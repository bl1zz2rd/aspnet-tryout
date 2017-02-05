using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace MultitenantProj.EntityFramework.Repositories
{
    public abstract class MultitenantProjRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<MultitenantProjDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MultitenantProjRepositoryBase(IDbContextProvider<MultitenantProjDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class MultitenantProjRepositoryBase<TEntity> : MultitenantProjRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected MultitenantProjRepositoryBase(IDbContextProvider<MultitenantProjDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
