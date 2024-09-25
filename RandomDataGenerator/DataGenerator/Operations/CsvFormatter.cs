using DataGenerator.Models;
using System.Text;

namespace DataGenerator.Operations
{
    public class CsvFormatter
    {
        public string Format(List<UserData> userDataList)
        {
            var csvBuilder = new StringBuilder();
            foreach (var userData in userDataList)
            {
                csvBuilder.AppendLine($"{userData.Index},{userData.RandomIdentifier},{userData.Name},{userData.MiddleName},{userData.LastName},{userData.Address},{userData.Phone}");
            }

            return csvBuilder.ToString();
        }
    }
}
