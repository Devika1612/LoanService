using System;
using System.Collections.Generic;
using System.Text;
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
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
