using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginService.Models;
using Microsoft.AspNetCore.Authorization;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanDetailsController : ControllerBase
    {
        private readonly LoanDetailContext _context;

        public LoanDetailsController(LoanDetailContext context)
        {
            _context = context;
        }

        // GET: api/LoanDetails
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<LoanDetail> GetLoanDetails()
        {
            return _context.LoanDetails;
        }

        // GET: api/LoanDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loanDetail = await _context.LoanDetails.FindAsync(id);

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loanDetail.LNId)
            {
                return BadRequest();
            }

            _context.Entry(loanDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            _context.LoanDetails.Add(loanDetail);
            await _context.SaveChangesAsync();

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

            var loanDetail = await _context.LoanDetails.FindAsync(id);
            if (loanDetail == null)
            {
                return NotFound();
            }

            _context.LoanDetails.Remove(loanDetail);
            await _context.SaveChangesAsync();

            return Ok(loanDetail);
        }

        private bool LoanDetailExists(int id)
        {
            return _context.LoanDetails.Any(e => e.LNId == id);
        }
    }
}