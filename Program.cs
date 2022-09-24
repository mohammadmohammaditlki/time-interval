using System;

namespace Date_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Date mohammad = new Date("mohammad ", 1374, 13, 250);
            string[] First_Member = Get_Input();      //[NAME][YEAR][MOUNTH][DAY]
            string[] Second_Member = Get_Input();
            Date First_M = new Date(First_Member[0], Int32.Parse(First_Member[1]), Int32.Parse(First_Member[2])
                                    , Int32.Parse(First_Member[3]));
            Date Second_M = new Date(Second_Member[0], Int32.Parse(Second_Member[1]), Int32.Parse(Second_Member[2])
                                    , Int32.Parse(Second_Member[3]));
            Console.WriteLine($"Between is {Date.Between(First_M, Second_M)}");
        }
        //MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM//
        static string[] Get_Input()
        {
            string[] Detail;
            string input;
            Console.WriteLine("Please enter your name & Date in name-year-mounth-day format:");
            Boolean Correct_input = true;
            do
            {
                Correct_input = true;
                input = Console.ReadLine();
                Detail = input.Split('-');    //Detail[0] = name  Detail[1] = year  Detail[2] = mounth  Detail[3]=day
                if (!Filter(Detail))
                {
                    Correct_input = false;
                    System.Console.WriteLine("please enter again");
                }
            } while (!Correct_input);
            return Detail;
        }
        //MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM//
        static Boolean Filter(string[] Detail)             //return false if date was wrong
        {
            if (Detail.Length != 4) { Console.WriteLine("Data_Lenght is wrong"); return false; }
            for (int i = 1; i < Detail.Length; i++)
            {
                if (Detail[i] == null || Detail[i] == "") { System.Console.WriteLine("null input"); ; return false; }
                foreach (char c in Detail[i])
                {
                    if (c < '0' || c > '9')             //13m4 --> char[0] = 1   char[1] = 3  char[2] = m   char[3]=4   return False;
                    {
                        System.Console.WriteLine("character is wrong");
                        return false;
                    }
                }
            }
            if (!Date_Logic(Detail))
            {
                System.Console.WriteLine("logic is wrong");
                return false;
            }
            return true;
        }
        //MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM//
        static Boolean Date_Logic(string[] Dates)    //Return True If Date Was Ok
        {
            int year = Int32.Parse(Dates[1]);
            int mounth = Int32.Parse(Dates[2]);
            int day = Int32.Parse(Dates[3]);

            if (day > 31 || day < 1) return false;
            if (mounth > 12 || mounth < 1) return false;
            if (mounth > 6 && day > 30) return false;
            if ((Date.Leap_Year(year)) && day > 30 && mounth == 12) return false;
            if (!(Date.Leap_Year(year)) && day > 29 && mounth == 12) return false;
            return true;
        }
        //MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM//
    }
}

