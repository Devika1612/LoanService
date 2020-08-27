using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginService.Models;
using Microsoft.AspNetCore.Authorization;
using LoanMngt.Contracts;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class LoanDetailsController : ControllerBase
    {
       // private readonly LoanDetailContext _context;
        //public LoanDetailsController(LoanDetailContext context)
        //{
        //    _context = context;
        //}
        private IRepositoryWrapper _repoWrapper;
        public LoanDetailsController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

  // GET: api/LoanDetails
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<LoanDetail> GetLoanDetails()
        {
            return (IEnumerable<LoanDetail>)_repoWrapper.LoanDetail;
        }

        // GET: api/LoanDetails
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [MapToApiVersion("1.1")]
        public IEnumerable<LoanDetail> GetLoanDetailsV1_1()
        {
            return (IEnumerable<LoanDetail>)_repoWrapper.LoanDetails;
        }

        // GET: api/LoanDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loanDetail = await _repoWrapper.LoanDetails.FindAsync(id);

            if (loanDetail == null)
            {
                return NotFound();
            }

            return Ok(loanDetail);
        }

        // PUT: api/LoanDetails/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        
        public async Task<IActionResult> PutLoanDetail([FromRoute] int id, [FromBody] LoanDetail loanDetail)
        {
           // var retry = Policy
           //.Handle<Exception>()
           //.WaitAndRetry(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loanDetail.LNId)
            {
                return BadRequest();
            }

            _repoWrapper.Entry(loanDetail).State = EntityState.Modified;

            try
            {
                
                    await _repoWrapper.SaveChangesAsync();
              
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoanDetails
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostLoanDetail([FromBody] LoanDetail loanDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repoWrapper.LoanDetails.Add(loanDetail);
            await _repoWrapper.SaveChangesAsync();

            return CreatedAtAction("GetLoanDetail", new { id = loanDetail.LNId }, loanDetail);
        }

        // DELETE: api/LoanDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loanDetail = await _repoWrapper.LoanDetails.FindAsync(id);
            if (loanDetail == null)
            {
                return NotFound();
            }

            _repoWrapper.LoanDetails.Remove(loanDetail);
            await _repoWrapper.SaveChangesAsync();

            return Ok(loanDetail);
        }

        private bool LoanDetailExists(int id)
        {
            return _repoWrapper.LoanDetails.Any(e => e.LNId == id);
        }
    }
}