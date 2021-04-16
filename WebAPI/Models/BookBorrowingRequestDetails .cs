using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class BookBorrowingRequestDetails 
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book {get; set; }
        public int RequestOrderId { get; set; }
        public BookBorrowingRequest RequestOrder {get; set;}

    }
}
