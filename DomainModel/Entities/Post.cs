using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{
    public class Post 
    {
        public string Id { get; set; }

        public DateTime PostDate { get; set; }

        [Required(ErrorMessage = "Title Is Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Post Content Is Required")]
        public string Body { get; set; }

        public int CharCount { get; set; }

        public int CommentCount { get; set; }
        
        public IList<Comment> Comments { get; set; }
    }
}