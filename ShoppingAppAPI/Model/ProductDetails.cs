using ShoppingAppAPI.Model;
using System;
using System.Collections.Generic;

namespace ShoppingAppAPI
{
    public class ProductDetails : IProductDetails
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }
        public decimal Cost { get; set; }


        public  List<ProductDetails> GetDetails()
        {
            List<ProductDetails> details = new List<ProductDetails>{
            new ProductDetails { Id= 1, Color= "blue", Quantity= 10 ,Cost=100},
            new ProductDetails { Id= 2, Color= "red",  Quantity= 5 ,Cost=150},
            new ProductDetails { Id= 3, Color= "yellow",  Quantity= 0 ,Cost=200}
          };
            return details;
        }
    }

}
