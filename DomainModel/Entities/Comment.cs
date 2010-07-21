using System;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{
    public class Comment
    {
        public int _CommentId { get; set; }

        public DateTime TimePosted { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Address Is Required")]
        /*[RegularExpression("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage = "A Valid E-Mail Address is required")]*/
        public string Email { get; set; }

        [Required(ErrorMessage = "Comment Content Is Required")]
        public string Body { get; set; }
    }
}
