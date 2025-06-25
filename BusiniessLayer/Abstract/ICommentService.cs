using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiniessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comments> GetCommentFalse();
        List<Comments> CommentAll(int id);
        Comments GetCommentsId(int id);
        void Insert(Comments comment);
        void Update(Comments comment);
    }
}
