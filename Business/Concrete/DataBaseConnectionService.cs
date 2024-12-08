using Business.Abstract;
using Business.Dtos.DataBaseConnectionInfo;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete
{
    public class DataBaseConnectionService : IDataBaseConnectionService
    {
        private DynamicChartDbContext _dbContext;
        private string _connectionString;
        private readonly DynamicChartDbContext _dynamicChartDbContext;
        private readonly IConfiguration _configuration;

        public DataBaseConnectionService(DynamicChartDbContext dynamicChartDbContext,IConfiguration configuration)
        {
            _dynamicChartDbContext = dynamicChartDbContext;
            _configuration = configuration;
        }
        public async Task<bool> ConnectToDatabaseAsync(DataBaseConnectionInfoRequestDto? dataBaseConnectionInfoRequestDto, string? connectionString)
        {
            if (_dbContext != null) return true;
            if(dataBaseConnectionInfoRequestDto != null)
            {
                _connectionString = $"Server={dataBaseConnectionInfoRequestDto.ServerName};Database={dataBaseConnectionInfoRequestDto.DatabaseName};User Id={dataBaseConnectionInfoRequestDto.Username};Password={dataBaseConnectionInfoRequestDto.Password};Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;";
                _dbContext = _dynamicChartDbContext;
            }
            if(connectionString != null && connectionString == _configuration.GetConnectionString("StoreDb"))
            {
                _dbContext = _dynamicChartDbContext;
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

        public DynamicChartDbContext GetDbContext()
        {
            return _dbContext;
        }
        public string GetConnectionString()
        {
            return _connectionString;
        }
  }
        }
    

