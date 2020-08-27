using LoanMngt.Contracts;
using LoginService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected LoanDetailContext LoanDetailContext { get; set; }

        public RepositoryBase(LoanDetailContext loanDetailContext)
        {
            LoanDetailContext = loanDetailContext;
        }
        public IQueryable<T> FindAll()
        {
            return LoanDetailContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return LoanDetailContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            LoanDetailContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            LoanDetailContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            LoanDetailContext.Set<T>().Remove(entity);
        }
    }
}
