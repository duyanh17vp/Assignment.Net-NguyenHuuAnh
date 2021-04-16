using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class BookBorrowingRequest
    {
        [Key]
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime DateRequest { get; set; }
        public DateTime DateReturn { get; set; }
        public int UserId { get; set; }
        public User User { get; set;}
        public ICollection<Book> Books { get; set;}
        public ICollection<BookBorrowingRequestDetails > RequestDetails {get; set;}
    }
}
