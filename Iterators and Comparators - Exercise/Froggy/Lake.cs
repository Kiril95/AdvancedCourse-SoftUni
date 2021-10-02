using System;
using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        public List<int> Stones { get; set; }

        public Lake(int[] values)
        {
            Stones = new List<int>(values);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int j = 0; j < Stones.Count; j++)
            {
                if (j % 2 == 0)
                {
                    yield return Stones[j];
                }
            }

            for (int i = Stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return Stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
