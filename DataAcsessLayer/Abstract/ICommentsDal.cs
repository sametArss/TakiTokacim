using EntitiyLayer.Models;
using Microsoft.EntityFrameworkCore;
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
        List<Comments> CommentAll();
       
    }
}
