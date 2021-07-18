namespace Api.Data
{
    using Microsoft.EntityFrameworkCore;

    public class MathGenDbContext : DbContext
    {
        public MathGenDbContext(DbContextOptions<MathGenDbContext> options)
            : base(options)
        {}
    }
}