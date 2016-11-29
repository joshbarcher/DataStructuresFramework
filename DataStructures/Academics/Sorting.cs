using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Basic;
using DataStructures.HelperClasses;
using DataStructures.Exceptions;
using DataStructures.Algorithms;

namespace DataStructures.Academics
{
    /// <summary>
    /// This class is a copy of the Sorting class in the DataStructures.Algorithms namespace.
    /// I have added a copy here, that is not static and is observable, for watching the
    /// algorithms as they take place. This class hands out a copy of an internal array at the
    /// beginning of each sort to be viewed while the sort occurs. This makes this class 
    /// dangerous at best since the algorithms inside can be broken by altering the array. That
    /// being said, this class is merely here for academic purposes and should not be used except
    /// for that purpose. Instead use the DataStructures.Algorithms.Sorting class.
    /// 
    /// The cloneable requirement for this sorting class is to ensure that certain algorithms
    /// can recieve cloned content. For example, the heap sort requires access to the internal structure
    /// of the binary heap. I do not wish to allow access to this information, so I clone the
    /// content and return it.
    /// </summary>
    public class Sorting<T> : Observable where T : class, Cloneable
    {
        private const double SHELL_CONSTANT = 2.2;
        private const int QUICKSORT_CUTOFF = 10;

        private static Comparator<T> my_comparator;

        /// <summary>
        /// Sorts an array using the strategy pattern. The Sorts enumeration is used
        /// to choose a strategy by which to sort with.
        /// </summary>
        /// <typeparam name="T">the reference type of elements stored in the array to 
        /// sorted.</typeparam>
        /// <param name="the_strategy">the type of sort to perform.</param>
        /// <param name="the_array">the array of comparable elements to be sorted.</param>
        public void Sort(Sorts the_strategy, ref T[] the_array, bool the_supress_drawing)
        {
            Preconditions.checkNull(the_array);

            //choose a strategy and sort
            switch (the_strategy)
            {
                case Sorts.BubbleSort:
                    bubbleSort(ref the_array, the_supress_drawing);
                    break;
                case Sorts.InsertionSort:
                    insertionSort(ref the_array, the_supress_drawing);
                    break;
                case Sorts.SelectionSort:
                    selectionSort(ref the_array, the_supress_drawing);
                    break;
                case Sorts.ShellSort:
                    shellSort(ref the_array, the_supress_drawing);
                    break;
                case Sorts.MergeSort:
                    mergeSort(ref the_array, the_supress_drawing);
                    break;
                case Sorts.QuickSort:
                    quickSort(ref the_array, the_supress_drawing);
                    break;
                case Sorts.HeapSort:
                    heapSort(ref the_array, the_supress_drawing);
                    break;
                default:
                    throw new ArgumentException("No such enum value recognized.");
            }
        }

        /// <summary>
        /// Sorts an array using the strategy pattern. The Sorts enumeration is used
        /// to choose a strategy by which to sort with.
        /// </summary>
        /// <typeparam name="T">the reference type of elements stored in the array to 
        /// sorted.</typeparam>
        /// <param name="the_strategy">the type of sort to perform.</param>
        /// <param name="the_array">the array of comparable elements to be sorted.</param>
        /// <param name="the_comparator">a comparator to compare elements.</param>
        public void Sort(Sorts the_strategy, ref T[] the_array, Comparator<T> the_comparator, bool the_supress_drawing)
        {
            //comparator for sort
            my_comparator = the_comparator;

            //choose a strategy and sort
            switch (the_strategy)
            {
                case Sorts.BubbleSort:
                    bubbleSort(ref the_array, the_supress_drawing);
                    break;
                case Sorts.InsertionSort:
                    insertionSort(ref the_array, the_supress_drawing);
                    break;
                case Sorts.SelectionSort:
                    selectionSort(ref the_array, the_supress_drawing);
                    break;
                case Sorts.ShellSort:
                    shellSort(ref the_array, the_supress_drawing);
                    break;
                case Sorts.MergeSort:
                    mergeSort(ref the_array, the_supress_drawing);
                    break;
                case Sorts.QuickSort:
                    quickSort(ref the_array, the_supress_drawing);
                    break;
                case Sorts.HeapSort:
                    heapSort(ref the_array, the_supress_drawing);
                    break;
                default:
                    throw new ArgumentException("No such enum value recognized.");
            }

            //reset for next sort
            my_comparator = null;
        }

