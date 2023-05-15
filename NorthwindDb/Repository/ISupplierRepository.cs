using NorthwindDb.Models;

namespace NorthwindDb.Repository
{
    public interface ISupplierRepository
    {
        List<Supplier> GetAllSuppliers();
        Supplier FindSupplierById(int SupplierId);
        string CreateSupplier(Supplier supplier);
        string UpdateSupplier(Supplier supplier);
        string DeleteSupplier(int SupplierId);
    }
}
