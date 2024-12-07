using Business.Abstract;
using Business.Dtos.DataBaseConnectionInfo;
using Microsoft.AspNetCore.Mvc;

namespace DynamicChartWebAPI.Controllers
{
    public class DataBaseController : ControllerBase
    {
        private readonly IDataBaseConnectionService _dataBaseConnectionService;
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
            _dataBaseConnectionService.DisconnectDatabase();
            return Ok(new { message = "The connection has been lost!" });
        }
    }
}