        //performs the bubble sort on an array
        //
        //worst-case: O(n^2) time.
        //
        //pros: O(1) additional space.
        //cons: lots of swapping of elements.
        //      bad worst case.
        private void bubbleSort(ref T[] the_array, bool the_supress_drawing)
        {
            for (int i = 0; i < the_array.Length - 1; i++)
            {
                //at the end of each iteration the ith greatest element will be in 
                //the correct position, so no longer check that index
                for (int j = 0; j < the_array.Length - i - 1; j++)
                {
                    if (compare(the_array[j], the_array[j + 1]) > 0)
                    {
                        Arrays.swap<T>(the_array, j, j + 1);

                        if (!the_supress_drawing)
                        {
                            sendUpdate(MessagingType.Drawing, j + 1);
                        }
                    }
                }

                sendUpdate(MessagingType.PercentDone, (i * 1.0) / (the_array.Length - 2));
            }
        }

        //performs the insertion sort on an array
        //
        //worst-case: O(n^2) time.
        //almost sorted list: O(n) time (roughly).
        //
        //pros: fast for an almost sorted array.
        //      online - it can sort arrays as it recieves them.
        //      O(1) additional space.
        //cons: bad worst case.
        private void insertionSort(ref T[] the_array, bool the_supress_drawing)
        {
            insertionSort(ref the_array, 0, the_array.Length - 1, true, the_supress_drawing);
        }

        //performs the selection sort on an array
        //
        //worst-case: O(n^2) time.
        //
        //pros: O(1) additional space.
        //      less swapping of elements than other sorts in this complexity range.
        //cons: bad worst case.
        private void selectionSort(ref T[] the_array, bool the_supress_drawing)
        {
            for (int i = 0; i < the_array.Length - 1; i++)
            {
                //start with a maximum
                T min = the_array[i];
                int max_index = i;

                //find the element in the ith smallest position
                for (int j = i + 1; j < the_array.Length; j++)
                {
                    if (compare(the_array[j], min) < 0)
                    {
                        min = the_array[j];
                        max_index = j;

                        if (!the_supress_drawing)
                        {
                            sendUpdate(MessagingType.Drawing, j);
                        }
                    }
                }

                sendUpdate(MessagingType.PercentDone, (i * 1.0) / (the_array.Length - 2));

                //swap the correct element to its final position
                Arrays.swap<T>(the_array, max_index, i);
            }
        }

        //performs the shell sort on an array
        //
        //worst-case: O(n^2) time for the original shell gap, 
        //            but other gaps (such as this one) give sub-quadratic time.
        //
        //pros: sub-quadratic time.
        //cons: for almost sorted arrays, insertion sort has less overhead.
        private void shellSort(ref T[] the_array, bool the_supress_drawing)
        {
            //delta is the gap for each iteration of insertion sort on a sub-array
            //SHELL_CONSTANT is a suggested constant that works well for this algorithm (2.2)
            for (int delta = the_array.Length / 2; delta > 0; delta = (delta == 2 ? 1 : (int)(delta / SHELL_CONSTANT)))
            {
                //perform insertion sort on this sub-array
                for (int j = delta; j < the_array.Length; j++)
                {

                    T temp = the_array[j];
                    int k;
                    for (k = j; k >= delta; k -= delta)
                    {
                        if (compare(the_array[k], the_array[k - delta]) < 0)
                        {
                            Arrays.swap<T>(the_array, k, k - delta);
                        }
                        else
                        {
                            break;
                        }
                    }
                    the_array[k] = temp;

                    if (!the_supress_drawing)
                    {
                        sendUpdate(MessagingType.Drawing, delta, j);
                    }
                }

                int max = the_array.Length / 2;
                sendUpdate(MessagingType.PercentDone, (max - delta) / (max - 1));
            }
        }

        //performs the merge sort on an array
        //
        //worst-case: O(nlogn) time.
        //
        //pros: good worst case.
        //cons: O(n) additional space.
        private void mergeSort(ref T[] the_array, bool the_supress_drawing)
        {
            mergeSort(ref the_array, new T[the_array.Length], 0, the_array.Length - 1, the_supress_drawing);
        }

        //performs the bubble sort on an array
        //
        //worst-case: O(n^2) time.
        //average-case: O(nlogn) time.
        //
        //pros: faster on average than mergesort or heapsort.
        //      using a median value for a pivot reduces the chance of the worst case.
        //cons: worst case can cause the running time to degenerate to quadratic.
        private void quickSort(ref T[] the_array, bool the_supress_drawing)
        {
            quicksort(ref the_array, 0, the_array.Length - 1, the_supress_drawing);
        }

