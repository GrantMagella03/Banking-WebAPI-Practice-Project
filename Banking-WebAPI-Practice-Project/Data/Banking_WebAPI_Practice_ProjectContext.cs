using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Banking_WebAPI_Practice_Project.Models;

namespace Banking_WebAPI_Practice_Project.Data
{
    public class Banking_WebAPI_Practice_ProjectContext : DbContext
    {
        public Banking_WebAPI_Practice_ProjectContext (DbContextOptions<Banking_WebAPI_Practice_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Banking_WebAPI_Practice_Project.Models.Customer> Customers { get; set; } = default!;

        public DbSet<Banking_WebAPI_Practice_Project.Models.Account> Accounts { get; set; } = default!;

        public DbSet<Banking_WebAPI_Practice_Project.Models.Transaction> Transactions { get; set; } = default!;
    }
}
