using POSBOWeb.Models;
using System.Collections.Generic;

namespace POSBOWeb.Services.Interfaces
{
    public interface IItemMasterService
    {
        List<InvMasterDTO> GetItemMasterList(string serachParam = null);
        List<PrinterDTO> GetMasterPrinterPrep(int itemId);
        bool SavePrintArea(List<int> ids, int itemId);
    }
}
