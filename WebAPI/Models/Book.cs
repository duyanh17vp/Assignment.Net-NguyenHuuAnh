using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        
        public Category Category { get; set;}
        public ICollection<BookBorrowingRequest> RequestOrders { get; set;}
        public ICollection<BookBorrowingRequestDetails > RequestDetails {get; set;}

    }
}
