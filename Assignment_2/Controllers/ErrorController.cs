using Microsoft.AspNetCore.Mvc;

namespace Assignment_1.Controllers;

public class ErrorController : Controller
{
    [Route("Error/{statusCode}")]
    public IActionResult HttpStatusCodeHandler(int statusCode)
    {
        switch (statusCode)
        {
            case 404:
                return View("404NotFound"); 
            case 500:
                return View("505ServerError"); 
            default:
                return View("GenericError"); 
        }
    }
}