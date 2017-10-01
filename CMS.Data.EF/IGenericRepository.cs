using CMS.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{

    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "");
    TEntity GetByID(Guid id);
    void Insert(TEntity entity);
    void Delete(Guid id);
    void Delete(TEntity entity);
    void Update(TEntity entity);
}