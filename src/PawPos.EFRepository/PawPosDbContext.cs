using Microsoft.EntityFrameworkCore;
using PawPos.Domain.Ticket;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.EFRepository
{
    public class PawPosDbContext : DbContext
    {
        public PawPosDbContext(DbContextOptions<PawPosDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketAsset> TicketAssets { get; set; }
    }
}
