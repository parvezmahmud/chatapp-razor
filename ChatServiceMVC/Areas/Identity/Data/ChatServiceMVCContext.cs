using ChatServiceMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatServiceMVC.Data;

public class ChatServiceMVCContext : IdentityDbContext<IdentityUser>
{
    public ChatServiceMVCContext(DbContextOptions<ChatServiceMVCContext> options)
        : base(options)
    {

    }

    public DbSet<User> Users {  get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<UserMessage> UserMessages { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Message>().HasKey(x=>x.Id);
        builder.Entity<UserMessage>().HasKey(x => x.Id);
        builder.Entity<Message>().HasIndex(x => x.IndexId);
        builder.Entity<UserMessage>().HasIndex(x => x.IndexId);
    }
}
