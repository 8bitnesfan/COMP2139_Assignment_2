using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Assignment_1.Data;
using Assignment_1.Models;

public class OrdersController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ApplicationDbContext context, ILogger<OrdersController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> GetOrder(int id)
    {
        try
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                _logger.LogWarning("Order {OrderId} not found.", id);
                return RedirectToAction("HttpStatusCodeHandler", "Error", new { statusCode = 404 });
            }

            return View(order);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching order {OrderId}.", id);
            return RedirectToAction("HttpStatusCodeHandler", "Error", new { statusCode = 500 });
        }
    }
}