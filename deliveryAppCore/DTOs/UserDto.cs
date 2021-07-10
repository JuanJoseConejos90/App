using System;

namespace deliveryAppCore.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string User1 { get; set; }
        public string Pass { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
