using aec_gama_api.Models;
using gama_aec.Models;
using Microsoft.EntityFrameworkCore;


namespace gama_aec.Servico
{

    public class DbContexto : DbContext
{
    public DbContexto(DbContextOptions<DbContexto> options) : base (options) { }

    public DbSet<Candidato> Candidatos { get; set; }
    public DbSet<Profissao> Profissoes { get; set; }
  }
}