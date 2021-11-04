using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DnD_CM_WPF_Lib
{//also an outdated class, also set to be removed
    public class Util
    {
        public static int ModReturn(int score)
        {
            return score switch
            {
                1 => -5,
                2 => -4,
                3 => -4,
                4 => -3,
                5 => -3,
                6 => -2,
                7 => -2,
                8 => -1,
                9 => -1,
                10 => 0, 
                11 => 0,
                12 => 1,
                13 => 1,
                14=> 2,
                15 => 2,
                16 => 3, 
                17 => 3,
                18 => 4,
                19 => 4,
                20 => 5, 
                21 => 5,
                22 => 6, 
                23 => 6,
                24 => 7, 
                25 => 7,
                26 => 8, 
                27 => 8,
                28 => 9, 
                29 => 9,
                30 => 10,
                _ => 0,
            };
        }

        public static string ReturnAverage(string input)
        {
            input = Regex.Replace(input, @"\(|\)", "");
            string[] temp;
            double count = 0, dice = 0, bonus = 0;
            temp = input.Replace(" ", "").Split(new char[] { 'd', '+' });

            if (temp[0] != null)
            {
                count = int.Parse(temp[0]);
            }
            if (temp[1] != null)
            {
                dice = int.Parse(temp[1]);
            }
            if (temp.Length > 2)
            {
                if (temp[2] != null)
                {
                    bonus = int.Parse(temp[2]);
                }
            }
            

            double average = Math.Floor(count * ((dice + 1) / 2));
            average += bonus;
            return $"{average} ({input})";
        }

        public static Task Delay(double milliseconds)
        {
            var tcs = new TaskCompletionSource<bool>();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += (obj, args) =>
            {
                tcs.TrySetResult(true);
            };
            timer.Interval = milliseconds;
            timer.AutoReset = false;
            timer.Start();
            return tcs.Task;
        }
    }
}
