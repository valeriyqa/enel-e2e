using System;
using System.Collections.Generic;

namespace TestAutomationFramework.Tools
{
    class HeatMap
    {
        public static List<int> getRandomForHeatMap(int quantity = 96, int maxValue = 3)
        {
            List<int> list = new List<int>();
            Random random = new Random();
            int myValue;

            for (int i = 0; i < quantity; i++)
            {
                //By default ee use range from -200 to 3000
                myValue = random.Next(-200, maxValue * 1000);

                list.Add(myValue);
            }

            return list;
        }

        public static List<string> getExpectedResultHeatMap(List<int> intHeatmap)
        {
            List<string> list = new List<string>();
            foreach (var item in intHeatmap)
            {
                if (item < -1)
                {
                    list.Add(string.Empty);
                }
                else if (item == -1)
                {
                    list.Add("0");
                }
                else
                {
                    float temp = (float)item/1000;
                    list.Add(temp.ToString("0.00"));
                }
            }

            return list;
        }

        //use "Pacific Standard Time" as example
        public static TimeSpan getOffsetToUtc(string timeZoneString)
        {
            var currentDateInUtc = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneString);
            var dateInTimeZone = TimeZoneInfo.ConvertTimeFromUtc(currentDateInUtc, timeZone);
            return dateInTimeZone.TimeOfDay - currentDateInUtc.TimeOfDay;
        }

    }
}
