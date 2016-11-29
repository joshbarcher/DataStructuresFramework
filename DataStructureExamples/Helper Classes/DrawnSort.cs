using System;
using System.Linq;
using System.Text;
using System.Drawing;
using DataStructures.Interfaces;
using DataStructures.Algorithms;
using DataStructures.PrimitiveWrappers;
using System.ComponentModel;
using System.Threading;
using DataStructures.Basic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DataStructures.Academics;

namespace DataStructureExamples.Helper_Classes
{
    /// <summary>
    /// This is a helper class that manages the thread the sort works within and
    /// the generation of the sorting visual.
    /// </summary>
    public class DrawnSort : Observer
    {
        //drawing variables
        private Brush my_bar_brush = new SolidBrush(Color.Black);
        private Brush my_highlight_bar_brush = new SolidBrush(Color.Blue);

        //main members
        private Sorts my_sort;
        private DSInteger[] my_input_values;
        private int my_draw_width;
        private int my_draw_height;
        private int my_input_max;
        private Form my_parent; //link to parent form
        private ISynchronizeInvoke my_sync; //synchronize on the main form
        private drawUpdate my_cross_thread_draw; //this callback sends the buffer to be drawn to the window thread
        private object[] my_call_args = new object[1]; //argument sent to the callback thread
        private Thread my_thread;

        //state variables
        private double my_percentage_complete;
        private long my_start_time;
        private long my_time_taken;

        //drawing buffers
        private Bitmap my_buffer1;
        private Bitmap my_buffer2;
        private bool my_first_buffer = true;

        /// <summary>
        /// Sets up this drawing object with all necessary values to perform the sort, track and draw
        /// the sort and necessary multi-threading objects to run on a different thread than the 
        /// main window thread.
        /// </summary>
        /// <param name="the_sort">type of sort to perform.</param>
        /// <param name="the_input_values">input array for the sort.</param>
        /// <param name="the_draw_width">the width of the drawing surface.</param>
        /// <param name="the_draw_height">the height of the drawing surface.</param>
        /// <param name="the_input_max">the maximum value in the input array.</param>
        /// <param name="the_cross_thread_call">a callback method to perform updates to the drawing panel
        /// on the main window thread.</param>
        /// <param name="the_parent">link to the parent window.</param>
        public DrawnSort(Sorts the_sort, DSInteger[] the_input_values, int the_draw_width, int the_draw_height,
            int the_input_max, drawUpdate the_cross_thread_draw, Form the_parent)
            : this(the_sort, the_input_values, the_parent)
        {
            //save all main members
            my_draw_width = the_draw_width;
            my_draw_height = the_draw_height;
            my_input_max = the_input_max;
            my_sync = my_parent = the_parent;
            my_cross_thread_draw = the_cross_thread_draw;

            //setup buffers
            my_buffer1 = new Bitmap(the_draw_width, the_draw_height);
            my_buffer2 = new Bitmap(the_draw_width, the_draw_height);
        }

        /// <summary>
        /// Sets up the drawn sort to just return updates of how much of the sort has been completed.
        /// </summary>
        /// <param name="the_cross_thread_percent">the call back method to send percentages to.</param>
        public DrawnSort(Sorts the_sort, DSInteger[] the_input_values, Form the_parent)
        {
            my_sort = the_sort;
            my_input_values = the_input_values;
            my_sync = my_parent = the_parent;

            //setup the thread
            my_thread = new Thread(new ThreadStart(doSort));
            my_thread.Priority = ThreadPriority.AboveNormal;
            my_thread.Name = "Sort: " + my_sort.ToString();
        }

        /// <summary>
        /// Starts the sorting thread.
        /// </summary>
        public void start()
        {
            //start it running
            my_thread.Start();
        }

        /// <summary>
        /// Shows whether the drawing thread has stopped or not.
        /// </summary>
        /// <returns>false if the current thread is aborted or stopped, otherwise
        /// true for all other thread states.</returns>
        public bool active()
        {
            if (my_thread == null)
            {
                return false;
            }
            else
            {
                //make sure to only show not active for aborted or stopped threads
                ThreadState cur_state = my_thread.ThreadState;
                bool state = !(cur_state == ThreadState.Aborted || cur_state == ThreadState.Stopped);
                return state;
            }
        }

        /// <summary>
        /// Attempts to stop the sorting thread. Because of garbage collection this
        /// will not always immediately terminate the thread. Call active() to guarantee
        /// that the thread has ceased updating.
        /// </summary>
        public void stop()
        {
            my_thread.Abort();
        }

        //main thread loop that sorts an array of integers and performs a final visual update to
        //show the sorted input.
        private void doSort()
        {
            //starting again
            my_start_time = DateTime.Now.Ticks;

            DataStructures.Academics.Sorting<DSInteger> sorting =
                new DataStructures.Academics.Sorting<DSInteger>();
            sorting.addObserver(this);

            //only allow for drawing if needed
            bool supress_drawing = my_cross_thread_draw == null;
            //start the sort
            sorting.Sort(my_sort, ref my_input_values, supress_drawing);

            //force a final redraw if the class is drawing
            if (my_cross_thread_draw != null)
            {
                Bitmap buffer_write;
                Bitmap buffer_draw;
                getBuffers(out buffer_write, out buffer_draw);
                drawBars(buffer_draw, buffer_draw, my_input_values, null);
            }

            //all done
            my_time_taken = DateTime.Now.Ticks - my_start_time;
        }

