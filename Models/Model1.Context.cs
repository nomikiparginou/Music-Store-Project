﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ChinookEntities : DbContext
    {
        public ChinookEntities()
            : base("name=ChinookEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<InvoiceStatistic> InvoiceStatistics { get; set; }
    
        public virtual ObjectResult<ReportI_Result> ReportI(Nullable<int> topNum, Nullable<System.DateTime> beginDate, Nullable<System.DateTime> endDate)
        {
            var topNumParameter = topNum.HasValue ?
                new ObjectParameter("TopNum", topNum) :
                new ObjectParameter("TopNum", typeof(int));
    
            var beginDateParameter = beginDate.HasValue ?
                new ObjectParameter("BeginDate", beginDate) :
                new ObjectParameter("BeginDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportI_Result>("ReportI", topNumParameter, beginDateParameter, endDateParameter);
        }
    
        public virtual int InvStats()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InvStats");
        }
    
        public virtual ObjectResult<ReportII_Result> ReportII(Nullable<System.DateTime> beginDate, Nullable<System.DateTime> endDate)
        {
            var beginDateParameter = beginDate.HasValue ?
                new ObjectParameter("BeginDate", beginDate) :
                new ObjectParameter("BeginDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportII_Result>("ReportII", beginDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<ReportIII_Result> ReportIII(Nullable<int> topNum)
        {
            var topNumParameter = topNum.HasValue ?
                new ObjectParameter("TopNum", topNum) :
                new ObjectParameter("TopNum", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportIII_Result>("ReportIII", topNumParameter);
        }
    
        public virtual ObjectResult<ReportIV_Result> ReportIV(Nullable<System.DateTime> beginDate, Nullable<System.DateTime> endDate)
        {
            var beginDateParameter = beginDate.HasValue ?
                new ObjectParameter("BeginDate", beginDate) :
                new ObjectParameter("BeginDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportIV_Result>("ReportIV", beginDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<ReportV_Result> ReportV(Nullable<System.DateTime> beginDate, Nullable<System.DateTime> endDate, string customerFName, string customerLName, string employeeFName, string employeeLName)
        {
            var beginDateParameter = beginDate.HasValue ?
                new ObjectParameter("BeginDate", beginDate) :
                new ObjectParameter("BeginDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var customerFNameParameter = customerFName != null ?
                new ObjectParameter("CustomerFName", customerFName) :
                new ObjectParameter("CustomerFName", typeof(string));
    
            var customerLNameParameter = customerLName != null ?
                new ObjectParameter("CustomerLName", customerLName) :
                new ObjectParameter("CustomerLName", typeof(string));
    
            var employeeFNameParameter = employeeFName != null ?
                new ObjectParameter("EmployeeFName", employeeFName) :
                new ObjectParameter("EmployeeFName", typeof(string));
    
            var employeeLNameParameter = employeeLName != null ?
                new ObjectParameter("EmployeeLName", employeeLName) :
                new ObjectParameter("EmployeeLName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportV_Result>("ReportV", beginDateParameter, endDateParameter, customerFNameParameter, customerLNameParameter, employeeFNameParameter, employeeLNameParameter);
        }
    
        public virtual ObjectResult<ReportVI_Result> ReportVI(Nullable<int> year)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportVI_Result>("ReportVI", yearParameter);
        }
    
        public virtual ObjectResult<ReportI_Result> FN_ReportI(Nullable<int> topNum, Nullable<System.DateTime> beginDate, Nullable<System.DateTime> endDate)
        {
            var topNumParameter = topNum.HasValue ?
                new ObjectParameter("TopNum", topNum) :
                new ObjectParameter("TopNum", typeof(int));
    
            var beginDateParameter = beginDate.HasValue ?
                new ObjectParameter("BeginDate", beginDate) :
                new ObjectParameter("BeginDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportI_Result>("FN_ReportI", topNumParameter, beginDateParameter, endDateParameter);
        }

        public System.Data.Entity.DbSet<WebApplication3.Models.ReportI_Result> ReportI_Result { get; set; }
        public System.Data.Entity.DbSet<WebApplication3.Models.ReportII_Result> ReportII_Result { get; set; }
        public System.Data.Entity.DbSet<WebApplication3.Models.ReportIII_Result> ReportIII_Result { get; set; }
        public System.Data.Entity.DbSet<WebApplication3.Models.ReportIV_Result> ReportIV_Result { get; set; }
        public System.Data.Entity.DbSet<WebApplication3.Models.ReportV_Result> ReportV_Result { get; set; }
        public System.Data.Entity.DbSet<WebApplication3.Models.ReportV_Result> ReportVI_Result { get; set; }
    }
}