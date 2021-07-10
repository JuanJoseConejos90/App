using System;
using System.Collections.Generic;
using System.Text;

namespace deliveryAppCore.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Cod { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}
