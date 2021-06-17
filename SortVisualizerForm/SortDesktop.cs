using SortVisualizerForm.Algoritms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortVisualizerForm
{
    public partial class SortDesktop : Form
    {
        /// <summary>
        /// Array that we use for sorting.
        /// </summary>
        private int[] Array { get; set; }

        /// <summary>
        /// Use to show progress of sorting.
        /// </summary>
        Graphics graph { get; set; } = null;

        /// <summary>
        /// Elemenys value.
        /// </summary>
        private int MaxHeight { get; set; }

        /// <summary>
        /// Use width of display for our count of elements in array.
        /// </summary>
        private int NumEntires { get; set; }

        /// <summary>
        /// Set up settings.
        /// </summary>
        public SortDesktop()
        {
            InitializeComponent();
            this.Text = "SortDesktop";
        }
        /// <summary>
        /// Exit button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Reset button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            graph = displayAlg.CreateGraphics();
            NumEntires = displayAlg.Width; 
            MaxHeight = displayAlg.Height;
            Array = new int[NumEntires];
            // color our display
            graph.FillRectangle(new SolidBrush(Color.Black), 0, 0, NumEntires, MaxHeight);
            Random random = new Random();
            //randomize elements
            for (int i = 0; i < NumEntires; i++)
            {
                Array[i] = random.Next(0, MaxHeight);
            }
            //draw on display
            for (int i = 0; i < NumEntires; i++)
            {
                graph.FillRectangle(new SolidBrush(Color.White), i, MaxHeight - Array[i], 2, MaxHeight);
            }
        }

        /// <summary>
        /// If sort is success, make it green.
        /// </summary>
        public void SuccessSort()
        {
            for (int i = 0; i < NumEntires; i++)
            {
                graph.FillRectangle(new SolidBrush(Color.Green), i, MaxHeight - Array[i], 2, MaxHeight);
            }
        }

        /// <summary>
        /// Start sort Btn click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startSort_Click(object sender, EventArgs e)
        {
            if (graph != null)
            {
                ISortEngine sortEngine = new BubbleSort(Array, graph, MaxHeight);
                sortEngine.Process();
                SuccessSort();
            }
        }
    }
}
