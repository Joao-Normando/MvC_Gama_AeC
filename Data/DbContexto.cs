using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gama_aec.Models;

    public class DbContexto : DbContext
    {
        public DbContexto (DbContextOptions<DbContexto> options)
            : base(options)
        {
        }

        public DbSet<gama_aec.Models.Candidato> Candidato { get; set; }

        public DbSet<gama_aec.Models.Profissao> Profissao { get; set; }
    }
