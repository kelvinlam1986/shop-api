using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories {
    public class BranchRepository : IBranchRepository {

        private ShopContext _context;

        public BranchRepository (ShopContext context) {
            this._context = context;
        }

        public Branch GetBranchByName (string name) {
            return this._context.Branches.FirstOrDefault (x => x.Name == name);
        }
    }
}