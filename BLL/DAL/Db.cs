﻿
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genres> Genre { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public Db(DbContextOptions options) : base(options) { }
    }
}
