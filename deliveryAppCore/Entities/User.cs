using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace deliveryAppCore.Entities
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("user")]
        [StringLength(150)]
        public string User1 { get; set; }
        [Required]
        [Column("pass")]
        [StringLength(250)]
        public string Pass { get; set; }
        [Column("created", TypeName = "datetime")]
        public DateTime Created { get; set; }
        [Required]
        [Column("createdBy")]
        [StringLength(150)]
        public string CreatedBy { get; set; }
        [Column("updated", TypeName = "datetime")]
        public DateTime Updated { get; set; }
        [Required]
        [Column("updatedBy")]
        [StringLength(150)]
        public string UpdatedBy { get; set; }
    }
}
