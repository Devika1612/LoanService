using LoginService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanMngt.Contracts
{
   public interface ILoanDetailRepository: IRepositoryBase<LoanDetail>
    {
        IEnumerable<LoanDetail> GetLoanDetails();
        LoanDetail GetLoanDetail([FromRoute] int id);
        void PostLoanDetail(LoanDetail loanDetail);
        void PutLoanDetail(LoanDetail loanDetail);
        void DeleteLoanDetail(LoanDetail loanDetail);
    }
}
