using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class PurchaseInvoiceRepository : IPurchaseInvoiceRepository
    {
        private ShopContext _context;

        public PurchaseInvoiceRepository(ShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<PurchaseInvoiceQuery> GetPurchaseInvoicesList(int supplierId, int invoiceStatus, string username)
        {
            var connection = this._context.Database.GetDbConnection();
            var purchaseInvoiceQueryList = new List<PurchaseInvoiceQuery>();
            using (var cmd = connection.CreateCommand())
            {
                string callStore = string.Format("prcPurchaseInvoices");
                cmd.CommandText = callStore;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var param0 = cmd.CreateParameter();
                param0.ParameterName = "@SupplierId";
                param0.Value = supplierId;

                var param1 = cmd.CreateParameter();
                param1.ParameterName = "@InvoiceStatus";
                param1.Value = invoiceStatus;

                var param2 = cmd.CreateParameter();
                param2.ParameterName = "@UserName";
                param2.Value = username;

                cmd.Parameters.Add(param0);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var purchaseInvoiceQuery = new PurchaseInvoiceQuery();
                        purchaseInvoiceQuery.Approval = reader.GetInt32(0);
                        purchaseInvoiceQuery.Status = reader.GetInt32(1);
                        purchaseInvoiceQuery.InvoiceId = reader.GetString(2);
                        purchaseInvoiceQuery.InvoiceDate = reader.GetDateTime(3);
                        purchaseInvoiceQuery.SupplierId = reader.GetInt32(4);
                        purchaseInvoiceQuery.SupplierName = reader.GetString(5);
                        purchaseInvoiceQuery.CurrencyId = reader.GetString(6);
                        purchaseInvoiceQuery.CreatedBy = reader.GetString(7);
                        purchaseInvoiceQuery.ExchangeRate = reader.GetDecimal(8);
                        purchaseInvoiceQuery.Amount = reader.GetDecimal(9);
                        purchaseInvoiceQuery.DescriptionInVietNamese = reader.GetString(10);
                        purchaseInvoiceQueryList.Add(purchaseInvoiceQuery);
                    }
                }
            }

            return purchaseInvoiceQueryList;
        }
    }
}