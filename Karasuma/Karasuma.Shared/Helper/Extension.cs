using System;
using System.Collections.Generic;
using System.Text;

namespace Karasuma.Helper
{
    public static class Extension
    {
        private static Random random = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public static class Combinations<T>
    {
        public static List<T[]> GetCombinations(List<T[]> sourceList)
        {
            List<T[]> resultList = new List<T[]>();
            Stack<T> stack = new Stack<T>();
            GetCombinationsCore(stack, resultList, sourceList);

            return resultList;
        }

        private static void GetCombinationsCore(Stack<T> stack, List<T[]> resultList, List<T[]> sourceList)
        {
            int dimension = stack.Count;
            if (sourceList.Count <= dimension)
            {
                T[] array = stack.ToArray();
                Array.Reverse(array);
                resultList.Add(array);
                return;
            }
            else
            {
                foreach (T item in sourceList[dimension])
                {
                    stack.Push(item);
                    GetCombinationsCore(stack, resultList, sourceList);
                    stack.Pop();
                }
            }
        }
    }
}
