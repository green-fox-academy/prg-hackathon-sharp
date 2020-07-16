﻿using Microsoft.EntityFrameworkCore;
using programmersGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace programmersGuide.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Form> Forms { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}