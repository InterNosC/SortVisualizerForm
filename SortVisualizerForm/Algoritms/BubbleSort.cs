using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizerForm.Algoritms
{
    /// <summary>
    /// Bubble sort.
    /// </summary>
    public class BubbleSort : ISortEngine
    {
        /// <summary>
        /// Color white for cells.
        /// </summary>
        private Brush WhiteBruch = new SolidBrush(Color.White);

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


        public BubbleSort(int[] Array, Graphics graph, int maxHeight)
        {
            this.Array = Array;
            this.Graph = graph;
            this.MaxHeight = maxHeight;
        }

        /// <summary>
        /// Init properties.
        /// </summary>
        /// <param name="Array"></param>
        /// <param name="graph"></param>
        /// <param name="maxHeight"></param>
        public void Process()
        {
            BubbleSorting();
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
        /// Bubble sort algorithm.
        /// </summary>
        public void BubbleSorting()
        {
            while (!isSorted)
            {
                for (int i = 0; i < Array.Length - 1; i++)
                {
                    if (Array[i] > Array[i + 1])
                    {
                        Swap(i, i + 1);
                        if (Graph != null) DrawOnDisplayElements(i, i + 1);
                    }
                }

                isSorted = checkSort();
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

            Graph.FillRectangle(WhiteBruch, i, MaxHeight - Array[i], 2, MaxHeight);
            Graph.FillRectangle(WhiteBruch, v, MaxHeight - Array[v], 2, MaxHeight);
        }

        /// <summary>
        /// Seap elements.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="v"></param>
        private void Swap(int i, int v)
        {
            var tmp = Array[i];
            Array[i] = Array[v];
            Array[v] = tmp;
        }


    }
}
