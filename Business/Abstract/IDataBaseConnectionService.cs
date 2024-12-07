using Business.Dtos.DataBaseConnectionInfo;
using Microsoft.EntityFrameworkCore;

namespace Business.Abstract
{
    public interface IDataBaseConnectionService
    {
        Task<bool> ConnectToDatabaseAsync(DataBaseConnectionInfoRequestDto dataBaseConnectionInfoRequestDto);
        DbContext GetDbContext();
        void DisconnectDatabase();
    }
}
