using ShopApi.Models;

namespace ShopApi.Repositories {
    public interface IBranchRepository {
        Branch GetBranchByName (string name);
    }
}