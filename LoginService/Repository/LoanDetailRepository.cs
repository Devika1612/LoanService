using LoanMngt.Contracts;
using LoginService.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Repository
{
   public class LoanDetailRepository: RepositoryBase<LoanDetail>, ILoanDetailRepository
    {
        public LoanDetailRepository(LoanDetailContext loanDetailContext)
            : base(loanDetailContext)
        {
        }
    }
}
