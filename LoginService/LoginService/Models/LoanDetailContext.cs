using Microsoft.EntityFrameworkCore;

namespace LoginService.Models
{
    public class LoanDetailContext : DbContext
    {
        public LoanDetailContext(DbContextOptions<LoanDetailContext> options) : base(options)
        {

        }
        public DbSet<LoanDetail> LoanDetails { get; set; }
    }
}
