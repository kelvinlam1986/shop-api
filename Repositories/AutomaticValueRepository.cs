using System;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class AutomaticValueRepository : IAutomaticValueRepository
    {
        private ShopContext _context;

        public AutomaticValueRepository(ShopContext context)
        {
            this._context = context;
        }

        public AutomaticValue GetAutoId(string tableName)
        {
            return this._context.AutomaticValues.Find(tableName);
        }

        public bool UpdateLastAutoId(string tableName, string lastAutoId)
        {
            try
            {
                var auto = this._context.AutomaticValues.Find(tableName);
                if (auto == null)
                {
                    return false;
                }

                auto.LastValueOfColumnId = lastAutoId;
                this._context.AutomaticValues.Update(auto);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}