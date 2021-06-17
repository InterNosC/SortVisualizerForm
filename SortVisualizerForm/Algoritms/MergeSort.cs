using System;
using System.Drawing;

namespace SortVisualizerForm.Algoritms
{
    /// <summary>
    /// Merge sort.
    /// </summary>
    class MergeSort : ISortEngine
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
        public MergeSort(int[] Array, Graphics graph, int maxHeight)
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
        private void DrawBar(int position, int height)
        {
            Graph.FillRectangle(BlackBrush, position, 0, 1, MaxHeight);
            Graph.FillRectangle(WhiteBrush, position, MaxHeight - Array[position], 1, MaxHeight);
        }

        /// <summary>
        /// One step for our algorithm
        /// </summary>
        public void NexStepInAlg()
        {
            mergeSort(Array, 0, Array.Length - 1);
        }

        /// <summary>
        /// Merge sort algorithm
        /// </summary>
        /// <param name="Array"></param>
        /// <param name="lower"></param>
        /// <param name="higher"></param>
        private void mergeSort(int[] Array, int lower, int higher)
        {
            if (lower < higher)
            {
                int middle = (lower + higher) / 2;

                mergeSort(Array, lower, middle);
                mergeSort(Array, middle + 1, higher);

                Merge(Array, lower, middle, higher);
            }
        }
    
        /// <summary>
        /// Body merger sort;
        /// </summary>
        /// <param name="Array"></param>
        /// <param name="lo"></param>
        /// <param name="middle"></param>
        /// <param name="higher"></param>
        private void Merge(int[] Array, int lower, int middle, int higher)
        {
            int[] leftArray = new int[middle - lower + 1];
            int[] rightArray = new int[higher - middle];


            System.Array.Copy(Array, lower, leftArray, 0, middle - lower + 1);
            System.Array.Copy(Array, middle + 1, rightArray, 0, higher - middle);

            int i = 0;
            int j = 0;
            for (int k = lower; k < higher + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    Array[k] = rightArray[j];
                    if (Graph != null)  DrawBar(k, Array[k]);
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    Array[k] = leftArray[i];
                    if (Graph != null)  DrawBar(k, Array[k]);
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    Array[k] = leftArray[i];
                    if (Graph != null)  DrawBar(k, Array[k]);
                    i++;
                }
                else
                {
                    Array[k] = rightArray[j];
                    if (Graph != null)  DrawBar(k, Array[k]);               
                    j++;
                }
            }
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
