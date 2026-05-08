using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using System.Dynamic;
using System.Globalization;

namespace ElectroCommerce.Application.Helpers
{
    public static class ImportHelper
    {
        public static void AddIfNotExist(List<string> list, string value)
        {
            if (!list.Contains(value))
                list.Add(value);
        }

        public static async Task<FileData> ReadFileDataAsync(IFormFile file)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                BadDataFound = null,
                MissingFieldFound = null
            };

            var fileData = new FileData();

            using var stream = file.OpenReadStream();
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, config);

            await csv.ReadAsync();
            csv.ReadHeader();
            var headers = csv.HeaderRecord.ToList();
            fileData.Headers.AddRange(headers);

            while (await csv.ReadAsync())
            {
                var record = new ExpandoObject() as IDictionary<string, object>;
                foreach (var header in headers)
                {
                    record[header] = csv.GetField(header);
                }
                fileData.AddRecord(new Dictionary<string, object>(record));
            }

            return fileData;
        }
    }
}
