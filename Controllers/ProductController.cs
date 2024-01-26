using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace app.webapi.Controllers
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
    }


    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> product = new List<Product>
        {
            new Product { Id = 1, Name="Kitap",Price=50 ,Category="Kırtasiye"},
            new Product { Id = 2, Name="Telefon",Price=500 ,Category="Elektronik"},
            new Product { Id = 3, Name="Bilgisayar",Price=1000 ,Category="Elektronik"},
            new Product { Id = 4, Name="Kalem",Price=500 ,Category="Kırtasiye"},
            new Product { Id = 5, Name="Defter",Price=15 ,Category="Kırtasiye"},
            new Product { Id = 6, Name="Kulaklık",Price=75 ,Category="Elektronik"},
            new Product { Id = 7, Name="Televizyon",Price=5000 ,Category="Elektronik"},
            new Product { Id = 8, Name="Bardak",Price=5 ,Category="Mutfak Eşyası"},
            new Product { Id = 9, Name="Demlik",Price=90 ,Category="Mutfak Eşyası"}

        };

        [HttpGet]
        public IEnumerable<Product> GetList()
        {
            return product;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var secilenUrun = product.FirstOrDefault(p => p.Id == id);

            if (secilenUrun == null)
            {
                return NotFound();
            }

            return secilenUrun;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product yeniUrun)
        {
            if (yeniUrun == null)
            {
                return BadRequest();
            }

            yeniUrun.Id = product.Count + 1;
            product.Add(yeniUrun);

            return CreatedAtAction(nameof(GetProductById), new { id = yeniUrun.Id }, yeniUrun);
        }

        [HttpPut("{id}")]
        public IActionResult PutProductById(int id, [FromBody] Product guncellenenUrun)
        {
            var secilenUrun = product.FirstOrDefault(p => p.Id == id);

            if (secilenUrun == null)
            {
                return NotFound();
            }

            secilenUrun.Name = guncellenenUrun.Name;
            secilenUrun.Price = guncellenenUrun.Price;
            secilenUrun.Category = guncellenenUrun.Category;

            return Ok(secilenUrun);


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(int id)
        {
            var secilenUrun = product.FirstOrDefault(p => p.Id == id);

            if (secilenUrun == null)
            {
                return NotFound();
            }

            product.Remove(secilenUrun);

            return NoContent();

        }


    }

}

