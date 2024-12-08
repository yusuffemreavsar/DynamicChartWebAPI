using Business.Abstract;
using Business.Dtos.DataBaseConnectionInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DynamicChartWebAPI.Controllers
{
    public class DataBaseController : ControllerBase
    {
        private readonly IDataBaseConnectionService _dataBaseConnectionService;
        private static string _connectionString;
        public DataBaseController(IDataBaseConnectionService dataBaseConnectionService)
        {
            _dataBaseConnectionService = dataBaseConnectionService;
        }
        [HttpPost("connectDatabase")]
        public async Task<IActionResult> ConnectToDatabase([FromBody] DataBaseConnectionInfoRequestDto dataBaseConnectionInfoRequestDto)
        {
            bool isConnected = await _dataBaseConnectionService.ConnectToDatabaseAsync(dataBaseConnectionInfoRequestDto);

            if (isConnected)
            {
                _connectionString=_dataBaseConnectionService.GetConnectionString();
                return Ok(new { message = $"{dataBaseConnectionInfoRequestDto.DatabaseName} Successfully connected to the database!!" });
            }
            else
            {
                return BadRequest(new { message = "Could not connect to database!" });
            }
        }
        [HttpPost("disconnectDatabase")]
        public IActionResult DisconnectDatabase()
        {
            _connectionString = null;
            return Ok(new { message = "The connection has been lost!" });
        }

        [HttpGet("getAllBooks")]
        public async Task<IActionResult> GetAllBooksProcedures()
        {
            bool isConnected = await _dataBaseConnectionService.ConnectToDatabaseAsync(null,_connectionString);
            if (isConnected)
            {
                var connectDbContext = _dataBaseConnectionService.GetDbContext();
                var procedures = await connectDbContext.Books.FromSqlRaw("AllBooks").ToListAsync();
                return Ok(procedures);
            }

            return NotFound();
        }
        [HttpGet("getStoredProcedures")]
        public async Task<IActionResult> GetStoredProcedures()
        {
            // Veritabanına bağlanma işlemi
            bool isConnected = await _dataBaseConnectionService.ConnectToDatabaseAsync(null, _connectionString);
            if (isConnected)
            {
                var connectDbContext = _dataBaseConnectionService.GetDbContext();

                // sys.procedures'den stored procedure'leri al
                var storedProcedures = await connectDbContext.StoredProcedureList
                    .FromSqlRaw("SELECT [name] FROM sys.procedures")
                    .Select(sp => sp.Name)
                    .ToListAsync();

                return Ok(storedProcedures);
            }

            return NotFound("Database connection failed.");
        }
    }
}
