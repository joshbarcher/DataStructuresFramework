using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataStructures.Interfaces;
using DataStructures.Basic;
using DataStructures.Academics;
using System.IO;
using DataStructures.PrimitiveWrappers;
using DataStructures.Exceptions;

namespace DataStructureExamples
{
    /// <summary>
    /// This application sets up a user parameterized hash set which is then opened internally
    /// and the inner hash table is visually displayed for the user. The application offers 
    /// many options to show the effects of the hash function used, input size, input type,
    /// collision handling and the clustering that occurs due to these settings.
    /// </summary>
    public partial class HashVisualization : Form
    {
        private const int MAX_INTEGER = 10000;
        private const int MAX_ITEMS = 1500;
        private const int MIN_ITEMS = 50;

        private Random my_random = new Random();
        private char[] my_alphabet = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 
            'y', 'z'};

        private HashSet<Cloneable> my_hash_set;
        private Cloneable[] my_data = null;

        /// <summary>
        /// This constructor sets up the windows application by initializing all components in the window.
        /// </summary>
        public HashVisualization()
        {
            InitializeComponent();
        }

        //handles the build function which builds the hash table visual when the build button is pressed
        private void btnBuild_Click(object sender, EventArgs e)
        {
            buildHashVisual();
        }

        //builds the hash visual on the window
        private void buildHashVisual()
        {
            //check for default input size
            if (txtItems.Text == "")
            {
                txtItems.Text = MIN_ITEMS.ToString();
            }

            //setup input size
            int items;
            try
            {
                items = Convert.ToInt32(txtItems.Text);
            }
            catch (FormatException the_ex)
            {
                MessageBox.Show("You must provide a valid integer for hash table size.");
                return;
            }

            //make sure the visual does it's job with a good input size
            if (items < MIN_ITEMS || items > MAX_ITEMS)
            {
                MessageBox.Show("You must enter 250-1500 as an input size.");
                return;
            }

            List<Cloneable> hash_list;

            //pick the input items
            if (rdbRandomString.Checked)
            {
                hash_list = getRandomStrings(items);
            }
            else if (rdbSequentialString.Checked)
            {
                hash_list = getSeqentialStrings(items);
            }
            else if (rdbRandomInteger.Checked)
            {
                hash_list = getRandomIntegers(items);
            }
            else
            {
                hash_list = getSeqentialIntegers(items);
            }

            //clear and add new items
            my_hash_set = getHashSet();
            for (int i = 0; i < hash_list.size(); i++)
            {
                my_hash_set.add(hash_list.get(i));
            }

            //setup the hash function label
            lblActualHashFunction.Text = ((StrategyHashSet<Cloneable>)my_hash_set).getStrategyFunction();

            //redraw the hash table
            pnlDraw.Refresh();
        }

        //gets the correct hash set with the chosen hash function
        private HashSet<Cloneable> getHashSet()
        {
            if (rdbModTableSize.Checked)
            {
                return HashSetFactory<Cloneable>.getHashSet(HashingStrategy.ModTableSize);
            }
            else
            {
                return HashSetFactory<Cloneable>.getHashSet(HashingStrategy.MultiplyPrimeModPrimeModTable);
            }
        }

        //sets up a label per column to show the item indices present in that column
        private void setupItemLabels(int the_item_size)
        {
            int row_size = the_item_size / 5;
            int row_2 = row_size * 2;
            int row_3 = row_size * 3;
            int row_4 = row_size * 4;
            lblItemsOne.Text = "Items 0 - " + (row_size - 1);
            lblItemsTwo.Text = "Items " + row_size + " - " + (row_2 - 1);
            lblItemsThree.Text = "Items " + row_2 + " - " + (row_3 - 1);
            lblItemsFour.Text = "Items " + row_3 + " - " + (row_4 - 1);
            lblItemsFive.Text = "Items " + row_4 + " - " + (the_item_size - 1);
        }

