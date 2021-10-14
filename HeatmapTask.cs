using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            return new HeatmapData(
                "Пример карты интенсивностей",
                GetFertilityDayMonth(names),
                GetData(30, 2),
                GetData(12, 1));
        }

        private static double[,] GetFertilityDayMonth(NameData[] names)
        {
            var fertilityDayMonth = new double[30, 12];
            foreach (var data in names)
                if (data.BirthDate.Day != 1)
                    fertilityDayMonth[data.BirthDate.Day - 2, data.BirthDate.Month - 1]++;
            return fertilityDayMonth;
        }

        private static string[] GetData(int n, int x)
        {
            var data = new string[n];
            for (int i = 0; i < n; i++)
                data[i] = (i + x).ToString();
            return data;
        }
    }
}