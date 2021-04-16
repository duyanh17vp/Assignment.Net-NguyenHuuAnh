using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set;}
        public ICollection<BookBorrowingRequest> RequestOrders {get; set;}

    }
}
