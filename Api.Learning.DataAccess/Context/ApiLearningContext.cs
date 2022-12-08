﻿using Api.Learning.DataAccess.Entities.Base;
using Api.Learning.DataAccess.Entities.Course;
using Api.Learning.DataAccess.Entities.Student;
using Api.Learning.DataAccess.Entities.Teacher;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Learning.DataAccess.Context
{
    public class ApiLearningContext : DbContext
    {
        public DbSet<StudentEntity> StudentEntity { get; set; }
        public DbSet<TeacherEntity> TeacherEntity { get; set; }
        public DbSet<CourseEntity> CourseEntity { get; set; }
        public ApiLearningContext(DbContextOptions<ApiLearningContext> options) :
            base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
