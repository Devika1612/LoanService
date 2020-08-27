using LoanMngt.Contracts;
using LoginService.Models;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected LoanDetailContext LoanDetailContext { get; set; }

        public RepositoryBase(LoanDetailContext loanDetailContext)
        {
            this.LoanDetailContext = loanDetailContext;
        }
    }
}
