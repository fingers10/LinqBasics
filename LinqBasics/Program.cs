using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linq Basics");

            // Generating
            var input = "1,2-3,4,5,6-10";
            // output -> 1,2,3,4,5,6,7,8,9,10
            var numbers = input.Split(",")
                 .Select(x => new { First = int.Parse(x.Split("-").First()), Last = int.Parse(x.Split("-").Last()) });

            var range = Enumerable.Range(1, 100).ToList();

            var repeat = Enumerable.Repeat(1, 5).ToList();

            var defaultEmpty = Enumerable.DefaultIfEmpty(range);

            var emptyEnumerable = Enumerable.Empty<int>();

            // Basics
            var select = input.Split(",")
                              .Select(x => new { First = int.Parse(x.Split("-").First()), Last = int.Parse(x.Split("-").Last()) });

            var deferredExecution = select.ToList();

            var nestedList = select.Select(x => Enumerable.Range(x.First, x.Last).ToList()).ToList();

            // flatten any collection
            var selectMany = nestedList.SelectMany(x => x)
                                        .Distinct()
                                        .OrderByDescending(x => x)
                                        .ToList();

            // Filtering
            var where = selectMany.Where(x => x > 5).ToList();

            // Aggregation
            var sum = selectMany.Sum();
            var average = selectMany.Average();
            var aggregate = selectMany.Aggregate((x1, x2) => x1 + x2);
            var max = selectMany.Max();
            var min = selectMany.Min();

            // Groups
            var group = select.GroupBy(x => x.First).ToList();
            foreach (var item in group)
            {
                Console.WriteLine(item);
            }

            // Element Operations
            var first = selectMany.First();
            var firstOrDefault = selectMany.FirstOrDefault();
            var last = selectMany.Last();
            var lastOrDefault = selectMany.LastOrDefault();
            //var single = selectMany.Single();
            //var singleOrDefault = selectMany.SingleOrDefault();

            // Set Operations
            var distinct = selectMany.Distinct();
            var intersection = new List<int> { 1, 2, 3 }.Intersect(new List<int> { 3, 4, 5 });
            var union = new List<int> { 1, 2, 3 }.Union(new List<int> { 3, 4, 5 });
            var except = new List<int> { 1, 2, 3 }.Except(new List<int> { 3, 4, 5 });

            // Quantify Data
            var any = select.Any(x => x.First > 0);
            var all = select.All(x => x.First > 0);
            var contains = selectMany.Contains(4);
            var count = selectMany.Count();

            // Partition
            var skip = selectMany.Skip(3);
            var take = selectMany.Take(5);

            // Combine
            var zip = Enumerable.Range(1, 8).Zip(Enumerable.Range('a', 8));

            // MoreLinq for additional extensions

            Console.ReadKey();
        }
    }
}
