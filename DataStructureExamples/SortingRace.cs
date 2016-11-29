using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataStructureExamples.Helper_Classes;
using DataStructures.Basic;
using DataStructures.Interfaces;
using DataStructures.Algorithms;
using DataStructures.PrimitiveWrappers;
using System.Threading;
using DataStructures.Exceptions;

namespace DataStructureExamples
{
    /// <summary>
    /// Shows a race simulation of each of the sorts and the time they take to complete
    /// a sort with a given input.
    /// </summary>
    public partial class SortingRace : Form
    {
        //sorting constants
        private const int NUMBER_OF_SORTS = 7;
        private const int SMALL_MAX = 100; //small maximum values generated
        private const int LARGE_MAX = 100000; //large maximum values generated
        private const int NUMBER_OF_ELEMENTS = 5000; //number of elements sorted

        //links a sort to a progressbar to show the user how far the sort has progressed
        private Map<DSString, ProgressBar> my_progress_bars = new HashMap<DSString, ProgressBar>(NUMBER_OF_SORTS);
        //links a sort to a label to show what 'place' the sort finished in the race
        private Map<DSString, Label> my_sort_labels = new HashMap<DSString, Label>(NUMBER_OF_SORTS);
        //list of completed times for the sorts
        private List<FinishTime> my_completed = new ArrayList<FinishTime>(NUMBER_OF_SORTS);
        //links a sort to the thread that performs the sort
        private Map<DSString, DrawnSort> my_sorts = new HashMap<DSString, DrawnSort>(NUMBER_OF_SORTS);

        private string[] my_sort_types = Enum.GetNames(Sorts.BubbleSort.GetType());
        private Random my_rand = new Random();

        /// <summary>
        /// Sets up the components for the window.
        /// </summary>
        public SortingRace()
        {
            InitializeComponent();

            //setup links to progressbars and labels
            addLinks();
        }

        /// <summary>
        /// Updates the progress bars on the window to display the finished percentage
        /// for each sort.
        /// </summary>
        public void updatePercentage()
        {
            //loop through all sorts
            for (int i=0; i < my_sort_types.Length; i++)
            {
                //find the sort and update the sort's progress bar
                DSString sort = new DSString(my_sort_types[i]);
                DrawnSort ds = my_sorts.get(sort);
                ProgressBar bar = my_progress_bars.get(sort);
                bar.Value = (int)(100.0 * ds.percentage_complete);

                //if the sort is finished and has not been marked so
                if (ds.time_taken != 0 && !checkCompletedContains(sort))
                {
                    //record the finish time
                    my_completed.add(new FinishTime(sort, new DSLong(ds.time_taken)));
                }
            }

            //check for whether all labels are correct
            int count = 0;
            long last = 0;
            FinishTime[] times = my_completed.toArray();
            Sorting<FinishTime>.Sort(Sorts.InsertionSort, ref times); //sort the finish times
            for (int i=0; i < times.Length; i++)
            {
                FinishTime sort_done = times[i];
                //this only advances count if a different finish time was found (it recognizes the ties)
                if (last != sort_done.finish_time.value)
                {
                    count++;
                }
                last = sort_done.finish_time.value;

                my_sort_labels.get(sort_done.sort).Text = sort_done.sort.value + " (" + count + ")";
            }

            //check for all sorts finished
            if (my_completed.size() == NUMBER_OF_SORTS)
            {
                Application.DoEvents();
                btnStartTheRace.Enabled = true;
                tmrUpdate.Enabled = false;
                return;
            }
            Application.DoEvents();
        }

        //checks whether the list of completed elements contains a sort.
        private bool checkCompletedContains(DSString the_sort)
        {
            //loop through and compare sort names
            Iterator<FinishTime> it = my_completed.iterator();
            while (it.hasNext())
            {
                if (it.next().sort.Equals(the_sort))
                {
                    return true;
                }
            }
            return false;
        }

