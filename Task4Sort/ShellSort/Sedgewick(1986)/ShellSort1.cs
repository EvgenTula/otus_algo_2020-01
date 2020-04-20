using System;

namespace Task4Sort
{
    class ShellSort1 : ShellSort
    {
        public ShellSort1(int[] array) : base(array) { }

        private double[] originalOffsets = {1, 5, 19, 41, 109, 209, 505, 929, 2161, 3905, 8929, 16001, 36289, 64769, 146305,
                                   260609, 587521, 1045505, 2354689, 4188161, 9427969, 16764929, 37730305, 67084289,
                                   150958081, 268386305, 603906049, 1073643521, 2415771649, 4294770689};
        public override void sort()
        {
            for (int i = originalOffsets.Length - 1; i >= 0; i--)
            {
                if (originalOffsets[i] < array.Length)
                    insertionSort((int)originalOffsets[i]);
            }
        }
    }
}
