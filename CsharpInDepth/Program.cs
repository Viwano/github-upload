using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace CsharpInDepth
{
    static class Program
    {
        static void Main(string[] args)
        {
            //var a = new[] { 1, 1.1 };
            //var b = new Dictionary<string, int>
            //{
            //    {"ali",1 },
            //    {"vahid",2 },
            //    {"masoud",3 }
            //};
            //var player = new { name = "vahid", score = 100 };
            //player = new { name = "vahid", score = 80 };

            //Action<string> action = m => Console.WriteLine("your message is {0}", m);

            //Func<int, int, int> multipy = (int x, int y) => { return x * y; };
            //Func<int, int, int> multi = (x, y) => { return x * y; };
            //Func<int, int, int> mult = (x, y) => x * y;

            //Func<string, int> lengthMultiply = (string message) =>
            //{
            //     int len = message.Length;
            //     return len * len;
            //};

            //captured vars
            //Foo();

            //extension methods
            //var ab = 10.sqaure();

            //query expressions 
            //var dataSource = new string[] { "ali", "hassan", "taghi", "gholi" };
            //IEnumerable<string> query = from name in dataSource
            //                            let length = name.Length
            //                            where length > 3
            //                            orderby length
            //                            select string.Format($"{length} : {name.ToUpper()}");

            //dynamic types
            //dynamicIntro(new int[] { 1,2,3});
            //dynamic example = new simpleDynamicExample();
            //example.callSomeMothod("X",10);
            //Console.WriteLine(example.SomeProperty);

            foreach (var item in Fibbonucci())
            {
                if (item > 10000)
                {
                    break;
                }
                Console.WriteLine(item);

#pragma warning disable 0219
                int a = 1;
#pragma warning restore 0219
                int b = 2;
            }
        }

        public static void Foo()
        {
            var actions = new List<Action>();
            for (int i = 0; i < 10; i++)
            {
                actions.Add(() => Console.WriteLine(i));
            }
            //foreach (var a in actions)
            //{
            //    a();
            //}

            actions.ForEach(a => a());
        }
        public static int sqaure(this int de)
        {
            return de * de;
        }
        public static void dynamicIntro(dynamic d)
        {
            Console.WriteLine(d+d);
        }
        static IEnumerable<int> Fibbonucci()
        {
            int current = 0;
            int next = 1;

            while (true)
            {
                yield return current;
                int oldCurrent = current;
                current = next;
                next = next + oldCurrent;
            }
        }
    }

    class simpleDynamicExample : DynamicObject {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.WriteLine("invoked: {0} ({1})",
                binder.Name, string.Join(",",args));
            result = null;
            return true;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = "fetched:" + binder.Name;
            return true;
        }
    }
}
