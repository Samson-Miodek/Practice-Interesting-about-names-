using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name),
                GetDayNumbers(),
                GetFertilityRate(names, name));
        }

        private static double[] GetFertilityRate(NameData[] names, string name)
        {
            var fertilityRate = new double[31];
            foreach (var data in names)
                if (data.Name.ToLower() == name.ToLower() && data.BirthDate.Day != 1)
                    fertilityRate[data.BirthDate.Day - 1]++;
            return fertilityRate;
        }

        private static string[] GetDayNumbers()
        {
            var dayNumbers = new string[31];
            for (int i = 0; i < 31; i++)
                dayNumbers[i] = (i + 1).ToString();
            return dayNumbers;
        }
    }
}