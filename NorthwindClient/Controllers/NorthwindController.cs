using Microsoft.AspNetCore.Mvc;
using NorthwindClient.Data;
using NorthwindClient.Models;

namespace NorthwindClient.Controllers;

[ApiController]
[Route("[Controller]")]
public class NorthwindController : ControllerBase
{
    NorthwindContext NWcontext;
    
    public NorthwindController( NorthwindContext context){

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
    
    [HttpPost]
    public IActionResult Create(Category newCategory)
    {
        var categoria = _service.Create(newCategory);
        return CreatedAtAction(nameof(Get), new { id = categoria!.Id }, categoria);
    }

    [HttpPut("{id}/addcategory")]
    public IActionResult AddCategory(int id, int CategoryId )
    {
        var categoriaToUpdate = _service.Get(id);

        if(categoriaToUpdate is not null)
        {
            _service.AddCategory(id,CategoryId );
            return NoContent();    
        }
        else
        {
            return NotFound();
        }
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var categoria = _service.Get(id);

        if(categoria is not null)
        {
            _service.DeleteByCategory(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

}
