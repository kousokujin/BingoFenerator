using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //タイトルとか表示
            System.Console.WriteLine("-------------------------------");
            System.Console.WriteLine("BingoGenerator");
            System.Console.WriteLine("version 1.0.0.0");
            System.Console.WriteLine("Copyright (c) 2017 Kousokujin.");
            System.Console.WriteLine("Released under the MIT license.");
            System.Console.WriteLine("-------------------------------");

            int[] num = new int[24];
            //int genloop = 0;
            //bool check = true;

            foreach (int i in num)
            {
                num[i] = 0;
            }


            for (int i = 0; i < 24; i++)
            {
                bool check = true;
                int n = genNumber(i);
                int genloop = 0;

                while(check == true)
                {
                    check = numCheck(n, num);
                    n = genNumber(i + genloop);
                }

                num[i] = n;

                //System.Console.WriteLine("gen:{0}", num[i]);
            }


            string bngStr = "";
            int loop = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 2 && j == 2)    //真ん中はFree
                    {
                        bngStr += string.Format("{0,4}","F");
                    }
                    else
                    {
                        //bngStr += num[loop].ToString();
                        bngStr += string.Format("{0,4}",num[loop]);
                        loop++;
                    }

                    bngStr += ' ';
                }

                bngStr += System.Environment.NewLine;
            }

            System.Console.WriteLine(bngStr);
            System.Console.WriteLine("終了するにはEnterキーを押してください。");
            System.Console.ReadLine();
        }

        static int genNumber(int seed)
        {
            int hour = System.DateTime.Now.Hour;
            int min = System.DateTime.Now.Minute;
            int sec = System.DateTime.Now.Second;
            int mll = System.DateTime.Now.Millisecond;

            Random r1 = new Random(mll * sec * min + seed);
            Random r2 = new Random((sec + hour) * mll + seed);
            Random r3 = new Random(mll + seed);

            int num1 = r1.Next(1, 7);
            int num2 = r2.Next(1, 7);
            int num3 = r3.Next(0, 2);

            string numStr = string.Format("{0}{1}{2}", num3, num2, num1);
            //System.Console.WriteLine("gen:{0}",numStr);

            return int.Parse(numStr);
        }

        static bool numCheck(int n, int[] num)
        {
            bool check = false;

            foreach (int i in num)
            {
                if (i == n)
                {
                    check = true;
                    break;
                }
            }

            return check;
        }
    }

}
