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
                    Id = 1,
                    FirstName = "Giorgi",
                    LastName = "Bezhanishvili",
                    Picture = "profilepicture.png",
                    Email = "giorgi@gmail.com",
                    Password = "0123456789"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Temp",
                    LastName = "User",
                    Picture = "temppicture.png",
                    Email = "tempuser@gmail.com",
                    Password = "1234567890"
                });
        }
    }
}
