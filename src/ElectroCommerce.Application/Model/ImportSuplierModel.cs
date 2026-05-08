using CsvHelper.Configuration.Attributes;

namespace ElectroCommerce.Application.Model
{
    public class ImportSuplierModel
    {
        [Name("Name")]
        public string Name { get; set; }
        [Name("Email")]
        public string Email { get; set; }
    }
}