        //cleans up old races and starts the sort threads for a new race.
        private void startRace()
        {
            //setup a new race
            clearLastRaceValues();
            clearOldSorts();

            //generate the drawing objects
            for (int i = 0; i < my_sort_types.Length; i++)
            {
                DSString cur_sort = new DSString(my_sort_types[i]);
                Sorts type = (Sorts)Enum.Parse(Sorts.BubbleSort.GetType(), cur_sort.value);
                my_sorts.put(cur_sort, new DrawnSort(type, getInput(), this));
            }

            tmrUpdate.Enabled = true;

            //start the sorts
            Iterator<DrawnSort> it = my_sorts.values().iterator();
            while (it.hasNext())
            {
                it.next().start();
            }
        }

        //gets the input the user wants for the sorts.
        private DSInteger[] getInput()
        {
            //match the radio button to the input wanted
            if (rdbLargeInput.Checked)
            {
                return getRandomIntegersLarge();
            }
            else if (rdbSmallInput.Checked)
            {
                return getRandomIntegersSmall();
            }
            else if (rdbAllSameInput.Checked)
            {
                return getSingleIntegerList();
            }
            else if (rdbPermutation.Checked)
            {
                return getPermutation();
            }
            else if (rdbSortedAscending.Checked)
            {
                return getSortedIntegersASC();
            }
            else
            {
                return getSortedIntegersDEC();
            }
        }

        //clears old race state values.
        private void clearLastRaceValues()
        {
            //clear old place counts for which sort finishes first
            my_completed.clear();

            //clear old label places
            for (int i = 0; i < my_sort_types.Length; i++)
            {
                DSString sort = new DSString(my_sort_types[i]);
                my_sort_labels.get(sort).Text = sort.value;
            }

            //clear old progress bar values
            Iterator<ProgressBar> it = my_progress_bars.values().iterator();
            {
                while (it.hasNext())
                {
                    it.next().Value = 0;
                }
            }
        }

        //stops old sorting threads.
        private void clearOldSorts()
        {
            //stop all threads
            Iterator<DrawnSort> it = my_sorts.values().iterator();
            while (it.hasNext())
            {
                DrawnSort ds = it.next();
                //if the old thread is still not stopped
                if (ds.active())
                {
                    ds.stop();
                    Cursor = Cursors.WaitCursor;

                    //loop while the thread is active
                    while (ds.active())
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }

                    Cursor = Cursors.Default;
                }
            }

            //clear old entries
            my_sorts.clear();
        }

        //adds links between sorts and progressbar/labels.
        private void addLinks()
        {
            addSingleLink(new DSString("BubbleSort"), pbrBubbleSort, lblBubbleSort);
            addSingleLink(new DSString("SelectionSort"), pbrSelectionSort, lblSelectionSort);
            addSingleLink(new DSString("InsertionSort"), pbrInsertionSort, lblInsertionSort);
            addSingleLink(new DSString("ShellSort"), pbrShellSort, lblShellSort);
            addSingleLink(new DSString("MergeSort"), pbrMergeSort, lblMergeSort);
            addSingleLink(new DSString("QuickSort"), pbrQuickSort, lblQuickSort);
            addSingleLink(new DSString("HeapSort"), pbrHeapSort, lblHeapSort);
        }

        //links a sort to a progressbar and a label.
        private void addSingleLink(DSString the_sort, ProgressBar the_pbar, Label the_label)
        {
            my_progress_bars.put(the_sort, the_pbar);
            my_sort_labels.put(the_sort, the_label);
        }

        //gets an array of integers within a large range of values.
        private DSInteger[] getRandomIntegersLarge()
        {
            //get an array of random integers
            DSInteger[] return_value = new DSInteger[NUMBER_OF_ELEMENTS];
            for (int i = 0; i < NUMBER_OF_ELEMENTS; i++)
            {
                return_value[i] = new DSInteger(my_rand.Next(0, LARGE_MAX));
            }

            //randomize them
            Randomization.shuffleArray<DSInteger>(ref return_value);

            return return_value;
        }

        //gets an array of integers within a small range of values.
        private DSInteger[] getRandomIntegersSmall()
        {
            //get an array of random integers
            DSInteger[] return_value = new DSInteger[NUMBER_OF_ELEMENTS];
            for (int i = 0; i < NUMBER_OF_ELEMENTS; i++)
            {
                return_value[i] = new DSInteger(my_rand.Next(0, SMALL_MAX));
            }

            //randomize them
            Randomization.shuffleArray<DSInteger>(ref return_value);

            return return_value;
        }

