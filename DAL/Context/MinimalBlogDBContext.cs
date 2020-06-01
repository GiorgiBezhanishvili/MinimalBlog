using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class MinimalBlogDBContext : DbContext
    {
        public MinimalBlogDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User
            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(e => e.Picture)
                .HasColumnType("nvarchar(500)")
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .HasColumnType("nvarchar(50)")
                .IsRequired();
            modelBuilder.Entity<User>()
               .Property(e => e.Password)
               .HasColumnType("nvarchar(50)")
               .IsRequired();

            //Post
            modelBuilder.Entity<Post>()
               .HasKey(e => e.Id);
            modelBuilder.Entity<Post>()
               .Property(e => e.Title)
               .HasColumnType("nvarchar(50)")
               .IsRequired();
            modelBuilder.Entity<Post>()
              .Property(e => e.Content)
              .HasColumnType("nvarchar(MAX)")
              .IsRequired();
            modelBuilder.Entity<Post>()
              .Property(e => e.Thumb)
              .HasColumnType("nvarchar(100)")
              .IsRequired();
            modelBuilder.Entity<Post>()
             .Property(e => e.Date)
             .HasColumnType("smalldatetime")
             .IsRequired();
            modelBuilder.Entity<Post>()
              .Property(e => e.Category)
              .HasColumnType("nvarchar(50)")
              .IsRequired();
            modelBuilder.Entity<Post>()
                .Property(e => e.AuthorId)
                .IsRequired();

            // Connection to User table : Author
            modelBuilder.Entity<Post>()
                .HasOne(e => e.Author)
                .WithMany(e => e.Posts)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            //Comment
            modelBuilder.Entity<Comment>()
               .HasKey(e => e.Id);
            modelBuilder.Entity<Comment>()
                .Property(e => e.UserId)
                .IsRequired();
            modelBuilder.Entity<Comment>()
                .Property(e => e.PostId)
                .IsRequired();
            modelBuilder.Entity<Comment>()
             .Property(e => e.CommentText)
             .HasColumnType("nvarchar(500)")
             .IsRequired();
            modelBuilder.Entity<Comment>()
             .Property(e => e.Date)
             .HasColumnType("smalldatetime")
             .IsRequired();

            // Connection to Post table : Comments on Post
            modelBuilder.Entity<Comment>()
                .HasOne(e => e.Post)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            // Connection to User table : Comment written by some User
            modelBuilder.Entity<Comment>()
                .HasOne(e => e.User)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Seed();
        }
    }
}
