using Microsoft.AspNetCore.Mvc;
using NorthwindClient.Data;
using NorthwindClient.Models;

namespace NorthwindClient.Controllers;

[ApiController]
[Route("[Controller]")]
public class NorthwindController : ControllerBase
{
    NorthwindContext NWcontext;
    private readonly ILogger<NorthwindController> _logger;
    public NorthwindController(ILogger<NorthwindController> logger, NorthwindContext context){
        _logger=logger;
        NWcontext=context;
    }

    [HttpGet]
    [Route("categorias")]
    public IEnumerable<Category> Get(){
        return NWcontext.Categories.ToList<Category>()
        .ToArray();
    }

    [HttpGet]
    [Route("Productos")]
    public IEnumerable<Product> GetProduct(){
        return NWcontext.Products.ToList<Product>()
        .ToArray();
    }

}