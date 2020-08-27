using LoanMngt.Contracts;
using LoginService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class LoanDetailRepository : RepositoryBase<LoanDetail>, ILoanDetailRepository
    {
        public LoanDetailRepository(LoanDetailContext loanDetailContext)
            : base(loanDetailContext)
        {
        }
        public IEnumerable<LoanDetail> GetLoanDetails()
        { return FindAll().OrderBy(ow => ow.LoanOwnerName).ToList();
        }
        public LoanDetail GetLoanDetail([FromRoute] int id)
        {
        return FindByCondition(x => x.LNId.Equals(id))
            .FirstOrDefault();
    }
       public void PostLoanDetail(LoanDetail loanDetail)
        {
            Create(loanDetail);
        }
       public void PutLoanDetail(LoanDetail loanDetail)
        {
            Update(loanDetail);
        }
        public void DeleteLoanDetail(LoanDetail loanDetail)
        {
            Delete(loanDetail);
        }

    }
}

    
    


