namespace POSBOWeb.Models
{
    public class InvMasterDTO
    {
        public int ItemNo { get; set; }
        public string Description { get; set; }
    }
    public class PrinterDTO
    {
        public int PosLogicId { get; set; }
        public string Description { get; set; }
        public bool IsItemPrinter { get; set; }
    }
}
