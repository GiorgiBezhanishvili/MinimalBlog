using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public static class DatabaseInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    FirstName = "Giorgi",
                    LastName = "Bezhanishvili",
                    Picture = "profilepicture.png",
                    Email = "giorgi@gmail.com",
                    PasswordHash = "0123456789"
                },
                new User
                {
                    FirstName = "Temp",
                    LastName = "User",
                    Picture = "temppicture.png",
                    Email = "tempuser@gmail.com",
                    PasswordHash = "1234567890"
                });
        }
    }
}
