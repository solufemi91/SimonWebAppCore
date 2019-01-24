using Microsoft.EntityFrameworkCore;
using System;

namespace SimonWebAppCore.Models
{
    public class Player
    {
       public int Id { get; set; }

       public string Name { get; set; }

       public int Score { get; set; }
   
    }

    public class PlayerDBContext : DbContext
    {
        public PlayerDBContext(DbContextOptions<PlayerDBContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}