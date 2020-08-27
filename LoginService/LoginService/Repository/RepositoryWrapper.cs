using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LoanMngt.Contracts;
using LoginService.Models;

namespace Repository
{
   public class RepositoryWrapper : IRepositoryWrapper
    {
        private LoanDetailContext _context;
        private ILoanDetailRepository _loandetail;
 public ILoanDetailRepository LoanDetail
        {
            get
            {
                if (_loandetail == null)
                {
                    _loandetail = new LoanDetailRepository(_context);
                }
                return _loandetail;
            }
        }

        public object LoanDetails { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Entry(LoanDetail loanDetail)
        {
            throw new NotImplementedException();
        }

        public RepositoryWrapper(LoanDetailContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
