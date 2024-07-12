using emedicineBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace emedicineBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DAL _dal;

        public MedicinesController(IConfiguration configuration, DAL dal)
        {
            _configuration = configuration;
            _dal = dal;
        }

        [HttpPost]
        [Route("addToCart")]
        public Response addToCart(Cart cart)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());

            Response response = _dal.AddToCart(cart, connection);

            return response; 
        }

        [HttpPost]
        [Route("placeOrder")]
        public Response placeOrder(Users users)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());

            Response response = _dal.PlaceOrder(users, connection);

            return response;
        }

        [HttpPost]
        [Route("orderList")]
        public Response orderList(Users users)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());

            Response response = _dal.OrderList(users, connection);

            return response;
        }
}
        