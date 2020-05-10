using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kd2020
{
    static class PodKey
    {
        public static avtoserviceEntities2 AE = new avtoserviceEntities2();
 
        public static string Roly;
    }
}
















































//    public class PodKey : DbContext
//    {
//        private string _connectionString { get; set; }
//        public DbSet<Role> Role { get; set; }

//        public PodKey()
//        : this(@"Data Source=LAPTOP-JFBLDFC0\SQLEXPRESS02;Initial Catalog=avtoservice;Integrated Security=true;")
//        {
//        }

//        public PodKey(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer(_connectionString);
//        }
//    }
//}











