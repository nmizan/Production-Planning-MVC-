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
    
    public partial class PRP_ASSIGNDET
    {
        public int ASSIGNCD { get; set; }
        public short ASSIGNDETCD { get; set; }
        public int MODCD { get; set; }
        public short MACQTY { get; set; }
        public byte MACEFF { get; set; }
        public System.DateTime STARTDATE { get; set; }
        public System.DateTime ENDDATE { get; set; }
        public decimal DAYS { get; set; }
        public int ASSIGNQTY { get; set; }
        public byte UNITCD { get; set; }
        public short INSERTBY { get; set; }
        public System.DateTime INSERTDT { get; set; }
        public Nullable<short> UPDATEBY { get; set; }
        public Nullable<System.DateTime> UPDATEDT { get; set; }
    
        public virtual MER_UNIT MER_UNIT { get; set; }
        public virtual PRP_ASSIGNMAS PRP_ASSIGNMAS { get; set; }
        public virtual PRP_MODULE PRP_MODULE { get; set; }
    }
}