        //performs the heap sort on an array
        //
        //worst-case: O(nlogn) time.
        //
        //pros: guaranteed to be O(nlogn) time.
        //cons: O(1) additional space (due to the in-place sort implementation).
        private void heapSort(ref T[] the_array, bool the_supress_drawing)
        {
            BinaryHeap<T> heap = new BinaryHeap<T>(false, the_array);
            int index = heap.size(); //one-based due to the dummy header in the heap

            T[] internals = null;

            //constant space required
            while (!heap.isEmpty())
            {
                heap.internal_array[index] = heap.deleteMin();

                if (!the_supress_drawing)
                {
                    //send update
                    Internals.getHeapInternals<T>(heap, ref internals);
                    sendUpdate(MessagingType.Drawing, internals, index);
                }
                sendUpdate(MessagingType.PercentDone, ((heap.internal_array.Length - heap.size()) * 1.0) / heap.internal_array.Length);

                index--;
            }

            //copy the elements back to the initial array
            for (int i = 0; i < the_array.Length; i++)
            {
                the_array[i] = heap.internal_array[i + 1];
            }
        }

        //---------------- PUBLIC HELPER METHODS --------------------

        /// <summary>
        /// Determines whether an array is sorted in ascending or descending order.
        /// </summary>
        /// <param name="the_array">the source array to check.</param>
        /// <param name="the_ascending">if true the method checks for ascending
        /// sorted order, otherwise it checks for descending order.</param>
        /// <returns>true if sorted, otherwise false.</returns>
        public bool isSorted(T[] the_array, bool the_ascending)
        {
            //check for bad array or simple return
            if (the_array == null)
            {
                return false;
            }
            else if (the_array.Length < 2)
            {
                return true;
            }

            //check for inversions
            for (int i = 0; i < the_array.Length - 1; i++)
            {
                if (the_ascending) //normal sort
                {
                    if (compare(the_array[i], the_array[i + 1]) > 0)
                    {
                        return false;
                    }
                }
                else //backwards sort
                {
                    if (compare(the_array[i], the_array[i + 1]) < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //---------------- HELPER METHODS ------------------

        //compares elements using a comparator if given or comparable elements
        private int compare(T the_one, T the_two)
        {
            if (my_comparator != null)
            {
                return my_comparator.compare(the_one, the_two);
            }
            else
            {
                return ((Comparable<T>)the_one).compareTo(the_two);
            }
        }

        //----------------Recursive quicksort method-------------------
        //1. This method has a cutoff for small sub-arrays that would
        //have incur too much overhead by the last iterations of
        //quicksort.
        //2. This method only performs a single recursive call and then
        //loops back to the start of the method with new bounds. This is
        //to avoid non-logarithmic recursion depth.
        //3. This method recurses with the smaller sub-array at each step.
        //This guarantees that the recursion depth will not reach a greater
        //depth than logarithmic.
        private void quicksort(ref T[] the_array, int the_low, int the_high, bool the_supress_drawing)
        {
            //this loop allows for a limited recursion depth by avoiding tail recursion (see below)
            while (the_low < the_high)
            {
                //quick out to avoid overhead at small array length
                if (the_low + QUICKSORT_CUTOFF > the_high)
                {
                    insertionSort(ref the_array, the_low, the_high, false, the_supress_drawing);

                    //if the last quick out
                    if (the_high == the_array.Length - 1)
                    {
                        sendUpdate(MessagingType.PercentDone, 1.0); 
                    }

                    return;
                }
                else
                {
                    //median of three (small insertion sort)
                    int mid = (the_low + the_high) / 2;
                    if (compare(the_array[the_low], the_array[mid]) > 0)
                    {
                        Arrays.swap<T>(the_array, the_low, mid);
                    }
                    if (compare(the_array[mid], the_array[the_high]) > 0)
                    {
                        Arrays.swap<T>(the_array, mid, the_high);
                    }
                    if (compare(the_array[the_low], the_array[mid]) > 0)
                    {
                        Arrays.swap<T>(the_array, the_low, mid);
                    }

                    //swap partition variable out to the end of the array until partition is done
                    T pivot = the_array[mid];
                    Arrays.swap<T>(the_array, mid, the_high - 1);

                    //partition
                    int i = the_low, j = the_high - 1;
                    while (true)
                    {
                        while (compare(the_array[++i], pivot) < 0)
                        {
                        }
                        while (compare(the_array[--j], pivot) > 0)
                        {
                        }

                        if (i >= j)
                        {
                            break;
                        }

                        Arrays.swap<T>(the_array, i, j);
                    }

                    if (!the_supress_drawing)
                    {
                        sendUpdate(MessagingType.Drawing, i);
                    }
                    
                    //copy pivot back
                    Arrays.swap<T>(the_array, i, the_high - 1);

                    //this performs only every other recursive call and only performs 
                    //recursive calls on the smaller sub-array to guarantee no greater
                    //than logarithmic recursion depth

                    //smaller left list
                    if (i - the_low - 1 < the_high - i + 1)
                    {
                        //recursive call
                        quicksort(ref the_array, the_low, i - 1, the_supress_drawing); //sort smaller elements
                        the_low = i + 1;
                    }
                    else //smaller right list
                    {
                        //recursive call
                        quicksort(ref the_array, i + 1, the_high, the_supress_drawing); //sort smaller elements
                        the_high = i - 1;
                    }
                }
            }

            sendUpdate(MessagingType.PercentDone, ((the_array.Length - (the_high - the_low)) * 1.0) / the_array.Length);  
        }

        //Performs the insertion sort on a sub-array of the given array
        private void insertionSort(ref T[] the_array, int the_low, int the_high, bool the_throw_update, bool the_supress_drawing)
        {
            //check for all elements except one
            //since comparison is done between elements, one element is done implicitly
            for (int i = the_low + 1; i <= the_high; i++)
            {
                T temp = the_array[i];

                //make sure each item to the left of i is sorted
                //this is quick for an almost sorted list due to the break; statement
                int j;
                for (j = i; j > 0; j--)
                {
                    if (compare(temp, the_array[j - 1]) < 0)
                    {
                        the_array[j] = the_array[j - 1];
                    }
                    else
                    {
                        break;
                    }

                    //throw update for the actual insertion sort and not quicksort which uses this method
                    if (the_throw_update)
                    {
                        if (!the_supress_drawing)
                        {
                            sendUpdate(MessagingType.Drawing, j);
                        }
                    }
                }

                if (the_throw_update)
                {
                    sendUpdate(MessagingType.PercentDone, ((i * 1.0) / the_high));
                }

                //put the current element in place
                the_array[j] = temp;
            }
        }

        //performs a recursive mergesort on an array
        private void mergeSort(ref T[] the_array, T[] the_merge, int the_low, int the_high, bool the_supress_drawing)
        {
            if (the_high - the_low <= 0)
            {
                return;
            }

            int high_one = the_low + (the_high - the_low) / 2;
            int low_two = high_one + 1;

            //recurse with both sub-arrays
            mergeSort(ref the_array, the_merge, the_low, high_one, the_supress_drawing);
            mergeSort(ref the_array, the_merge, low_two, the_high, the_supress_drawing);

            //merge the sub-arrays
            merge(ref the_array, the_merge, the_low, high_one, low_two, the_high);

            if (!the_supress_drawing)
            {
                sendUpdate(MessagingType.Drawing, the_low, the_high);
            }
            sendUpdate(MessagingType.PercentDone, ((the_high - the_low + 1) * 1.0) / the_array.Length);
        }

        //merges two arrays from a lower bound on both to a higher bound
        private void merge(ref T[] the_array, T[] the_a_merge, int the_low_one, int the_high_one, 
            int the_low_two, int the_high_two)
        {
            int i = the_low_one, j = the_low_two;
            int total = the_high_two - the_low_one + 1;

            //merge the lists according to the ordering
            for (int k = 0; k < total; k++)
            {
                if (i > the_high_one)
                {
                    the_a_merge[the_low_one + k] = the_array[j++];
                }
                else if (j > the_high_two)
                {
                    the_a_merge[the_low_one + k] = the_array[i++];
                }
                else if (compare(the_array[i], the_array[j]) < 0) //first array's element is smaller
                {
                    the_a_merge[the_low_one + k] = the_array[i++];
                }
                else //second array's element is smaller/equal
                {
                    the_a_merge[the_low_one + k] = the_array[j++];
                }
            }

            //copy back the temporary array to the given array
            for (int k = the_low_one; k <= the_high_two; k++)
            {
                the_array[k] = the_a_merge[k];
            }
        }

        private void sendUpdate(params object[] the_args)
        {
            changed = true;
            //send arguments
            notifyUpdate(the_args);
        }
    }

    public enum MessagingType
    {
        Drawing,
        PercentDone
    }
}
