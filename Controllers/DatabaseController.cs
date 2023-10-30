using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using DIENAPPRESTAPI.Data; 

[Route("api/[controller]/[action]")]
[ApiController]
public class DatabaseController : ControllerBase
{
    private readonly DIENAPPRESTAPIContext _context;

    public DatabaseController(DIENAPPRESTAPIContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult CheckDatabaseConnection()
    {
        try
        {
            _context.Database.OpenConnection();
            return Ok("Database connection successful!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Database connection failed: {ex.Message}");
        }
        finally
        {
            _context.Database.CloseConnection();
        }
    }
}
