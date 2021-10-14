using System;

namespace Names
{
    internal static class CreativityTask
    {
        public static bool longOrShort = true;
        public static int minYear;
        public static int maxYear;

        public static HistogramData ShowYourStatistics(NameData[] names_data)
        {
            GetMaxAndMinYear(names_data);
            return new HistogramData(
                String.Format("Самое {0} имя по годам", longOrShort ? "длинное" : "короткое"), 
                GetNames(names_data), 
                GetNameLengths(names_data)
            );
        }

        private static double[] GetNameLengths(NameData[] names)
        {
            var nameLength = new double[maxYear - minYear + 1];
            foreach (var data in names)
            {
                var ind = data.BirthDate.Year - minYear;

                if (longOrShort)
                    nameLength[ind] = Math.Max(nameLength[ind], data.Name.Length);
                else
                {
                    if (nameLength[ind] == 0)
                        nameLength[ind] = data.Name.Length;
                    else
                        nameLength[ind] = Math.Min(nameLength[ind], data.Name.Length);
                }
            }
            return nameLength;
        }
        private static string[] GetNames(NameData[] names)
        {
            var x_names = new string[maxYear - minYear + 1];
            foreach (var data in names)
            {
                var ind = data.BirthDate.Year - minYear;

                var name1 = data.Name;
                var name2 = x_names[ind];

                if (name2 == null)
                    name2 = name1;

                if(longOrShort)
                    x_names[ind] = name1.Length > name2.Length ? name1 : name2;
                else
                    x_names[ind] = name1.Length < name2.Length ? name1 : name2;

            }

            for (int i = 0; i < x_names.Length; i++)
                x_names[i] += " : " + (minYear + i);
            return x_names;
        }
        private static void GetMaxAndMinYear(NameData[] names)
        {
            minYear = int.MaxValue;
            maxYear = int.MinValue;
            foreach (var name in names)
            {
                minYear = Math.Min(minYear, name.BirthDate.Year);
                maxYear = Math.Max(maxYear, name.BirthDate.Year);
            }
        }
    }
}
