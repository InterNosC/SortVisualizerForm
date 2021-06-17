using System.Drawing;

namespace SortVisualizerForm.Algoritms
{
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
            for (int i = 0; i < Array.Length - 1; i++)
            {
                int min = FindMin(Array, i);
                int temp = Array[i];
                Array[i] = Array[min];
                DrawBar(i, Array[min]);
                System.Threading.Thread.Sleep(5);
                Array[min] = temp;
                DrawBar(min, temp);
                System.Threading.Thread.Sleep(5);
            }
        }

        /// <summary>
        /// Draw our cells.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="height"></param>
        private void DrawBar(int position, int height)
        {

            Graph.FillRectangle(BlackBrush, position, 0, 1, MaxHeight);
            Graph.FillRectangle(WhiteBrush, position, MaxHeight - Array[position], 2, MaxHeight);
            Graph.FillRectangle(WhiteBrush, position, MaxHeight - Array[position], 2, MaxHeight);
        }


        /// <summary>
        /// Find minimum for our sort.
        /// </summary>
        /// <param name="mainArray"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        private int FindMin(int[] arr, int num)
        {
            int retloc = num;
            int voi = arr[num];
            for (int i = num + 1; i < arr.Length - 1; i++)
            {
                if (arr[i] < voi)
                {
                    retloc = i;
                    voi = arr[i];
                }
                
            }
            return retloc;
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
