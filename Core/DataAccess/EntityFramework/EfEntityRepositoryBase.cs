using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    // Veri tabanına yeni tablo eklediğimizde, tüm tabloyu ilgilendire CRUD işlemleri bu sınıfta gerçekleştirilir.
    public class EfEntityRepositoryBase<TEntity,TContext> 
        where TEntity:class,new()
    {
    }
}
