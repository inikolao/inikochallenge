using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InikoChallenge.Models.Data;

namespace InikoChallenge.Models.Data.Contex
{
    public class DataContexInCh : DbContext
    {
        public DataContexInCh (DbContextOptions<DataContexInCh> options)
            : base(options)
        {
        }

        public DbSet<InikoChallenge.Models.Data.Employees> Employees { get; set; }

        public DbSet<InikoChallenge.Models.Data.Skills> Skills { get; set; }

        public DbSet<InikoChallenge.Models.Data.EmplSkills> EmplSkills { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelbuilder)
        //{
        //    modelbuilder.Entity<Employees>().HasKey(bc => new { bc.ID });
        //    modelbuilder.Entity<Skills>().HasKey(bc => new { bc.ID });
        //    modelbuilder.Entity<EmplSkills>().HasOne(b => b.SkillID).WithMany(bg => bg.Categories).HasForeignKey(bc => bc.begripId);

        //}
    }
}
