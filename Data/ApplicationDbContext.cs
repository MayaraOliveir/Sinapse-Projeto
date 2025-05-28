using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sinapse.Models;

namespace Sinapse.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Community> Communities { get; set; }
    public DbSet<DirectMessage> DirectMessages { get; set; }
    public DbSet<Connection> Connections { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<SkillSwap> SkillSwaps { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Renomeia as tabelas do Identity para português
        builder.Entity<ApplicationUser>().ToTable("Usuarios");
        builder.Entity<IdentityRole>().ToTable("Funcoes");
        builder.Entity<IdentityUserRole<string>>().ToTable("UsuariosFuncoes");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UsuariosReivindicacoes");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UsuariosLogins");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("FuncoesReivindicacoes");
        builder.Entity<IdentityUserToken<string>>().ToTable("UsuariosTokens");

        // Configura as tabelas do domínio
        builder.Entity<Post>().ToTable("Publicacoes");
        builder.Entity<Comment>().ToTable("Comentarios");
        builder.Entity<Like>().ToTable("Curtidas");
        builder.Entity<Community>().ToTable("Comunidades");
        builder.Entity<DirectMessage>().ToTable("MensagensDiretas");
        builder.Entity<Connection>().ToTable("Conexoes");
        builder.Entity<Notification>().ToTable("Notificacoes");
        builder.Entity<SkillSwap>().ToTable("TrocasConhecimento");

        // Configurações de índices
        builder.Entity<ApplicationUser>()
            .HasIndex(u => u.Email)
            .IsUnique();

        builder.Entity<Community>()
            .HasIndex(c => c.Hashtag)
            .IsUnique();

        builder.Entity<Post>()
            .HasIndex(p => p.CreatedAt);

        builder.Entity<DirectMessage>()
            .HasIndex(dm => new { dm.SenderId, dm.ReceiverId });

        builder.Entity<SkillSwap>()
            .HasIndex(ss => new { ss.RequesterId, ss.AddresseeId });

        // Configurações de relacionamentos

        // Post -> User (Autor)
        builder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Post -> Community
        builder.Entity<Post>()
            .HasOne(p => p.Community)
            .WithMany(c => c.Posts)
            .HasForeignKey(p => p.CommunityId)
            .OnDelete(DeleteBehavior.SetNull);

        // Comment -> Post
        builder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        // Comment -> User (Autor)
        builder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Like -> Post
        builder.Entity<Like>()
            .HasOne(l => l.Post)
            .WithMany(p => p.Likes)
            .HasForeignKey(l => l.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        // Like -> User
        builder.Entity<Like>()
            .HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // DirectMessage -> User (Sender)
        builder.Entity<DirectMessage>()
            .HasOne(m => m.Sender)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        // DirectMessage -> User (Receiver)
        builder.Entity<DirectMessage>()
            .HasOne(m => m.Receiver)
            .WithMany(u => u.ReceivedMessages)
            .HasForeignKey(m => m.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        // Connection -> User (Requester)
        builder.Entity<Connection>()
            .HasOne(c => c.Requester)
            .WithMany(u => u.RequestedConnections)
            .HasForeignKey(c => c.RequesterId)
            .OnDelete(DeleteBehavior.Restrict);

        // Connection -> User (Addressee)
        builder.Entity<Connection>()
            .HasOne(c => c.Addressee)
            .WithMany(u => u.ReceivedConnections)
            .HasForeignKey(c => c.AddresseeId)
            .OnDelete(DeleteBehavior.Restrict);

        // SkillSwap -> User (Requester)
        builder.Entity<SkillSwap>()
            .HasOne(ss => ss.Requester)
            .WithMany(u => u.RequestedSkillSwaps)
            .HasForeignKey(ss => ss.RequesterId)
            .OnDelete(DeleteBehavior.Restrict);

        // SkillSwap -> User (Addressee)
        builder.Entity<SkillSwap>()
            .HasOne(ss => ss.Addressee)
            .WithMany(u => u.ReceivedSkillSwaps)
            .HasForeignKey(ss => ss.AddresseeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Community -> User (Creator)
        builder.Entity<Community>()
            .HasOne(c => c.CreatedByUser)
            .WithMany(u => u.CreatedCommunities)
            .HasForeignKey(c => c.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Notification -> User
        builder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
