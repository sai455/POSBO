using Microsoft.EntityFrameworkCore;
using POSBOWeb.Models;
using POSBOWeb.Services.Context;
using POSBOWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POSBOWeb.Services.Implementations
{
    public class ItemMasterService : IItemMasterService
    {
        private readonly PosboDBContext _context;
        public ItemMasterService(PosboDBContext context) => _context = context;
        public List<InvMasterDTO> GetItemMasterList(string serachParam = null)
        {
            var retData=new List<InvMasterDTO>();
            try{
                string query = "select MstInvItemNo,Description from MstInvItemMaster where Isactive=1";
                if (!string.IsNullOrEmpty(serachParam))
                {
                    query += $" and Description like '%{serachParam.ToLower()}%'";
                }
                retData = _context.InvItemMasters.FromSqlRaw(query).Select(x => new InvMasterDTO
                {
                    ItemNo = x.MstInvItemNo,
                    Description = x.Description
                }).ToList();

            }
            catch (Exception ex)
            {

            }
            return retData;
        }
        public List<PrinterDTO> GetMasterPrinterPrep(int itemId)
        {
            var retData = new List<PrinterDTO>();
            try
            {
                string query = $"select Distinct mp.POSLogicID, mp.Printer_Desc as Description,IIF(itp.ID is null, CAST (0 AS bit),CAST (1 AS bit)) IsItemPrinter from MstPOSPrinterPrep mp Left Join Fb_itemPrinter itp on itp.PrinterID=mp.PrimaryPrinterID and itp.ItemId={itemId}";
                retData = _context.PrinterDTOs.FromSqlRaw(query).ToList();

            }
            catch (Exception ex)
            {

            }
            return retData;
        }
        public bool SavePrintArea(List<int> ids, int itemId)
        {
            var itemsInDb = _context.ItemPrinters.Where(x => x.ItemID == itemId).ToList();
            try
            {
                if (itemsInDb.Any())
                {
                    _context.ItemPrinters.RemoveRange(itemsInDb);
                    _context.SaveChanges();
                }
                foreach (var p in ids)
                {
                    _context.ItemPrinters.Add(new Context.Entites.ItemPrinterEntity
                    {
                        LocationID = 1,
                        ItemID = itemId,
                        PrinterID = p,
                        MstLocationID = 1
                    });
                }
                if (ids.Any())
                    _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            
            return true;
        }
    }
}
