using System.Drawing;

namespace SortVisualizerForm.Algoritms
{
    /// <summary>
    /// Selection sort.
    /// </summary>
    class SelectionSort : ISortEngine
    {
        /// <summary>
        /// Color white for cells.
        /// </summary>
        private Brush WhiteBrush = new SolidBrush(Color.White);

        /// <summary>
        /// Color black.
        /// </summary>
        private Brush BlackBrush = new SolidBrush(Color.Black);

        /// <summary>
        /// Check if our array is sorted.
        /// </summary>
        private bool isSorted { get; set; } = false;

        /// <summary>
        /// Our array.
        /// </summary>
        public int[] Array { get; private set; }

        /// <summary>
        /// Maximum height that cells can be.
        /// </summary>
        private int MaxHeight { get; set; }

        /// <summary>
        /// Display.
        /// </summary>
        private Graphics Graph { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Array"></param>
        /// <param name="graph"></param>
        /// <param name="maxHeight"></param>
        public SelectionSort(int[] Array, Graphics graph, int maxHeight)
        {
            this.Array = Array;
            this.Graph = graph;
            this.MaxHeight = maxHeight;
        }

        /// <summary>
        /// Check our array, if it could be sorted.
        /// </summary>
        /// <returns></returns>
        public bool checkSort()
        {
            for (int i = 0; i < Array.Length - 1; i++)
            {
                if (Array[i] > Array[i + 1]) return false;
            }
            return true;
        }

        /// <summary>
        /// One step for our algorithm
        /// </summary>
        public void NexStepInAlg()
        {
            for (int i = 0, smallest = 0; i < Array.Length - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < Array.Length; j++)
                {
                    if (Array[j] < Array[smallest])
                    {
                        smallest = j;
                    }
                }
                var temp = Array[smallest];
                Array[smallest] = Array[i];
                Array[i] = temp;

                if (Graph != null) DrawOnDisplayElements(smallest, i);
            }
        }

        /// <summary>
        /// Draw our proccess on display.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="v"></param>
        private void DrawOnDisplayElements(int i, int v)
        {
            Graph.FillRectangle(BlackBrush, i, 0, 2, MaxHeight);
            Graph.FillRectangle(BlackBrush, v, 0, 2, MaxHeight);

            Graph.FillRectangle(WhiteBrush, i, MaxHeight - Array[i], 2, MaxHeight);
            Graph.FillRectangle(WhiteBrush, v, MaxHeight - Array[v], 2, MaxHeight);
        }


        /// <summary>
        /// Selection Sort algorithm.
        /// </summary>
        public void Process()
        {
            while (!isSorted)
            {
                NexStepInAlg();
                isSorted = checkSort();
            }
        }
    }
}
