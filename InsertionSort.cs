//This program is an implementation of the Insertion Sort Algorithm.  It generates a list of random numbers and sorts the list 
//with Insertion Sort and the .Net List Sort function, comparing the two.  

//Created by Joseph Mumford 10/18/2017.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertionSort Test = new InsertionSort();

            Test.Run();     
        }
    }

    public class InsertionSort
    {
        public List<int> ListA = new List<int>();       //List to be sorted by test algorithm
        public List<int> ListB = new List<int>();       //List to be sorted by standard List.Sort()
        public Random RandomGenerator;

        public void Run()
        {
            Initialize();
            GenerateLists();

            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            ListA = Sort(ListA);
            Timer.Stop();

            Stopwatch Timer1 = new Stopwatch();
            Timer1.Start();
            ListB.Sort();
            Timer1.Stop();

            Console.WriteLine("Insertion Sort Time: {0}", Timer.Elapsed);
            Console.WriteLine("List Sort Time: {0}", Timer1.Elapsed);
            string comparison = "";
            if (Timer.Elapsed < Timer1.Elapsed)
            {
                comparison = "faster";
            }
            else
            {
                comparison = "slower";
            }
            Console.WriteLine("Insertion Sort is {0} {1} than List Sort", Timer.Elapsed - Timer1.Elapsed, comparison);

            Console.ReadKey();
        }

        /// <summary>
        /// Populate list with random numbers
        /// </summary>
        public void GenerateLists()
        {
            for (int i = 0; i < 10000; i++)
            {
                ListA.Add(RandomGenerator.Next(int.MaxValue));
            }
        }

        /// <summary>
        /// Create list, generate random numbers, and set comparison list to initial list
        /// </summary>
        public void Initialize()
        {
            ListA = new List<int>();
            RandomGenerator = new Random();
            ListB = ListA;
        }

        /// <summary>
        /// Sort "list" with Insertion Sort Algorithm
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<int> Sort(List<int> list)
        {
            for(int i = 0; i < list.Count - 1; i++)
            {
                for(int j = i + 1; j > 0; j--)
                {
                    //Check to see if the prior element is greater than the current element, if so, swap elements
                    if (list[j - 1] > list[j])
                    {
                        int t = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = t;
                    }
                }
            }
            return list;
        }
    }
}
