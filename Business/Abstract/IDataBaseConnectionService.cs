using Business.Dtos.DataBaseConnectionInfo;
using DataAccess.Concrete;

namespace Business.Abstract
{
    public interface IDataBaseConnectionService
    {
        Task<bool> ConnectToDatabaseAsync(DataBaseConnectionInfoRequestDto dataBaseConnectionInfoRequestDto);
        DynamicChartAppContext GetDbContext();
        void DisconnectDatabase();
    }
}
