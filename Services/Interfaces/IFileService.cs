using Microsoft.AspNetCore.Http;
using SmartOrderSystem.DTOs;

namespace SmartOrderSystem.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
        Task<List<BulkOrderRow>> ReadCsvAsync(string filePath);
        Task<List<BulkOrderRow>> ReadExcelAsync(string filePath);
        Task<FileImportResult> ValidateAndParseOrders(string filePath);
    }
}