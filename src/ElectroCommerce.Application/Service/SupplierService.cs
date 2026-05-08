using Application.Interface;
using Application.Respsone;
using AutoMapper;
using CsvHelper.Configuration.Attributes;
using Domain.Entities;
using Domain.Interface;
using ElectroCommerce.Application.Helpers;
using ElectroCommerce.Application.Model;
using ElectroCommerce.Application.Request;
using System.Reflection;

namespace Application.Service
{
    public class SupplierService: ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<SupplierResponse>> GetAllSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllSuppliersAsync();
            return _mapper.Map<IEnumerable<SupplierResponse>>(suppliers);
        }

        public async Task ImportSuplierAsyns(ImportSuplierRequest request)
        {
            var fileData = await ImportHelper.ReadFileDataAsync(request.File);

            var supliers = GetSuplierImport(fileData);

            var entities = supliers.Select(x => new Supplier
            {
                Name = x.Name,
                Email = x.Email
            }).ToList();

            await _supplierRepository.SaveAllAsync(entities);
        }

        private IEnumerable<ImportSuplierModel> GetSuplierImport(FileData fileData)
        {
            var records = new List<ImportSuplierModel>();

            foreach (var csvRecord in fileData.Records)
            {
                var record = new ImportSuplierModel();

                PropertyInfo[] props = record.GetType().GetProperties();

                var staticHeaders = new List<string>();

                foreach (PropertyInfo prp in props)
                {
                    var importName = prp.GetCustomAttribute<NameAttribute>()?.Names[0];

                    if (importName != null)
                    {
                        ImportHelper.AddIfNotExist(staticHeaders, importName);

                        var value = csvRecord.ContainsKey(importName) ? csvRecord[importName] : null;

                        prp.SetValue(record, value, null);
                    }
                }

                records.Add(record);
            }

            return records;
        }
    }
}