        //gets a list of randomly generated strings
        private List<Cloneable> getRandomStrings(int the_items)
        {
            //make sure there a possible unique permutation of all unique strings
            int max_string_length = the_items / my_alphabet.Length;

            //extra for remainder
            if (the_items % my_alphabet.Length != 0)
            {
                max_string_length++;
            }

            //build a list of n random strings
            List<Cloneable> return_value = new ArrayList<Cloneable>();
            for (int i = 0; i < the_items; i++)
            {
                //pick out all random characters
                StringBuilder builder = new StringBuilder();
                for (int j = 0; j < max_string_length; j++)
                {
                    builder.Append(my_alphabet[my_random.Next(0, 26)]);
                }
                return_value.add(new DSString(builder.ToString()));
            }

            return return_value;
        }

        //gets a list of sequential strings (the strings are picked out of the dictionary
        //and have close proximity to each other).
        private List<Cloneable> getSeqentialStrings(int the_items)
        {
            //build a list of n random strings
            List<Cloneable> return_value = new ArrayList<Cloneable>();

            //read sequential strings out of the dictionary
            TextReader reader = new StreamReader("Files/Dictionary.txt");

            //start reading at a random starting point
            int rand_start = my_random.Next(0, 10000);
            int count = 0;
            while (count < rand_start)
            {
                reader.ReadLine();
                count++;
            }

            string line;
            count = 0;
            while (count <= the_items && (line = reader.ReadLine()) != null)
            {
                return_value.add(new DSString(line));
                count++;
            }

            return return_value;
        }

        //gets a list of random integers.
        private List<Cloneable> getRandomIntegers(int the_items)
        {
            //build a list of n random integers
            List<Cloneable> return_value = new ArrayList<Cloneable>();

            //random number between low and high
            for (int i = 0; i < the_items; i++)
            {
                return_value.add(new DSInteger(my_random.Next(0, MAX_INTEGER)));
            }

            return return_value;
        }

        //gets a list of sequential integers.
        private List<Cloneable> getSeqentialIntegers(int the_items)
        {
            //build a list of n random integers
            List<Cloneable> return_value = new ArrayList<Cloneable>();

            int offset = my_random.Next(0, MAX_INTEGER); //get a random offset to try different runs of integers

            //random number between low and high
            for (int i = 0; i < the_items; i++)
            {
                return_value.add(new DSInteger(offset + i));
            }

            return return_value;
        }

        //handles the visual of the hash table's elements on the panel pnlDraw
        private void pnlDraw_Paint(object sender, PaintEventArgs e)
        {
            //only draw if ready
            if (my_hash_set != null)
            {
                Internals.getHashSetInternals<Cloneable>(my_hash_set, ref my_data);

                //get a graphics context to draw with
                Graphics g = e.Graphics;

                int row_count = my_data.Length / 5; //number of elements per row
                int col_width = (pnlDraw.Width - 20) / 5; // width of each coloum of elements
                double delta = (pnlDraw.Height * 1.0) / row_count; //get the distance between elements and draw them

                //loop through all elements and draw them
                for (int i = 0; i < my_data.Length; i++)
                {
                    int col = i / row_count; //current column
                    int left = 4 + col * 4 + col * col_width; //left x value for the line being drawn
                    int right = left + col_width; //right x value for the line being drawn

                    //draw the line
                    Pen p = new Pen(new SolidBrush(Color.Black));
                    if (my_data[i] != null)
                    {
                        int y = (int)(delta * (i % row_count));
                        g.DrawLine(p, new Point(left, y), new Point(right, y));
                    }
                }

                //setup visual labels for row counts
                setupItemLabels(my_data.Length);
            }
        }

        //redraws the visual when the form is resized.
        private void HashVisualization_ResizeEnd(object sender, EventArgs e)
        {
            pnlDraw.Refresh();
        }
    }
}
