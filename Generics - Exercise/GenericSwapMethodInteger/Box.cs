using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodInteger
{
    public class Box<T>
    {
        public Box(List<T> info)
        {
            Info = new List<T>(info);
        }
        public List<T> Info { get; set; }


        public void Swap(int idx1, int idx2)
        {
            (Info[idx1], Info[idx2]) = (Info[idx2], Info[idx1]);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in Info)
            {
                builder.AppendLine($"{item.GetType()}: {item}");
            }

            return builder.ToString().Trim();
        }
    }
}
