using LZY.Model.ApplicationManagement;
using LZY.Model.ApplicationOrganization;
using LZY.Model.Attachments;
using LZY.Model.BusinessManegement.Audit;
using LZY.Model.WebSettingManagement;
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

        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        #endregion

        #region 用户工作区与菜单相关
        public DbSet<SystemWorkPlace> SystemWorkPlaces { get; set; }
        public DbSet<WorkPlaceCategory> WorkPlaceCategory { get; set; }
        #endregion

        #region 一些基础业务对象相关
        public DbSet<AuditRecord> AuditRecords { get; set; }
        public DbSet<BusinessFile> BusinessFiles { get; set; }
        public DbSet<BusinessImage> BusinessImages { get; set; }
        public DbSet<BusinessVideo> BusinessVideos { get; set; }
        public DbSet<WebSiteSettings> WebSiteSittings { get; set; }
        public DbSet<WebIdentityServer> WebIdentityServers { get; set; }
        public DbSet<RsaKey> RsaKeys { get; set; }
        

        #endregion


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
