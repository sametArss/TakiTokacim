using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        [StringLength(200)]
        public string Subject { get; set; }

        [StringLength(500)]
        public string Message { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }

        // 
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
