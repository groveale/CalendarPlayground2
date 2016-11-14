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
            var monthIndex = DaysOWeek.ToList<string>().IndexOf(firstdayOfMonth.ToString());

            // days to display (including days before 1st)
            var daysToDisplay = lenghOfMonth + monthIndex;

            // Days o week
            const int coloumns = 7;

            // Rows, worked out from number of days to display
            var rows = Math.Ceiling((daysToDisplay / 7.0));

            DateTime[] dateCells = new DateTime[coloumns * (int)rows];

            int dayCounter = 1;

            for (int i = monthIndex; i < daysToDisplay; i++ )
            {
                dateCells[i] = new DateTime(today.Year, today.Month, dayCounter);
                dayCounter++;
            }

            Console.ReadKey();
        }
    }
}
