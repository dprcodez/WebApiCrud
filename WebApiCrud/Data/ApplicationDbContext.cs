using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiCrud.Models;

namespace WebApiCrud.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("WebApiCrudDBConn") { }
        public DbSet<Student> Students { get; set; }

    }
}