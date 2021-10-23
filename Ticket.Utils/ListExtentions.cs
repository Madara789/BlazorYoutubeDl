using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorYoutubeDl.Utils
{
    public static class ListExtentions
    {
        public static IList<T[]> GroupArray<T>(this T[] array, int groupSize)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (groupSize <= 0)
                throw new ArgumentException("Group size must be greater than 0.", "groupSize");

            IList<T[]> list = new List<T[]>();

            T[] temp = new T[groupSize];

            for (int i = 0; i < array.Length; i++)
            {
                if ((i % groupSize) == 0)
                {
                    temp = new T[groupSize];
                    list.Add(temp);
                }

                temp[(i % groupSize)] = array[i];
            }

            return list;
        }
    }
}
