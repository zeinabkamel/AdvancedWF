using AdvancedWf.Data.Configuration;
using AdvancedWf.Model;
using AdvancedWf.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedWf.Data
{
    public class AdvancedWfContext :DbContext
    {
        public AdvancedWfContext() : base("AdvancedWfEntities") { }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkflowTypes> WorkflowTypes { get; set; }
        public DbSet<WorkflowEngineTypes> workflowEngineTypes { get; set; }
        public static AdvancedWfContext Create()
        {
            return new AdvancedWfContext();
        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GadgetConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
