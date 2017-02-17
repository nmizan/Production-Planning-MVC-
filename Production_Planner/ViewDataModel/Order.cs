
using System;
namespace Production_Planner.ViewDataModel
{
    public class Order
    {
        
        public int ORDSLNO { get; set; }
        public string SKETCHNO { get; set; }
        public Nullable<short> LCYEAR { get; set; }
        public Nullable<int> LCSLNO { get; set; }
        public string STYLENO { get; set; }
        public short COMPCD { get; set; }
        public byte GAUGECD { get; set; }
        public string ORDTYPE { get; set; }
        public string ORDMETHOD { get; set; }
        public string ORDFLAG { get; set; }
        public string STATUS { get; set; }
        public string FLAGIMG { get; set; }
        public string REMARKS { get; set; }
        public short INSERTBY { get; set; }
        public System.DateTime INSERTDT { get; set; }

        public Models.MER_ORDERDET mer_Order_Det { get; set; }


    }
}