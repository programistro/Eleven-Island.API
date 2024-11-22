using System.Security.Cryptography;
using System.Text;
using ElevenIsland.API.Data;
using ElevenIsland.Core;
using ElevenIsland.Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ElevenIsland.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    
    private readonly AppDbContext _context;

    public CustomerController(ILogger<CustomerController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> Post(CustomerDto dto)
    {
        if (dto == null)
        {
            return BadRequest();
        }

        Customer customer = new()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Id = Guid.NewGuid(),
        };
        
        using (SHA256 sha = SHA256.Create())
        {
            byte[] hashValue = sha.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashValue.Length; i++)
            {
                builder.Append(hashValue[i].ToString("x2")); // Преобразуем байты хэша в шестнадцатеричное представление
            }

            string hash = builder.ToString();

            customer.PasswordHash = hash;
        }
        
        return Ok(customer);
    }
}