        //get an array where every value is the same integer.
        private DSInteger[] getSingleIntegerList()
        {
            DSInteger[] return_value = new DSInteger[NUMBER_OF_ELEMENTS];
            for (int i = 0; i < NUMBER_OF_ELEMENTS; i++)
            {
                //all elements are the integer zero
                return_value[i] = new DSInteger(0);
            }

            return return_value;
        }

        //gives a permutation of the first n integers in array form.
        private DSInteger[] getPermutation()
        {
            //create a permutation of the first n integers
            DSInteger[] return_value = new DSInteger[NUMBER_OF_ELEMENTS];
            for (int i = 0; i < NUMBER_OF_ELEMENTS; i++)
            {
                return_value[i] = new DSInteger(i);
            }

            //randomize them
            Randomization.shuffleArray<DSInteger>(ref return_value);

            return return_value;
        }

        //creates an array that is a sorted permutation of the first n integers (in ascending order).
        private DSInteger[] getSortedIntegersASC()
        {
            //create a permutation of the first n integers
            DSInteger[] return_value = new DSInteger[NUMBER_OF_ELEMENTS];
            for (int i = 0; i < NUMBER_OF_ELEMENTS; i++)
            {
                return_value[i] = new DSInteger(i);
            }

            //sort them
            Sorting<DSInteger>.Sort(Sorts.QuickSort, ref return_value);

            return return_value;
        }

        //creates an array that is a sorted permutation of the first n integers (in descending order).
        private DSInteger[] getSortedIntegersDEC()
        {
            //create a permutation of the first n integers
            DSInteger[] return_value = new DSInteger[NUMBER_OF_ELEMENTS];
            for (int i = 0; i < NUMBER_OF_ELEMENTS; i++)
            {
                return_value[i] = new DSInteger(i);
            }

            //sort them and then reverse them (descending order)
            Sorting<DSInteger>.Sort(Sorts.QuickSort, ref return_value);
            Arrays.reverse<DSInteger>(return_value);

            return return_value;
        }

        //updates the progressbars on the window every time the timer requires an update.
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            updatePercentage();
        }

        //clears old threads when the window is closed (if necessary).
        private void SortingRace_FormClosing(object sender, FormClosingEventArgs e)
        {
            //make sure all threads are closed
            clearOldSorts();
        }

        //starts the sort race with the input from the user.
        private void btnStartTheRace_Click(object sender, EventArgs e)
        {
            btnStartTheRace.Enabled = false;
            tmrUpdate.Enabled = true;
            startRace();
        }

        /// <summary>
        /// Helper class that uses the pair pattern to store both a sort type and finish
        /// time for the sorting algorithms in the SortingRace class.
        /// </summary>
        private class FinishTime : Comparable<FinishTime>
        {
            private DSString my_sort;
            private DSLong my_finish_time;

            /// <summary>
            /// Initializes the class with both a sort type and finish time.
            /// </summary>
            /// <param name="the_sort"></param>
            /// <param name="the_finish_time"></param>
            public FinishTime(DSString the_sort, DSLong the_finish_time)
            {
                Preconditions.checkNull(the_sort);
                Preconditions.checkNull(the_finish_time);

                my_sort = the_sort;
                my_finish_time = the_finish_time;
            }

            /// <summary>
            /// Compares this FinishTime with another. The comparison is based entirely
            /// on the time at which the sort finished.
            /// </summary>
            /// <param name="the_other">the other FinishTime.</param>
            /// <returns>the difference between this object and the_other object's time finished.</returns>
            public int compareTo(FinishTime the_other)
            {
                return (int)(finish_time.value - the_other.finish_time.value);
            }

            /// <summary>
            /// Gives a string representation of the FinishTime object.
            /// </summary>
            /// <returns>a string representation.</returns>
            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("Sort: ");
                builder.Append(sort.value.ToString());
                builder.Append(", Time: ");
                builder.Append(finish_time.ToString());
                return builder.ToString();
            }

            /// <summary>
            /// Access to sort type.
            /// </summary>
            public DSString sort
            {
                get { return my_sort; }
                set { my_sort = value; }
            }

            /// <summary>
            /// Access to finish time.
            /// </summary>
            public DSLong finish_time
            {
                get { return my_finish_time; }
                set { my_finish_time = value; }
            }
        }
    }
}
