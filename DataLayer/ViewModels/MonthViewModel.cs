using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels
{
    public class MonthViewModel
    {
        public static List<Month> GetAllMonth()
        {
            List<Month> months = new List<Month>();

            months.Add(new Month() { Id = 1, Name = "الشهر الأول" });
            months.Add(new Month() { Id = 2, Name = "الشهر الثاني" });
            months.Add(new Month() { Id = 3, Name = "الشهر الثالث" });
            months.Add(new Month() { Id = 4, Name = "الشهر الرابع" });
            months.Add(new Month() { Id = 5, Name = "الشهر الخامس" });
            months.Add(new Month() { Id = 6, Name = "الشهر السادس" });
            months.Add(new Month() { Id = 7, Name = "الشهر السابع" });
            months.Add(new Month() { Id = 8, Name = "الشهر الثامن" });
            months.Add(new Month() { Id = 9, Name = "الشهر التاسع" });
            months.Add(new Month() { Id = 10, Name = "الشهر العاشر" });
            months.Add(new Month() { Id = 11, Name = "الشهر الحادي عشر" });
            months.Add(new Month() { Id = 12, Name = "الشهر الثاني عشر" });

            return months;
        }
    }
    public class Month
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
