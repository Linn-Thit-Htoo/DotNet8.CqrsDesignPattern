using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet8.CqrsDesignPattern.Models
{
    [Table("Tbl_blog")]
    public class BlogModel
    {
        public long BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
} 