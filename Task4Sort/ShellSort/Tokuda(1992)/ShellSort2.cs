using System;

namespace Task4Sort
{
    class ShellSort2 : ShellSort
    {
        public ShellSort2(int[] array) : base(array) { }
        private double[] originalOffsets = new double[] { 1, 4, 9, 20, 46, 103, 233, 525, 1182, 2660, 5985, 13467, 30301, 68178, 153401,
                                   345152, 776591, 1747331, 3931496, 8845866, 19903198, 44782196, 100759940, 226709866,
                                   510097200, 1147718700, 2582367076, 5810325920, 13073233321, 29414774973};
        public void Sort()
        {
            for (int i = originalOffsets.Length - 1; i >= 0; i--)
            {
                if (originalOffsets[i] < array.Length)
                    insertionSort((int)originalOffsets[i]);
            }
        }
    }
}
