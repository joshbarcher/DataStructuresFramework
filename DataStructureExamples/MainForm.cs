using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataStructureExamples
{
    /// <summary>
    /// Main entry point for the data structures example application. This window
    /// has many buttons which link to each individual example.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// This constructor initializes all components on the window.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        //opens the word clue application
        private void btnWordClues_Click(object sender, EventArgs e)
        {
            WordClue form = new WordClue();
            form.Show();
        }

        private void btnHashVisualization_Click(object sender, EventArgs e)
        {
            HashVisualization form = new HashVisualization();
            form.Show();
        }

        private void btnMazeGeneration_Click(object sender, EventArgs e)
        {
            MazeGeneration form = new MazeGeneration();
            form.Show();
        }

        private void btnGraphVisuals_Click(object sender, EventArgs e)
        {
            GraphVisualization form = new GraphVisualization();
            form.Show();
        }

        private void btnSortingRace_Click(object sender, EventArgs e)
        {
            SortVisual form = new SortVisual();
            form.Show();
        }

        private void btnSortingRace_Click_1(object sender, EventArgs e)
        {
            SortingRace form = new SortingRace();
            form.Show();
        }
    }
}
