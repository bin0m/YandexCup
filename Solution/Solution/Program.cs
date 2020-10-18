using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    public class Solution
    {
        static void Solve()
        {
            int n = ReadInt();
            int x = ReadInt();
            int k = ReadInt();

            int[] arr = ReadIntArr();

            var startTimes = new int[x];
            for (int i = 0; i < x; i++)
            {
                startTimes[i] = int.MaxValue;
            }
            for (int i = 0; i < n; i++)
            {
                if (arr[i] < startTimes[arr[i] % x])
                {
                    startTimes[arr[i] % x] = arr[i];
                }
            }
            var startsList = new List<int>();
            for (int i = 0; i < x; i++)
            {
                if (startTimes[i] < int.MaxValue)
                {
                    startsList.Add(startTimes[i]);
                }
            }

            int from = 0;
            int to = int.MaxValue;
            int mid = 0;

            while (from <= to)
            {
                mid = (from + to) / 2;
                int sum = 0;
                foreach (int start in startsList)
                {
                    sum += (mid - start + x) / x;
                }
                if (sum == k)
                {
                    Console.WriteLine(mid);
                    return;
                }
                if (sum < k)
                {
                    from = mid + 1;
                }
                else
                {
                    to = mid - 1;
                }
            }

            Console.WriteLine(mid);

            //
            Console.ReadLine();
        }

        static IEnumerable<string> _tokens;
        static IEnumerator<string> _tokenEnumarator;

        static int ReadInt()
        {
            return int.Parse(ReadNextToken());
        }

        static long ReadLong()
        {
            return long.Parse(ReadNextToken());
        }

        static string ReadString()
        {
            return ReadNextToken();
        }

        static char ReadChar()
        {
            return char.Parse(ReadNextToken());
        }

        static int[] ReadIntArr()
        {
            string s = Console.ReadLine().Trim();
            int[] a = (from v in s.Split(' ') select int.Parse(v)).ToArray();
            return a;
        }

        static long[] ReadLongArr()
        {
            string s = Console.ReadLine().Trim();
            long[] a = (from v in s.Split(' ') select long.Parse(v)).ToArray();
            return a;
        }

        static string ReadNextToken()
        {
            while (_tokens == null || _tokenEnumarator?.Current == null)
            {
                _tokens = Console.ReadLine().Trim().Split(' ');
                _tokenEnumarator = _tokens.GetEnumerator();
                _tokenEnumarator.MoveNext();
            }
            string token = _tokenEnumarator.Current;
            if (!_tokenEnumarator.MoveNext())
            {
                _tokenEnumarator.Dispose();
                _tokenEnumarator = null;
            }
            return token;
        }


        static void Main(string[] args)
        {
            Solve();

            //Console.ReadLine();
        }
    }
}
