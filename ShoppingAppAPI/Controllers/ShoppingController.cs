using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingAppAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingController : ControllerBase
    {
         private readonly ILogger<ShoppingController> _logger;
         private readonly  IProductDetails _productdetail;

        public ShoppingController(ILogger<ShoppingController> logger , IProductDetails productDetails)
        {
            _logger = logger;
            _productdetail = productDetails;
        }
        //Get Methode for ProductDetails
        [HttpGet]
        public IEnumerable<ProductDetails> Get()
        {
            return _productdetail.GetDetails().ToArray();
            
        }
    }
}
