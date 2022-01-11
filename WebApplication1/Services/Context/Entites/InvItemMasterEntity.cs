using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSBOWeb.Services.Context.Entites
{
    [Table("MstInvItemMaster")]
    public class InvItemMasterEntity
    {
        [Key]
        public int MstInvItemNo { get; set; }
        public string Description { get; set; }
    }

    [Table("MstPOSPrinterPrep")]
    public class MasterPOSPrinterPrepEntity
    {
        [Key]
        public int POSLogicID { get; set; }
        public string Printer_Desc { get; set; }
    }
    [Table("Fb_itemPrinter")]
    public class ItemPrinterEntity
    {
        [Key]
        public int ID { get; set; }
        public int LocationID { get; set; }
        public int ItemID { get; set; }
        public int PrinterID { get; set; }
        public int MstLocationID { get; set; }
    }


    
}
