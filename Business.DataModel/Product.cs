//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Business.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
