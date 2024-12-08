using Business.Dtos.DataBaseConnectionInfo;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Business.Abstract
{
    public interface IDataBaseConnectionService
    {
        Task<bool> ConnectToDatabaseAsync(DataBaseConnectionInfoRequestDto dataBaseConnectionInfoRequestDto = null, string connectionString = null);
        DynamicChartDbContext GetDbContext();
        string GetConnectionString();
    }
}
