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
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public Response register(Users users)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            
            DAL dal = new DAL();
            Response response = new Response();

            response = dal.Register(users, connection);

            return response;
        }

        [HttpPost]
        [Route("login")]
        public Response login(Users users)
        { 
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            
            DAL dal = new DAL();
            Response response = new Response();

            response = dal.Login(users, connection);

            return response;
        }

        [HttpPost]
        [Route("viewUser")]
        public Response viewUser(Users users)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            
            DAL dal = new DAL();
            Response response = dal.ViewUser(users, connection);

            return response;
        }

        [HttpPost]
        [Route("updateProfile")]
        public Response updateProfile(Users users)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());

            DAL dal = new DAL();
            Response response = dal.UpdateProfile(users, connection);
            
            return response;
        }
    }
}
