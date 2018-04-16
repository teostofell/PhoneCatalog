using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogApp.API.Models
{
    public class CommentVM
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public UserVM User { get; set; }

        public int PhoneId { get; set; }
    }
}