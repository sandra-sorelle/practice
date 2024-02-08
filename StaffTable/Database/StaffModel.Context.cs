﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StaffTable.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class StaffingTableEntities : DbContext
    {
        public StaffingTableEntities()
            : base("name=StaffingTableEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Allowance> Allowance { get; set; }
        public virtual DbSet<AllowanceSize> AllowanceSize { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ExPos> ExPos { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<Signature> Signature { get; set; }
        public virtual DbSet<SignatureTabularPart> SignatureTabularPart { get; set; }
        public virtual DbSet<StaffTable> StaffTable { get; set; }
        public virtual DbSet<StaffTableTabularPart> StaffTableTabularPart { get; set; }
        public virtual DbSet<StructualDivision> StructualDivision { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }
        public virtual DbSet<StaffTable1> StaffTable1 { get; set; }
    
        [DbFunction("StaffingTableEntities", "getlinesinTable")]
        public virtual IQueryable<getlinesinTable_Result> getlinesinTable(Nullable<int> tableid)
        {
            var tableidParameter = tableid.HasValue ?
                new ObjectParameter("tableid", tableid) :
                new ObjectParameter("tableid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<getlinesinTable_Result>("[StaffingTableEntities].[getlinesinTable](@tableid)", tableidParameter);
        }
    
        public virtual int addRowInStaffTable(Nullable<int> number, Nullable<int> postid, Nullable<decimal> units, string notes)
        {
            var numberParameter = number.HasValue ?
                new ObjectParameter("number", number) :
                new ObjectParameter("number", typeof(int));
    
            var postidParameter = postid.HasValue ?
                new ObjectParameter("postid", postid) :
                new ObjectParameter("postid", typeof(int));
    
            var unitsParameter = units.HasValue ?
                new ObjectParameter("units", units) :
                new ObjectParameter("units", typeof(decimal));
    
            var notesParameter = notes != null ?
                new ObjectParameter("notes", notes) :
                new ObjectParameter("notes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addRowInStaffTable", numberParameter, postidParameter, unitsParameter, notesParameter);
        }
    
        public virtual int AddSign(Nullable<int> workerid, Nullable<int> tableid)
        {
            var workeridParameter = workerid.HasValue ?
                new ObjectParameter("workerid", workerid) :
                new ObjectParameter("workerid", typeof(int));
    
            var tableidParameter = tableid.HasValue ?
                new ObjectParameter("tableid", tableid) :
                new ObjectParameter("tableid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddSign", workeridParameter, tableidParameter);
        }
    
        public virtual int AddSignature()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddSignature");
        }
    
        public virtual int addStaffTable(Nullable<System.DateTime> dateend, Nullable<int> period, Nullable<int> signatureid)
        {
            var dateendParameter = dateend.HasValue ?
                new ObjectParameter("dateend", dateend) :
                new ObjectParameter("dateend", typeof(System.DateTime));
    
            var periodParameter = period.HasValue ?
                new ObjectParameter("period", period) :
                new ObjectParameter("period", typeof(int));
    
            var signatureidParameter = signatureid.HasValue ?
                new ObjectParameter("signatureid", signatureid) :
                new ObjectParameter("signatureid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addStaffTable", dateendParameter, periodParameter, signatureidParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int DeleteStaffTable(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteStaffTable", idParameter);
        }
    }
}