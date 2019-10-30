using LZY.Model.ApplicationOrganization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZY.DataAccess.EntityFramework
{
   public class EntityDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// 将SchoolDbContext与数据上下文联通
        /// </summary>
        /// <param name="options"></param>
        public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options)
        {

        }

        #region 用户与角色相关
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        #endregion
        /// <summary>
        /// 生成数据库表 名称为复数
        /// </summary>
        //public DbSet<Student> Students { get; set; }


        /// <summary>
        /// 如果不需要 DbSet<T> 所定义的属性名称作为数据库表的名称，可以在下面的位置自己重新定义
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Student>().ToTable("Student"); //设置生成对应数据库表的名称
            base.OnModelCreating(modelBuilder);

        }
    }
}
