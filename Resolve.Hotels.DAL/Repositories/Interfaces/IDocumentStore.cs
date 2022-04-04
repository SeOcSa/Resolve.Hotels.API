using System.Threading.Tasks;

namespace Resolve.Hotels.DAL.Repositories.Interfaces
{
    public interface IDocumentStore
    {
        Task<string> UploadFile(byte[] file, string hotelName);
        Task<byte[]>  DownloadFile(string storeId);
    }
}