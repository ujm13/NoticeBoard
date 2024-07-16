using Microsoft.EntityFrameworkCore;
using NoticeBoard.Repository.Configurations;
using NoticeBoard.Repository.Entities;

namespace NoticeBoard.Repository.Db;

/// <summary>
/// NoticeBoardDbContext
/// </summary>
public class NoticeBoardDbContext : DbContext
{
    public NoticeBoardDbContext(DbContextOptions<NoticeBoardDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// OnModelCreating
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
        modelBuilder.ApplyConfiguration(new AnnouncementConfigurations());
        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Announcements
    /// </summary>
    public virtual DbSet<Announcement> Announcements { get; set; }
}