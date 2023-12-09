using BooKStore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public int TotalPages { get; set; }

        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public int StatusId { get; set; }



        public virtual Author? Author { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual Status? Status { get; set; }
    }
}
