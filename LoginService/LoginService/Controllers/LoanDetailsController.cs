using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginService.Models;
using Microsoft.AspNetCore.Authorization;
using LoanMngt.Contracts;
using System;

namespace LoginService.Controllers
{
    [Route("api/LoanDetails")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class LoanDetailsController : ControllerBase
    {
      
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
            try
            {
                return (IEnumerable<LoanDetail>)_repoWrapper.LoanDetail;
            }
            catch
            {
                return (IEnumerable<LoanDetail>)StatusCode(500, "Internal server error");
            }
        }

        // GET: api/LoanDetails
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [MapToApiVersion("1.1")]
        public IEnumerable<LoanDetail> GetLoanDetailsV1_1()
        {
            try
            {
                return (IEnumerable<LoanDetail>)_repoWrapper.LoanDetail;
            }
            catch
            {
                return (IEnumerable<LoanDetail>)StatusCode(500, "Internal server error");
            }
        }

        // GET: api/LoanDetails/5
        [HttpGet("{id}")]
        public IActionResult GetLoanDetail([FromRoute] int id)
        {
            try
            {
                var loandetail = _repoWrapper.LoanDetail.GetLoanDetail(id);
                if (loandetail == null)
                {

                    return NotFound();
                }
                else
                {
                 return Ok(loandetail);
                }
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "Internal server error");
            }

           
        }

        // PUT: api/LoanDetails/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        
        public  IActionResult PutLoanDetail([FromRoute] int id, [FromBody] LoanDetail loanDetail)
        {
            try
            { 
            if(loanDetail==null)
            {
                return BadRequest(ModelState);
            }
           if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

                if (id != loanDetail.LNId)
                {
                    return BadRequest("Invalid model object");
                }
                else
                {
                    // _repoWrapper.Entry(loanDetail).State = EntityState.Modified;
                    var loanEntity = _repoWrapper.LoanDetail.GetLoanDetail(id);


                    _repoWrapper.LoanDetail.PutLoanDetail(loanEntity);
                    _repoWrapper.Save();

                }

            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!LoanDetailExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}

                return NotFound();
            }

            return NoContent();
        }

        // POST: api/LoanDetails
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostLoanDetail([FromBody] LoanDetail loanDetail)
        {
            try
            {
                if (loanDetail == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _repoWrapper.LoanDetail.PostLoanDetail(loanDetail);
                await _repoWrapper.SaveChangesAsync();

                return CreatedAtAction("GetLoanDetail", new { id = loanDetail.LNId }, loanDetail);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/LoanDetails/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLoanDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var loanDetail = _repoWrapper.LoanDetail.GetLoanDetail(id);
                if (loanDetail == null)
                {
                    return NotFound();
                }

                _repoWrapper.LoanDetail.DeleteLoanDetail(loanDetail);
                _repoWrapper.Save();

                return Ok(loanDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        //private bool LoanDetailExists(int id)
        //{
        //    return _repoWrapper.LoanDetails.FindByCondition(e => e.LNId == id);
        //}
    }
}