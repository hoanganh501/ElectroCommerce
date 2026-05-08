namespace ElectroCommerce.Application.Helpers
{
    public class FileData
    {
        public List<string> Headers { get; set; } = new();

        public List<Dictionary<string, object>> Records { get; set; } = new();

        public void AddRecord(Dictionary<string, object> record)
        {
            Records.Add(record);
        }
    }
}
