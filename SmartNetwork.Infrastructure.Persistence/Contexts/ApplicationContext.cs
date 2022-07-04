using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SmartNetwork.Core.Application.Helpers;
using SmartNetwork.Core.Application.ViewModel.Users;
using SmartNetwork.Core.Domain.Common;
using SmartNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartNetwork.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IHttpContextAccessor httpContextAccessor) : base(options) { _httpContextAccessor = httpContextAccessor; }

        public DbSet<User> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Friend> Friends { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Username!=null? _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Username : "DefaultUserApp";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Username!=null? _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Username : "DefaultUserApp";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Fluent API
            #region Tables
            modelBuilder
                .Entity<User>()
                .ToTable("Users");

            modelBuilder
                .Entity<Posts>()
                .ToTable("Posts");

            modelBuilder
                .Entity<Like>()
                .ToTable("Like");

            modelBuilder
                .Entity<Comment>()
                .ToTable("Comments");

            modelBuilder
                .Entity<Friend>()
                .ToTable("Friends");
            #endregion

            #region Primary Key

            modelBuilder
                .Entity<User>()
                .HasKey(user=>user.Id);

            modelBuilder
                .Entity<Posts>()
                .HasKey(post=>post.Id);

            modelBuilder
                .Entity<Like>()
                .HasKey(like=>like.Id);

            modelBuilder
                .Entity<Comment>()
                .HasKey(comment => comment.Id);

            modelBuilder
                .Entity<Friend>()
                .HasKey(friend=>friend.Id);

            #endregion


            #region RelationShips

            modelBuilder.Entity<User>()
                .HasMany(user => user.Posts)
                .WithOne(post => post.User)
                .HasForeignKey(post=>post.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<User>()
                .HasMany(user => user.Comments)
                .WithOne(comment => comment.User)
                .HasForeignKey(comment=>comment.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<User>()
                .HasMany(user => user.Likes)
                .WithOne(Like => Like.User)
                .HasForeignKey(Like=>Like.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(user => user.FriendsByYou)
                .WithOne(friend => friend.UserFrom)
                .HasForeignKey(friend => friend.UserFirst)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<User>()
                .HasMany(user => user.FriendsByOther)
                .WithOne(friend => friend.UserTo)
                .HasForeignKey(friend => friend.UserSecond)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Posts>()
                .HasMany(post=>post.Likes)
                .WithOne(like=>like.Posts)
                .HasForeignKey(like=>like.PostId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Posts>()
                .HasMany(post=>post.Comments)
                .WithOne(comment=>comment.Posts)
                .HasForeignKey(comment=>comment.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Properties Configuration

            #region Users

            modelBuilder
                .Entity<User>()
                .Property(user => user.Name)
                .IsRequired();

            modelBuilder
                .Entity<User>()
                .Property(user => user.LastName)
                .IsRequired();

            modelBuilder
                .Entity<User>()
                .Property(user => user.Email)
                .IsRequired();

            modelBuilder
                .Entity<User>()
                .Property(user => user.Phone)
                .IsRequired();
            
            modelBuilder
                .Entity<User>()
                .Property(user => user.Username)
                .IsRequired();
            
            modelBuilder
                .Entity<User>()
                .Property(user => user.Password)
                .IsRequired();

            #endregion

            #region Post

            modelBuilder
                .Entity<Posts>()
                .Property(post => post.Body)
                .IsRequired();

            #endregion

            #region Comments

            modelBuilder
                .Entity<Comment>()
                .Property(comment => comment.Body)
                .IsRequired();

            #endregion

            #endregion
        }
    }
}
