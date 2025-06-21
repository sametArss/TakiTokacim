using EntitiyLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Abstract
{
    public interface ICommentsDal:IGenericRepositoriesDal<Comments>
    {
        Task AddAsync(Comments entity);
        IQueryable<Comments> GetAllFilter(Expression<Func<Comments, bool>> filter);
    }
}
