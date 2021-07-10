using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace deliveryAppCore.Entities
{
    public partial class Po
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Cod { get; set; }
        [Required]
        [StringLength(4000)]
        public string Details { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
    }
}
