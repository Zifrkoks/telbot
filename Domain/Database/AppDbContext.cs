using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using telbot.Domain.Database.Models;

namespace telbot.Domain.Database
{
    public class AppDbContext: DbContext
    {
    public DbSet<ChatUser> Users {get;set;}= null!;
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
        Database.EnsureCreated();// создаем базу данных при первом обращении
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=newsapp.db");
        optionsBuilder.LogTo(Console.WriteLine);

    }
}
}