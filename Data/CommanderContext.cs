using BackEndAPIHost.Models;
using Microsoft.EntityFrameworkCore;
//External (Not DTOs--all data in "DbSet" are exposing to client)
namespace BackEndAPIHost.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            
        }
        public DbSet<Command> Commands { get; set; }
    }
}