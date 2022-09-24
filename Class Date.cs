using System;
using System.Linq;

namespace Date_Class
{
    public class Date
    {
        private int Year;
        private int Day;
        private int Mounth;
        private string name;
        //MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM//
        public Date(string Personname, int PersonYear, int PersonMounth, int PersonDay)   //Public constructor 
        {
            name = Personname;
            Year = PersonYear;
            Mounth = PersonMounth;
            Day = PersonDay;
        }
        //---------------------------------------------------------------------------------------//
        private Date() { }           //Private Constructor
        //MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM// 
        static public int Between(Date First, Date Second)        
        {
            Date Old_Date = new Date();
            Date new_Date = new Date();
            int count = 0;

            if (First.Year > Second.Year) { Old_Date = (Date)Second.MemberwiseClone(); new_Date = (Date)First.MemberwiseClone(); }
            else if (First.Year < Second.Year) { Old_Date = (Date)First.MemberwiseClone(); new_Date = (Date)Second.MemberwiseClone(); }
            else if (First.Mounth > Second.Mounth) { Old_Date = (Date)Second.MemberwiseClone(); new_Date = (Date)First.MemberwiseClone(); }
            else if (First.Mounth < Second.Mounth) { Old_Date = (Date)First.MemberwiseClone(); new_Date = (Date)Second.MemberwiseClone(); }
            else if (First.Day > Second.Day) { Old_Date = (Date)Second.MemberwiseClone(); new_Date = (Date)First.MemberwiseClone(); }
            else if (First.Day < Second.Day) { Old_Date = (Date)First.MemberwiseClone(); new_Date = (Date)Second.MemberwiseClone(); }
            else return 0;

            do                                     //increase the old date to reach to the new date
            {
                increase_day(ref Old_Date);
                count++;
            } while (!equal(Old_Date, new_Date));  // return true if date's are equal 
            return count;
        }
        //MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM//
        static public Boolean Leap_Year(int year)   //return true if it's leap year
        {
            int r = year % 33;
            return r == 1 || r == 5 || r == 9 || r == 13 || r == 17 || r == 22 || r == 26 || r == 30;
        }
        //MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM//
        static private void increase_day(ref Date Date)  // increase 1 day to date
        {
            Date.Day++;
            if (Date.Day == 32)
            {
                Date.Day = 1;
                Date.Mounth++;
            }

            if (Date.Day >= 31 && Date.Mounth > 6)
            {
                Date.Day = 1;
                Date.Mounth++;
                if (Date.Mounth > 12) { Date.Mounth = 1; Date.Year++; }
            }

            else if (Date.Day >= 30 && Date.Mounth == 12)
            {
                if (!Leap_Year(Date.Year))
                {
                    Date.Day = 1;
                    Date.Mounth = 1;
                    Date.Year++;
                }
            }

        }
        //MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM//
        static private Boolean equal(Date First, Date Second)  //return true if Date's are equal
        {
            if (First.Day == Second.Day && First.Mounth == Second.Mounth && First.Year == Second.Year)
            {
                return true;
            }
            return false;
        }

    }
}