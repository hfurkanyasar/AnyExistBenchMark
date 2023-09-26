using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using static AnyExistBenchMark.TextClass;
namespace AnyExistBenchMark
{
    public class Program
    {
        public List<string> list = new List<string>();
        public string searchItem = string.Empty;

        public Program()
        {
            FillGuidList(ref list);
        }

        [Benchmark]
        public bool TextAny()
        {
            return list.Any(a => a == searchItem);
        }

        [Benchmark]
        public bool TextExist()
        {
            return list.Exists(a => a == searchItem);
        }

        public static void Main(string[] args)
        {
            
            var summary = BenchmarkRunner.Run<Program>();
            Console.ReadKey();
        }

        public void FillGuidList(ref List<string> list)
        {
            for (int i = 0; i < 10000; i++)
            {
                var item = Guid.NewGuid().ToString();
                list.Add(item);
                if (i == 5000) { Console.WriteLine(item); searchItem = item; }
            }
        }
    }
}