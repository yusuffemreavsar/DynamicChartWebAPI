using Business.Abstract;
using Business.Dtos.DataBaseConnectionInfo;
using DataAccess.Concrete;

namespace Business.Concrete
{
    public class DataBaseConnectionService : IDataBaseConnectionService
    {
        private DynamicChartAppContext _dbContext;
        private string _connectionString;
        public async Task<bool> ConnectToDatabaseAsync(DataBaseConnectionInfoRequestDto dataBaseConnectionInfoRequestDto)
        {
            if (_dbContext != null) return true;

            _connectionString = $"Server={dataBaseConnectionInfoRequestDto.ServerName};Database={dataBaseConnectionInfoRequestDto.DatabaseName};User Id={dataBaseConnectionInfoRequestDto.Username};Password={dataBaseConnectionInfoRequestDto.Password};Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;";
            _dbContext = new DynamicChartAppContext(_connectionString);

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

        public DynamicChartAppContext GetDbContext()
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
