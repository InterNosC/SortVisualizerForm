using NUnit.Framework;
using SortVisualizerForm.Algoritms;
using System.Linq;

namespace SortVisualizerForm.Tests
{
    [TestFixture]
    public class TestSort
    {
        [Test]
        public void checkSort_sortedArr_isTrue()
        {
            var bubbleSort = new BubbleSort(new int[5] { 1, 2, 3, 4, 5 }, null, 10);

            Assert.That(bubbleSort.checkSort() == true);
        }

        [Test]
        public void checkSort_unsortedArr_isFalse()
        {
            var bubbleSort = new BubbleSort(new int[5] { 1, 2, 8, 4, 5 }, null, 10);

            Assert.That(bubbleSort.checkSort() == false);
        }

        [Test]
        public void BubbleSorting_sortingUnSortedArray_isTrue()
        {
            var bubbleSort = new BubbleSort(new int[5] { 1, 2, 8, 4, 5 }, null, 10);
            var sortedArr = new int[5] { 1, 2, 4, 5, 8 };

            bubbleSort.BubbleSorting();        
            Assert.That(sortedArr.SequenceEqual(bubbleSort.Array));
        }

        [Test]
        public void SelectionSorting_sortingUnSortedArray_isTrue()
        {
            var selectionSort = new SelectionSort(new int[5] { 1, 2, 8, 4, 5 }, null, 10);
            var sortedArr = new int[5] { 1, 2, 4, 5, 8 };

            selectionSort.Process();
            Assert.That(sortedArr.SequenceEqual(selectionSort.Array));
        }

        [Test]
        public void MergeSorting_sortingUnSortedArray_isTrue()
        {
            var mergeSort = new BubbleSort(new int[5] { 1, 2, 8, 4, 5 }, null, 10);
            var sortedArr = new int[5] { 1, 2, 4, 5, 8 };

            mergeSort.Process();
            Assert.That(sortedArr.SequenceEqual(mergeSort.Array));
        }
    }
}
