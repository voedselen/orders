using BusinessLayer;
using BusinessLayer.DB_Interfaces;
using DBLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoedselASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusinessLogic _orderLogic;
        public OrderController(IOrderBusinessLogic iAccessOrder)
        {
            _orderLogic = iAccessOrder;
        }
        // GET: api/<OrderController>
        [HttpGet(template: "getall")]
        public IActionResult Get()
        {
            bool result = true;

            try
            {
                List<Order> orders =_orderLogic.ReadOrdersDB();
                var response = new { result = result, status = 200, message = "success", orders};
                return Ok(response);
            }
            catch (Exception ex)
            {
                result = false;
                var response = new { result = result, status = 200, message = ex.Message };
                return BadRequest(response);
            }
        }

        // POST api/<OrderController>
        [HttpPost(template:"post")]
        public IActionResult Post([FromBody] Order order)
        {
            bool result = true;

            try
            {
                // Log order details for troubleshooting
                Console.WriteLine($"Received Order: {JsonConvert.SerializeObject(order)}");


                _orderLogic.AddOrderDB(order);
                var response = new { result = result, status=200, message="success" };
                return Ok(response);
            }
            catch(Exception ex)
            {
                result = false;
                var response = new { result = result, status = 200, message=ex.Message };
                return BadRequest(response);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete(template: "delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            bool result = true;

            try
            {
                _orderLogic.DeleteOrderDB(id);
                var response = new { result = result, status = 200, message = "success" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                result = false;
                var response = new { result = result, status = 200, message = ex.Message };
                return BadRequest(response);
            }
        }

        [HttpPost(template: "FetchUnpaidOrdersByTableNumber")]
        public IActionResult UnpaidOrdersByTableNumber([FromQuery] int tableNumber)
        {
            bool result = true;

            try
            {
                List<Order> unpaidTableOrdersResult = _orderLogic.GetUnpaidOrdersByTableNumber(tableNumber);
                var response = new { result = result, status = 200, message = "success", unpaidTableOrders = unpaidTableOrdersResult.ToArray() };
                return Ok(response);
            }
            catch (Exception ex)
            {
                result = false;
                var response = new { result = result, status = 500, message = ex.Message };
                return BadRequest(response);
            }
        }
    }
}
