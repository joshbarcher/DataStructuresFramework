using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DataStructures.Interfaces;
using DataStructures.PrimitiveWrappers;
using DataStructures.Algorithms;
using DataStructures.Basic;
using Algorithms;
using DataStructures.Exceptions;

namespace DataStructureExamples
{
    /// <summary>
    /// Application to show the uses of the binary search tree for word problems.
    /// </summary>
    public partial class WordClue : Form, Observer
    {
        private const int DICTIONARY_SIZE = 236983;
        private Tree<DSString> my_bst = new BinarySearchTree<DSString>();
        private bool my_dictionary_loaded = false;

        /// <summary>
        /// Sets up the window components.
        /// </summary>
        public WordClue()
        {
            InitializeComponent();
        }

        //handles the word search after the search button is pressed
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchForWords();
        }

        //searches for words in the dictionary that match unique permutations of all subsets
        //of the user input.
        private void searchForWords()
        {
            string input = txtLetters.Text;

            //check for bad input
            if (input.Length == 0)
            {
                MessageBox.Show("You must enter letters in the textbox to get results.");
                return;
            }
            else if (input.Length > 8)
            {
                MessageBox.Show("A maximum of eight characters is allowed due to the time-complexity of this algorithm.");
                return;
            }

            //tree to hold words
            if (!my_dictionary_loaded)
            {
                my_dictionary_loaded = true;
                addDictionary();
            }

            //get characters
            char[] letters = input.ToLower().ToCharArray();

            //get unique permutations
            Subsets s = new Subsets();
            s.addObserver(this);

            lblInfo.Text = "Getting letter permutations...";
            List<List<DSInteger>> permutation_indices = s.getUniquePermutationIndices<DSInteger>(letters.Length);

            lblInfo.Text = "Building possible words...";
            pbrProgress.Value = 0;
            pbrProgress.Maximum = permutation_indices.size();

            //get word candidates from the permutation indices
            Set<DSString> word_candidates = new HashSet<DSString>();
            for (int i = 0; i < permutation_indices.size(); i++)
            {
                StringBuilder builder = new StringBuilder();
                List<DSInteger> permutation = permutation_indices.get(i);
                for (int j = 0; j < permutation.size(); j++)
                {
                    builder.Append(letters[permutation.get(j).value]);
                }

                DSString possible = new DSString(builder.ToString());
                if (!word_candidates.contains(possible))
                {
                    word_candidates.add(possible);
                }

                //show progress
                updateProgress();
            }

            pbrProgress.Value = 0;
            pbrProgress.Maximum = word_candidates.size();
            lblInfo.Text = "Check Search Tree for words...";

            //sort candidates according to length and then alphabetically
            DSString[] sorted = word_candidates.toArray();
            Sorting<DSString>.Sort(Sorts.QuickSort, ref sorted, new StringLengthComparator());

            //clear old lookups
            lstWords.Items.Clear();

            //lookup each word in the bst
            for (int i = sorted.Length - 1; i >= 0; i--)
            {
                DSString current = sorted[i];
                if (my_bst.contains(current))
                {
                    lstWords.Items.Add(current.value);
                }

                //show progress
                updateProgress();
            }

            //show words found
            lblInfo.Text = "Words found: " + lstWords.Items.Count;
        }

        //adds the dictionary to the binary search tree
        private void addDictionary()
        {
            TextReader reader = new StreamReader(@"Files/Dictionary.txt");
            List<DSString> temp = new ArrayList<DSString>(DICTIONARY_SIZE);

            //progressbar
            pbrProgress.Value = 0;
            pbrProgress.Maximum = DICTIONARY_SIZE + DICTIONARY_SIZE;
            lblInfo.Text = "Loading Dictionary...";

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                DSString add = new DSString(line);
                temp.add(add);

                //show update
                updateProgress();
            }

            //get a split ordering
            List<DSString> split_ordering = Searching.binarySplit<DSString>(temp.toArray());

            //add the items to the tree so lookups remain logarithmic
            for (int i = 0; i < split_ordering.size(); i++)
            {
                my_bst.add(split_ordering.get(i));

                //show update
                updateProgress();
            }

            lblInfo.Text = "Loading Dictionary...";
        }

        /// <summary>
        /// Callback method for watching the permutation algorithm as it finds subsets and unique
        /// permutations.
        /// </summary>
        /// <param name="the_arguments">the total work to be done as an integer and current
        /// work already completed as an integer.</param>
        public void update(object[] the_arguments)
        {
            //check for bad information
            if (the_arguments.Length != 2)
            {
                throw new IllegalStateException("Bad update information sent to observer.");
            }

            try
            {
                int total = (int)the_arguments[0];
                int current = (int)the_arguments[1];

                //only change if necessary
                if (pbrProgress.Maximum != total)
                {
                    pbrProgress.Maximum = total;
                }

                pbrProgress.Value = current; //expected to change
                updateVisual();
            }
            catch (ClassCastException the_ex)
            {
                throw new IllegalStateException("Bad update information sent to observer.");
            }
        }

        //Updates the application visual and increments the progress
        private void updateProgress()
        {
            pbrProgress.Value += 1;

            if (pbrProgress.Value % 50 == 0)
            {
                Application.DoEvents();
            }
        }

        //Updates the application visual
        private void updateVisual()
        {
            if (pbrProgress.Value % 50 == 0)
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Sorts a DSString wrapper first by string length and then alphabetically.
        /// </summary>
        private class StringLengthComparator : Comparator<DSString>
        {
            /// <summary>
            /// Compares the two string wrappers first by length and then alphabetically.
            /// </summary>
            /// <param name="the_one">the first string wrapper.</param>
            /// <param name="the_two">the second string wrapper.</4param>
            /// <returns>a negative number if the first string length is less than the second
            /// or both strings are equal length and the first string is alphabetically before
            /// the second or positive if the second string length is less than the second
            /// or both strings are equal length and the seconds string is alphabetically before
            /// the first, or returns zero if both strings are identical in length and characters.</returns>
            public int compare(DSString the_one, DSString the_two)
            {
                int one_length = the_one.value.Length;
                int two_length = the_two.value.Length;

                //check for length equality
                if (one_length == two_length)
                {
                    //return alphabetical difference
                    return the_two.value.CompareTo(the_one.value);
                }
                else
                {
                    //return length difference
                    return one_length - two_length;
                }
            }
        }
    }
}
