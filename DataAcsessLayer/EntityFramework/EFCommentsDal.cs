using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Context;
using DataAcsessLayer.Concrete.Repositories;
using EntitiyLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.EntityFramework
{
    public class EFCommentsDal:GenericRepositoriesDal<Comments>,ICommentsDal
    {

        public EFCommentsDal(AppDbContext context) : base(context)
        {
        }

  

        public List<Comments> CommentAll()
        {
            return _context.Comments.Include(c => c.User).ToList();
        }
    }

}