        /// <summary>
        /// This observer method allows for the Academics.Sorting class to update this class with
        /// the internal state of array values.
        /// </summary>
        /// <param name="the_args">the information sent from the Academics.Sorting class.</param>
        public void update(object[] the_args)
        {
            MessagingType type = (MessagingType)the_args[0];

            //if we are drawing and a drawing message was sent
            if (my_cross_thread_draw != null && type == MessagingType.Drawing)
            {
                Bitmap buffer_write;
                Bitmap buffer_draw;
                getBuffers(out buffer_write, out buffer_draw);

                //find which sort is active and callback accordingly
                switch (my_sort)
                {
                    case Sorts.ShellSort:
                        //shell sort draws gap values (a set of highlights)
                        drawShellSort(buffer_write, buffer_draw, the_args);
                        break;
                    case Sorts.HeapSort:
                        //heap sort needs to gain access to the internal heap array on the first iteration
                        drawHeapSort(buffer_write, buffer_draw, the_args);
                        break;
                    case Sorts.MergeSort:
                        //merge sort draws two markers (the high/low values)
                        drawBars(buffer_write, buffer_draw, my_input_values, new DSInteger[] { new DSInteger((int)the_args[1]), new DSInteger((int)the_args[2]) });
                        break;
                    default: //all others drawn with a marker and array
                        drawBars(buffer_write, buffer_draw, my_input_values, new DSInteger[] { new DSInteger((int)the_args[1]) });
                        break;
                }
            }
            else if (type == MessagingType.PercentDone)
            {
                //lock percentage complete
                lock (this)
                {
                    percentage_complete = Convert.ToDouble(the_args[1]);
                }
            }
        }

        //performs a page flipping routine where for each iteration of the drawing routine
        //one buffer is used for drawing and one for writing.
        private void getBuffers(out Bitmap the_buffer_write, out Bitmap the_buffer_draw)
        {
            if (my_first_buffer)
            {
                the_buffer_write = my_buffer1;
                the_buffer_draw = my_buffer2;
                my_first_buffer = false;
            }
            else
            {
                the_buffer_write = my_buffer2;
                the_buffer_draw = my_buffer1;
                my_first_buffer = true;
            }
        }

        //draws the array and gap indices for shell sort as highlights
        private void drawShellSort(Bitmap the_buffer_write, Bitmap the_buffer_draw, object[] the_args)
        {
            //get the indices of this gap insertion sort
            int gap = (int)the_args[1];
            int j = (int)the_args[2];
            List<DSInteger> indices = new LinkedList<DSInteger>();

            //mark all gap indices
            for (int i = j; i >= 0; i -= gap)
            {
                indices.add(new DSInteger(i));
            }

            drawBars(the_buffer_write, the_buffer_draw, my_input_values, indices.toArray());
        }

        //draws the array and current index as a highlight
        private void drawHeapSort(Bitmap the_buffer_write, Bitmap the_buffer_draw, object[] the_args)
        {
            drawBars(the_buffer_write, the_buffer_draw, (DSInteger[])the_args[1], new DSInteger[] { new DSInteger((int)the_args[2]) });
        }

        //draws an array of bars and highlights to the write buffer and sends a callback to the main
        //window thread with the draw buffer to be drawn.
        private void drawBars(Bitmap the_buffer_write, Bitmap the_buffer_draw,
            DSInteger[] the_inputs, DSInteger[] the_highlights)
        {
            //write to the write buffer
            Graphics g = Graphics.FromImage(the_buffer_write);
            g.Clear(Color.Gold);

            float main_bar_width = (my_draw_width * 1.0f) / the_inputs.Length;

            //draw main bars
            for (int i = 0; i < the_inputs.Length; i++)
            {
                //don't draw null elements (heap sort)
                if (the_inputs[i] != null)
                {
                    drawBar(my_bar_brush, g, main_bar_width, the_inputs[i].value, i);
                }
            }

            //draw highlights
            if (the_highlights != null)
            {
                for (int i = 0; i < the_highlights.Length; i++)
                {
                    //don't draw null elements (heap sort)
                    if (the_inputs[the_highlights[i].value] != null)
                    {
                        int index = the_highlights[i].value;
                        drawBar(my_highlight_bar_brush, g, main_bar_width,
                            the_inputs[index].value, index);
                    }
                }
            }
            g.Flush(FlushIntention.Sync); //force the drawing to complete

            //update the main window thread
            my_call_args[0] = the_buffer_draw;
            my_sync.Invoke(my_cross_thread_draw, my_call_args);
        }

        //draws a single bar (whether highlighted or not)
        private void drawBar(Brush the_brush, Graphics the_g, float the_main_bar_width,
            int the_bar_value, int the_bar_index)
        {
            //increase bar value to be one-based
            //make the height the ratio of the values to the max value multiplied by the draw height
            float bar_height = (((the_bar_value + 1) * 1.0f) / my_input_max) * my_draw_height;
            float bar_left = the_bar_index * the_main_bar_width;
            float bar_top = my_draw_height - bar_height;

            the_g.FillRectangle(the_brush, bar_left, bar_top, the_main_bar_width, bar_height);
        }

        /// <summary>
        /// Returns a string representation of the drawn sort.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            return my_sort.ToString();
        }

        /// <summary>
        /// Access to the percentage completed.
        /// </summary>
        public double percentage_complete
        {
            get { return my_percentage_complete; }
            set { my_percentage_complete = value; }
        }

        /// <summary>
        /// Access to the time elapsed for the sort (this value will be 0 until
        /// the sort is finished).
        /// </summary>
        public long time_taken
        {
            get { return my_time_taken; }
        }
    }
}
