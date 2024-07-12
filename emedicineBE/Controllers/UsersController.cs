using emedicineBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace emedicineBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DAL _dal;
        public UsersController(IConfiguration configuration, DAL dal)
        {
            _configuration = configuration;
            _dal = dal;
        }

        [HttpPost]
        [Route("register")]
        public Response register(Users users)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            
            Response response = new Response();
            response = _dal.Register(users, connection);

            return response;
        }

        [HttpPost]
        [Route("login")]
        public Response login(Users users)
        { 
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            
            Response response = new Response();
            response = _dal.Login(users, connection);

            return response;
        }

        [HttpPost]
        [Route("viewUser")]
        public Response viewUser(Users users)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            
            Response response = _dal.ViewUser(users, connection);

            return response;
        }

        [HttpPost]
        [Route("updateProfile")]
        public Response updateProfile(Users users)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());

            Response response = _dal.UpdateProfile(users, connection);
            
            return response;
        }
    }
}
