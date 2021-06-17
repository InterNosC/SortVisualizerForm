using SortVisualizerForm.Algoritms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
        private Graphics graph { get; set; } = null;

        /// <summary>
        /// Our Thread to work on background.
        /// </summary>
        private BackgroundWorker BackgroundWorkerElem { get; set; } = null;

        /// <summary>
        /// Our flag for pause.
        /// </summary>
        private bool isPaused { get; set; } = false;

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
            PopulateDeopdawn();
            this.Text = "SortDesktop";
        }

        /// <summary>
        /// Populate our combobox with classes that implements ISorEngine.
        /// </summary>
        private void PopulateDeopdawn()
        {
            List<string> ClassList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISortEngine).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.Name).ToList();
            ClassList.Sort();
            foreach (string entry in ClassList)
            {
                selectAlg.Items.Add(entry);
            }
            selectAlg.SelectedIndex = 0;
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
                BackgroundWorkerElem = new BackgroundWorker();
                BackgroundWorkerElem.WorkerSupportsCancellation = true;
                BackgroundWorkerElem.DoWork += new DoWorkEventHandler(BGW_DoWork);
                BackgroundWorkerElem.RunWorkerAsync(argument: selectAlg.SelectedItem);
            }
        }

        /// <summary>
        /// Pause or Resume button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PR_btn_Click(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                BackgroundWorkerElem.CancelAsync();
                isPaused = true;
            }
            else
            {
                isPaused = false;
                for (int i = 0; i < NumEntires; i++)
                {
                    graph.FillRectangle(new SolidBrush(Color.Black), i, 0, 1, MaxHeight);
                    graph.FillRectangle(new SolidBrush(Color.White), i, MaxHeight - Array[i], 1, MaxHeight);
                }
                BackgroundWorkerElem.RunWorkerAsync(argument: selectAlg.SelectedItem);
            }
        }

        /// <summary>
        /// Our event for BackgroundWorkerElem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BGW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string SortEngineName = (string)e.Argument;
            Type type = Type.GetType("SortVisualizerForm.Algoritms." + SortEngineName);
            var ctors = type.GetConstructors();
            try
            {
                ISortEngine sortEngine = (ISortEngine)ctors[0].Invoke(new object[] { Array, graph, MaxHeight });
                while (!sortEngine.checkSort() && (!BackgroundWorkerElem.CancellationPending))
                {
                    sortEngine.NexStepInAlg();
                }
                if (sortEngine.checkSort()) SuccessSort();
            }
            catch (Exception ex)
            {
            }
        }

        
    }
}
