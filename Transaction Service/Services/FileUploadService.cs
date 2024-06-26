using CsvHelper;
using CsvHelper.Configuration;
using FluentValidation;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Transaction_Service.Models;

namespace Transaction_Service.Services
{
    public class FileUploadService
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<Transactions> _validator;

        public FileUploadService(ApplicationDbContext context, IValidator<Transactions> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<UploadResult> UploadFileAsync(IFormFile file)
        {
            var transactions = new List<Transactions>();
            var invalidRecords = new List<string>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
                csv.Context.RegisterClassMap<TransactionMap>();

                var records = csv.GetRecords<Transactions>().ToList();

                foreach (var record in records)
                {
                    var validationResult = _validator.Validate(record);
                    if (!validationResult.IsValid)
                    {
                        var invalidRecord = $"Invalid record: {string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))}";
                        invalidRecords.Add(invalidRecord);
                    }
                    else
                    {
                        if (_context.Transactions.Any(t => t.ReferenceNumber == record.ReferenceNumber))
                        {
                            throw new DuplicateReferenceException($"Duplicate reference number found: {record.ReferenceNumber}");
                        }

                        transactions.Add(record);
                    }
                }
            }

            if (invalidRecords.Any())
            {

                throw new InvalidFileException($"Invalid records found. File not imported. Details: {string.Join("\n", invalidRecords)}");
            }

            await _context.Transactions.AddRangeAsync(transactions);
            await _context.SaveChangesAsync();

            return new UploadResult(true);
        }
    }

    public class UploadResult
    {
        public bool Success { get; }
        public List<string> ErrorMessages { get; }

        public UploadResult(bool success, List<string> errorMessages = null)
        {
            Success = success;
            ErrorMessages = errorMessages ?? new List<string>();
        }
    }

    public class DuplicateReferenceException : System.Exception
    {
        public DuplicateReferenceException(string message) : base(message) { }
    }

    public class InvalidFileException : System.Exception
    {
        public InvalidFileException(string message) : base(message) { }
    }
}
