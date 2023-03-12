﻿using Enterprise.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Persistence;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<PaymentRecord> PaymentRecords { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<TaxYear> TaxYear { get; set; }
}

