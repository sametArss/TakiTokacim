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

        public List<Comments> CommentAll(int id)
        {
            return _commentsDal.GetAllFilterInclude(x => x.ProductId == id && x.CommentStatus==true,
                                                        x => x.User);
        }

        public List<Comments> GetCommentFalse()
        {
            return _commentsDal.GetAllFilterInclude(x => x.CommentStatus == false,
                x=>x.User,x=>x.Product);
        }

        public Comments GetCommentsId(int id)
        {
            return _commentsDal.GetById(id);
        }

        public void Insert(Comments comment)
        {
            _commentsDal.Insert(comment);
        }

        public void Update(Comments comment)
        {
            _commentsDal.Update(comment);
        }
    }
}
