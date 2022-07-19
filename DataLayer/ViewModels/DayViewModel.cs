using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels
{
    public class DayViewModel
    {
        public static List<Day> GetAllDayInMont(int yearId, int monthId)
        {
            List<Day> days = new List<Day>();
            for (int i = 1; i <= DateTime.DaysInMonth(yearId, monthId); i++)
            {
                days.Add(new Day() { Id = i, Name = i.ToString() });
            }
            return days;
        }
    }
    public class Day
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
