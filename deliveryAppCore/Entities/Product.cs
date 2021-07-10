using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace deliveryAppCore.Entities
{
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Cod { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        [Column("IVA", TypeName = "decimal(10, 2)")]
        public decimal Iva { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
    }
}
