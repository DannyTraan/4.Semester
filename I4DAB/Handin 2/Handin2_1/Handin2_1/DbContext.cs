using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Handin2_1
{
    public class DbContext : System.Data.Entity.DbContext
    {
        #region Properties

        public DbSet<Person> Personer { get; set; }
        public DbSet<Adresse> Adresser { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Telefon> Telefoner { get; set; }
        public DbSet<ZIP> Zips { get; set; }
        public DbSet<ZIPListe> ZipLister { get; set; }
        public DbSet<AA> AAs { get; set; }
        #endregion
    }
}