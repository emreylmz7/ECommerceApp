using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.Payment.Dtos;
using OllieShop.Payment.Services;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentDto createPaymentDto)
    {
        var payment = await _paymentService.CreatePaymentAsync(createPaymentDto);
        return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, payment);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaymentById(int id)
    {
        var payment = await _paymentService.GetPaymentByIdAsync(id);
        if (payment == null)
        {
            return NotFound();
        }

        return Ok(payment);
    }

    [HttpGet("order/{orderId}")]
    public async Task<IActionResult> GetPaymentsByOrderId(string orderId)
    {
        var payments = await _paymentService.GetPaymentsByOrderIdAsync(orderId);
        return Ok(payments);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdatePaymentStatus(int id, [FromBody] string status)
    {
        var result = await _paymentService.UpdatePaymentStatusAsync(id, status);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
