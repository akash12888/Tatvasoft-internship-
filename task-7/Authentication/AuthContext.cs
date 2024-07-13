using Authentication.Entities;
using Authentication.Model;
using Microsoft.EntityFrameworkCore;

namespace Authentication
{
    public class AuthContext : DbContext
    {

        public AuthContext(DbContextOptions<AuthContext> options): base(options) 
        {
            
        }
        public DbSet<MissionDto> Missions{get;set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Themedto> Themes { get; set; }

        public DbSet<MissionSkilldto> MissionSkill { get; set; }
    }
    
}
