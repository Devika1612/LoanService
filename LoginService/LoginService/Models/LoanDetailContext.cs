using Microsoft.EntityFrameworkCore;

namespace LoginService.Models
{
    public partial class LoanDetailContext : DbContext
    {
        public LoanDetailContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<LoanDetail> LoanDetails { get; set; }
    }
}

