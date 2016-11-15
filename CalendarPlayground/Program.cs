using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarPlayground
{
    class Program
    {

        static void Main(string[] args)
        {
            // Get todays date
            DateTime today = DateTime.Now;

            // Get first day of month
            var firstdayOfMonth = (new DateTime(today.Year, today.Month, 1)).DayOfWeek;

            // Get length of month to work out calendar spec
            var lenghOfMonth = DateTime.DaysInMonth(today.Year, today.Month);

            // Get start of omnth index to add to lenght
            String[] DaysOWeek = new String[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            // If month starts on a tuesday
            var monthIndex = DaysOWeek.ToList<string>().IndexOf(firstdayOfMonth.ToString());

            // days to display (including days before 1st)
            var daysToDisplay = lenghOfMonth + monthIndex;

            // Days o week
            const int coloumns = 7;

            // Rows, worked out from number of days to display
            var rows = Math.Ceiling((daysToDisplay / 7.0));

            // DataTime Array of required length
            DateTime[] dateCells = new DateTime[coloumns * (int)rows];

            // To ensure days start from the 1st of the month
            int dayCounter = 1;

            DateTime[] week = new DateTime[7];
            DateTime[][] month = new DateTime[(int)rows][];

            for (int i = 0; i < month.Count(); i++)
            {
                for (int j = monthIndex; j < week.Count(); j++)
                {
                    week[j] = new DateTime(today.Year, today.Month, dayCounter);
                    dayCounter++;
                    if (dayCounter > lenghOfMonth)
                    {
                        // Break when end of the month is reached
                        break;
                    }
                }
                // Add week to month
                month[i] = week;
                // Reset Month Index adn Week
                monthIndex = 0;
                week = new DateTime[7];
            }

            Console.ReadKey();
        }
    }
}
