﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RADMediaService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RADDeviceMediaEntities : DbContext
    {
        public RADDeviceMediaEntities()
            : base("name=RADDeviceMediaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<SP_GetMediaDetailsForRADDevice_Result> SP_GetMediaDetailsForRADDevice(Nullable<int> rADDeviceID, Nullable<int> companyID)
        {
            var rADDeviceIDParameter = rADDeviceID.HasValue ?
                new ObjectParameter("RADDeviceID", rADDeviceID) :
                new ObjectParameter("RADDeviceID", typeof(int));
    
            var companyIDParameter = companyID.HasValue ?
                new ObjectParameter("CompanyID", companyID) :
                new ObjectParameter("CompanyID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetMediaDetailsForRADDevice_Result>("SP_GetMediaDetailsForRADDevice", rADDeviceIDParameter, companyIDParameter);
        }
    }
}
