using BusinessLayer.Classes;
using BusinessLayer.DB_Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VoedselASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaypalServices _paypalService;
        public PaymentController(IPaypalServices iPaypalService)
        {
            _paypalService = iPaypalService;
        }
        
        [HttpPost]
        
        public IActionResult Update([FromBody] Payments orderList)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _paypalService.UpdatePaymentStatus(orderList);

                bool result = true;
                var response = new { result = result, status = 200, message = "success" };
                return Ok(response);
                
            }
            catch (Exception ex)
            {
                bool result = false;
                var response = new { result = result, status = 200, message = ex.Message };
                return BadRequest(response);
            }
        }

        // GET: PaymentController/Delete/5

    }
}
