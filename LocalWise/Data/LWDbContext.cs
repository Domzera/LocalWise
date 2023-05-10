using LocalWise.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocalWise.Data
{
    public class LWDbContext : IdentityDbContext<Pessoa>
    {
        public LWDbContext(DbContextOptions<LWDbContext> options) : base(options) { }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<ComentarioAvaliacao> ComentarioAvaliacaos  { get; set; }
        public DbSet<DetalheGuia> DetalheGuias { get; set; }
        public DbSet<DetalhesTurista> DetalhesTuristas { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<GerenteLocal> GerenteLocals { get; set; }
        public DbSet<Guia> Guias { get; set; }
        public DbSet<Itinerario> Itinerarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PontoTuristico> PontoTuristicos { get; set; }
        public DbSet<Turista> Turistas { get; set; }
    }
}
