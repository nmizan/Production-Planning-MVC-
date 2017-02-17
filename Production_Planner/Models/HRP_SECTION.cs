//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Production_Planner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class HRP_SECTION
    {
        public HRP_SECTION()
        {
            this.MER_CP = new HashSet<MER_CP>();
            this.MER_CP_ORDER = new HashSet<MER_CP_ORDER>();
            this.MER_ORDER_CATEGORY = new HashSet<MER_ORDER_CATEGORY>();
            this.MER_SMV = new HashSet<MER_SMV>();
            this.PRP_ASSIGNMAS = new HashSet<PRP_ASSIGNMAS>();
            this.PRP_MODULE = new HashSet<PRP_MODULE>();
            this.PRP_PRODMAS = new HashSet<PRP_PRODMAS>();
        }
    
        public byte SECCODE { get; set; }
        [DisplayName("Section Name")]
        public string SECNAME { get; set; }
        public string SECNMBG { get; set; }
        public string SECFLOOR { get; set; }
        public string PRSYMBOL { get; set; }
        public byte PSLNO { get; set; }
        public short INSERTBY { get; set; }
        public System.DateTime INSERTDT { get; set; }
        public Nullable<short> UPDATEBY { get; set; }
        public Nullable<System.DateTime> UPDATEDT { get; set; }
        public Nullable<byte> LAGGING_SLNO { get; set; }
        public string LAGGING_HEADING { get; set; }
    
        public virtual ICollection<MER_CP> MER_CP { get; set; }
        public virtual ICollection<MER_CP_ORDER> MER_CP_ORDER { get; set; }
        public virtual ICollection<MER_ORDER_CATEGORY> MER_ORDER_CATEGORY { get; set; }
        public virtual ICollection<MER_SMV> MER_SMV { get; set; }
        public virtual ICollection<PRP_ASSIGNMAS> PRP_ASSIGNMAS { get; set; }
        public virtual ICollection<PRP_MODULE> PRP_MODULE { get; set; }
        public virtual ICollection<PRP_PRODMAS> PRP_PRODMAS { get; set; }
    }
}
