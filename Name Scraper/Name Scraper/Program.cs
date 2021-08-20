using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Name_Scraper
{
    class Program
    {
        static string RandomString(int size)
        {
            Fare.Xeger xeger = new Fare.Xeger(@"[\a\b\c\d\e\f\g\h\i\j\k\l\m\n\o\p\q\r\s\t\u\v\w\x\y\z\1\2\3\4\5\6\7\8\9\0]{"  + size.ToString() + "}", new Random(Environment.TickCount));
            return xeger.Generate();
        }

        public static List<string> used = new List<string>();
        public static int size, threads, total, bad, good;
        static async void Entry()
        {
            for (;;)
            {
                z:
                Console.Title = "Name Scraper [Total: " + total + " | Good: " + good + " | Bad: " + bad + "]";
                string generated = RandomString(size);
                try
                {
                    using (var client = new HttpClient())
                    {
                        var response = client.GetAsync("https://api.roblox.com/users/get-by-username?username=" + generated);
                        string j = await response.Result.Content.ReadAsStringAsync();
                        if (!used.Contains(generated))
                        {
                            if (!j.Contains("User not found"))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    | -> [BAD NAME]: " + generated);
                                bad++;
                                total++;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("    | -> [GOOD NAME]: " + generated);
                                File.AppendAllText("usernames.txt", generated + "\n");
                                good++;
                                total++;
                            }
                            used.Add(generated);
                        }
                    }
                } catch (Exception e) {
                    goto z;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n    | ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Desired Name Length? -> ");
            size = Int32.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("    | ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("How many Threads? -> ");
            threads = Int32.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            //Threads for more POWEEERRRR (jeremy fragrance reference)
            for (int k = 0; k < threads; k++)
            {
                new Thread(Entry).Start();
            }
        }
    }
}
