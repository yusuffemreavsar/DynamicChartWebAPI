using Business.Abstract;
using Business.Dtos.DataBaseConnectionInfo;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class DataBaseConnectionService : IDataBaseConnectionService
    {
        private DbContext _dbContext;
        private string _connectionString;

        public AStoreDbContext _aStoreDbContext { get; }
        public BStoreDbContext _bStoreDbContext { get; }

        public DataBaseConnectionService(AStoreDbContext aStoreDbContext , BStoreDbContext bStoreDbContext)
        {
            _aStoreDbContext = aStoreDbContext;
            _bStoreDbContext = bStoreDbContext;
        }
        public async Task<bool> ConnectToDatabaseAsync(DataBaseConnectionInfoRequestDto dataBaseConnectionInfoRequestDto)
        {
            if (_dbContext != null) return true;

            _connectionString = $"Server={dataBaseConnectionInfoRequestDto.ServerName};Database={dataBaseConnectionInfoRequestDto.DatabaseName};User Id={dataBaseConnectionInfoRequestDto.Username};Password={dataBaseConnectionInfoRequestDto.Password};Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;";
            if (dataBaseConnectionInfoRequestDto != null) {
            
            if(dataBaseConnectionInfoRequestDto.ServerName == "AStoreDbContext")
             {
                    _dbContext = _aStoreDbContext;
             }
            if (dataBaseConnectionInfoRequestDto.ServerName == "AStoreDbContext")
                {
                    _dbContext = _bStoreDbContext;
                }
            }

            try
            {
                var canConnect = await _dbContext.Database.CanConnectAsync();
                return canConnect;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DbContext GetDbContext()
        {
            return _dbContext;
        }
        public void DisconnectDatabase()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }
    }
}
