using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.DataModifier
{
    public class DataModifier
    {
        public int Days { get; set; }
        public int Months { get; set; }
        public int  Year { get; set; }

        public DataModifier(int days, int months, int year)
        {
            Days = days;
            Months = months;
            Year = year;
        }

        public string DaysBetweenDates(DataModifier firstDate, DataModifier secondDate)
        {
            DateTime firstDateTime = new System.DateTime(firstDate.Year, firstDate.Months, firstDate.Days);
            DateTime secondDateTime = new System.DateTime(secondDate.Year, secondDate.Months, secondDate.Days);

            return (secondDateTime - firstDateTime).TotalDays.ToString();
        }
    }
}
