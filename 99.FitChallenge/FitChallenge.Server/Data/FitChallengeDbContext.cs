﻿using System;
using System.Threading;
using System.Threading.Tasks;
using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Data.Models.Base;
using FitChallenge.Server.Infrastructure.Extensions;
using FitChallenge.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using static FitChallenge.Server.Data.Seed.InitialData;

namespace FitChallenge.Server.Data
{
    public class FitChallengeDbContext : IdentityDbContext<User>
    {
        private readonly ICurrentUserService currentUser;

        public FitChallengeDbContext(DbContextOptions<FitChallengeDbContext> options, ICurrentUserService currentUser)
            :base(options)
        {
            this.currentUser = currentUser;
        }


        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Excercise> Excercises { get; set; }

        public DbSet<Workout> Workouts{ get; set; }

        public DbSet<WorkoutType> WorkoutTypes { get; set; }

        public DbSet<ExcerciseWorkout> ExcerciseWorkouts { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WorkoutType>()
                .HasData(BasicWorkoutTypes);

            builder.Entity<ExcerciseWorkout>()
                .HasKey(c => new { c.ExcerciseId, c.WorkoutId });

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplyAuditInformation()
            => this.ChangeTracker
            .Entries()
            .ForEach(entry =>
            {
                var userName = this.currentUser.GetName();

                if (entry.Entity is IDeletableEntity deletableEntity)
                {
                    if (entry.State == EntityState.Deleted)
                    {
                        deletableEntity.DeletedOn = DateTime.UtcNow;
                        deletableEntity.DeletedBy = userName;
                        deletableEntity.IsDeleted = true;

                        entry.State = EntityState.Modified;

                        return;
                    }
                }

                if (entry.Entity is IEntity entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedOn = DateTime.UtcNow;
                        entity.CreatedBy = userName;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entity.ModifiedBy = userName;
                        entity.ModifiedOn = DateTime.UtcNow;
                    }
                }
            });
    }
}
