using BusiniessLayer.Abstract;
using DataAcsessLayer.Abstract;
using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentsDal _commentsDal;
        public CommentManager(ICommentsDal commentsDal)
        {
            _commentsDal = commentsDal;
        }

        public List<Comments> CommentAll()
        {
            return _commentsDal.CommentAll();
        }

      
    }
}
