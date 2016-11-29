﻿using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DataStructures.Academics;
using DataStructures.Algorithms;
using DataStructures.Interfaces;
using DataStructures.PrimitiveWrappers;
using System.Drawing.Drawing2D;
using DataStructures.Basic;
using DataStructureExamples.Helper_Classes;

namespace DataStructureExamples
{
    /// <summary>
    /// Call back delegate for the sorting threads to update the GUI thread.
    /// </summary>
    /// <param name="the_bitmap">the buffer generated by the sorting thread.</param>
    public delegate void drawUpdate(Bitmap the_bitmap);

    public delegate void percentageUpdate(double the_percentage, string the_sort);

    /// <summary>
    /// Application that shows visually the steps required to sort a permutation of integers.
    /// </summary>
    public partial class SortVisual : Form
    {
        //input constants
        private const int MIN_VALUE = 50;
        private const int MAX_VALUE = 5000;
        private const string ERROR_MSG = "You must enter an integer from 50-1000 for input size.";

        private DrawnSort my_drawable; //sorting object
        private Graphics my_graphics; //graphics context for the drawing panel

        /// <summary>
        /// Sets up the application with default settings.
        /// </summary>
        public SortVisual()
        {
            InitializeComponent();

            setupGraphics();
        }

        /// <summary>
        /// Draws the current sort with the buffer given.
        /// </summary>
        /// <param name="the_bitmap">the sort buffer.</param>
        public void drawPanel(Bitmap the_bitmap)
        {
            my_graphics.DrawImage(the_bitmap, new RectangleF(0.0f, 0.0f, pnlDraw.Width, pnlDraw.Height),
                new RectangleF(0.0f, 0.0f, the_bitmap.Width, the_bitmap.Height), GraphicsUnit.Pixel);
            my_graphics.Flush(FlushIntention.Sync);
        }

        //gets a fresh graphics context to draw upon (this is called from
        //form_resize so that the context matches the panel size).
        private void setupGraphics()
        {
            my_graphics = pnlDraw.CreateGraphics();
        }

        //builds and starts a sorting thread of the given sorting type.
        private void sort(Sorts the_sort)
        {
            //removes the old sorting thread if present
            if (my_drawable != null)
            {
                resetOldThread();
            }

            //gets the maximum input value from the user
            int max = getMax();
            if (max == -1)
            {
                return;
            }

            //setup new sorting thread
            my_drawable = new DrawnSort(the_sort, getInputArray(max), pnlDraw.Width, pnlDraw.Height, max, drawPanel, this);

            //make sure old memory is reclaimed (otherwise a leak can occur)
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //start the sorting thread
            my_drawable.start();
        }

        //gets the maximum input type from the user.
        private int getMax()
        {
            int max_value = 0;
            try
            {
                max_value = Convert.ToInt32(txtInputSize.Text);

                //check for positive values
                if (max_value < MIN_VALUE)
                {
                    MessageBox.Show(ERROR_MSG);
                    return -1;
                }
                else if (max_value > MAX_VALUE) //check for too large of a value
                {
                    MessageBox.Show(ERROR_MSG);
                    return -1;
                }
            }
            catch (FormatException the_ex)
            {
                MessageBox.Show("You must enter a valid integer input for the sorting permutation.");
                return -1;
            }

            return max_value;
        }

        //forces an old thread to stop and loops until it has been aborted/stopped.
        private void resetOldThread()
        {
            //if the old thread is still not stopped
            if (my_drawable.active())
            {
                my_drawable.stop();
                Cursor = Cursors.WaitCursor;

                //loop while the thread is active
                while (my_drawable.active())
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }

                Cursor = Cursors.Default;
            }
        }

        //gives a permutation of the first n integers in array form.
        private DSInteger[] getInputArray(int the_max_value)
        {
            //create a permutation of the first n integers
            DSInteger[] return_value = new DSInteger[the_max_value];
            for (int i = 0; i < the_max_value; i++)
            {
                return_value[i] = new DSInteger(i);
            }

            //randomize them
            Randomization.shuffleArray<DSInteger>(ref return_value);

            return return_value;
        }

        //starts a sorting visual.
        private void btnStartVisual_Click(object the_sender, EventArgs the_e)
        {
            sort(getSortSelected());
        }

        //gets the current sort chosen through the sort radio buttons on the window.
        private Sorts getSortSelected()
        {
            if (rdbBubbleSort.Checked)
            {
                return Sorts.BubbleSort;
            }
            else if (rdbSelectionSort.Checked)
            {
                return Sorts.SelectionSort;
            }
            else if (rdbInsertionSort.Checked)
            {
                return Sorts.InsertionSort;
            }
            else if (rdbShellSort.Checked)
            {
                return Sorts.ShellSort;
            }
            else if (rdbMergeSort.Checked)
            {
                return Sorts.MergeSort;
            }
            else if (rdbQuickSort.Checked)
            {
                return Sorts.QuickSort;
            }
            else
            {
                return Sorts.HeapSort;
            }
        }

        //the resize event forces the application to create a new graphics context
        //that matches the resized panel dimensions.
        private void SortingRace_Resize(object sender, EventArgs e)
        {
            setupGraphics();
        }

        //shuts down any sorting thread that may be running
        private void SortVisual_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (my_drawable != null)
            {
                //remove the thread before exiting
                resetOldThread();
            }
        }

        
    }
}