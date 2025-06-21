using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Context;
using DataAcsessLayer.Concrete.Repositories;
using EntitiyLayer.Models;
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

            public async Task AddAsync(Comments entity)
            {
                await _context.Set<Comments>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }

        IQueryable<Comments> ICommentsDal.GetAllFilter(Expression<Func<Comments, bool>> filter)
        {
            return _context.Set<Comments>().Where(filter);
        }
    }
    
}
