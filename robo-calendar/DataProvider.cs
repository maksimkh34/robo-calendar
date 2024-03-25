using System.IO;

namespace robo_calendar
{
    internal static class DataProvider
    {
        public static Dictionary<string, string> LoadDataDict(string fileName, char delimeter = '=')
        {
            Dictionary<string, string> result = [];
            string[] text;
            try { text = File.ReadAllLines(fileName); }
            catch (FileNotFoundException)
            {
                File.Create(fileName).Close();
                text = File.ReadAllLines(fileName);
            }
            if (text.Length == 0) return result;

            foreach (string line in text)
            {
                result.Add(line.Split(delimeter)[0], line.Split(delimeter)[1]);
            }

            return result;
        }

        public static List<List<string>> LoadDataList(string fileName, char delimeter = ';')
        {
            List<List<string>> result = [];

            string[] text = File.ReadAllLines(fileName);
            if (text.Length == 0) return result;

            foreach (string line in text)
            {
                result.Add([.. line.Split(delimeter)]);
            }

            return result;
        }

        public static void WriteDataDict(string fileName, Dictionary<string, string> data, char delimeter = '=')
        {
            using StreamWriter writer = new(fileName);
            foreach (string key in data.Keys)
            {
                if (key.Contains(delimeter) || data[key].Contains(delimeter))
                {
                    throw new InvalidDataProvidedException();
                }
                writer.WriteLine(key + delimeter + data[key]);
            }
        }

        public static void WriteDataList(string fileName, List<List<string>> data, char delimeter = '=')
        {
            using StreamWriter writer = new(fileName);
            foreach (List<string> dataLine in data)
            {
                string output = "";
                foreach (string line in dataLine)
                {
                    if (line.Contains(delimeter))
                    {
                        throw new InvalidDataProvidedException();
                    }
                    output += line + delimeter;
                }
                output = output.Remove(output.Length - 1, 1);
                writer.WriteLine(output);
            }
        }
    }
}
