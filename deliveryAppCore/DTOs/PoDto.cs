using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.DTOs
{
    public class PoDto
    {
        public int Id { get; set; }
        public string Cod { get; set; }
        public string Details { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}
