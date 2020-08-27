using LoginService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanMngt.Contracts
{
   public interface IRepositoryWrapper
    {
        ILoanDetailRepository LoanDetail { get; }
        object LoanDetails { get; set; }

        void Save();
        object Entry(LoanDetail loanDetail);
        Task SaveChangesAsync();
       
    }
}
