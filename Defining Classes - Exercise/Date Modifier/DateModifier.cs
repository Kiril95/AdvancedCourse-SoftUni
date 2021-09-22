using System;

namespace DefiningClasses
{
    public class DateModifier
    {
        private DateTime date1;
        private DateTime date2;

        public static double DifferenceBetweenTwoDates(DateTime date1, DateTime date2)
        {
            return Math.Abs((date2 - date1).TotalDays);
        }
    }
}
