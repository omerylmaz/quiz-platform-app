﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Users.Application.Abstractions.Data;
using Users.Domain.Users;

namespace Users.Infrastructure.Database;

public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.HasDefaultSchema(Schemas.Users);
    }
}
