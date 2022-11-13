﻿using FenClub.Models.Domain;
using Microsoft.EntityFrameworkCore;
using ScorePrediction.Domain;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ScorePrediction.Web.Models
{
    public class ScorePredictionDbContext : DbContext
    {
        public ScorePredictionDbContext(DbContextOptions<ScorePredictionDbContext> options)
              : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScorePredictionDbContext).Assembly);
        }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
    }
}