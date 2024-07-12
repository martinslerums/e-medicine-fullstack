using emedicineBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace emedicineBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DAL _dal;

        public AdminController(IConfiguration configuration, DAL dal)
        {
            _configuration = configuration;
            _dal = dal; 
        }

        [HttpPost]
        [Route("addUpdateMedicine")]
        public Response addUpdateMedicine(Medicines medicines)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());

            Response response = _dal.AddUpdateMedicine(medicines, connection);

            return response;
        }

        [HttpGet]
        [Route("userList")]
        public Response userList()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            
            Response response = _dal.UserList(connection);

            return response;
        }
    }
}   
