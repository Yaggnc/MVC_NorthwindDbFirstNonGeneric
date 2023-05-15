using NorthwindDb.Models;
using NorthwindDb.Repository;

namespace NorthwindDb.Service
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly northwndContext _northwndContext;

        public SupplierRepository(northwndContext northwndContext)
        {
            _northwndContext = northwndContext;
        }

        public string CreateSupplier(Supplier supplier)
        {
            _northwndContext.Suppliers.Add(supplier);
            _northwndContext.SaveChanges();
            return "Tedarikçi eklendi!";
        }

        public string DeleteSupplier(int SupplierId)
        {
            try
            {
                var deletedId = FindSupplierById(SupplierId);
                _northwndContext.Suppliers.Remove(deletedId);
                _northwndContext.SaveChanges();
                return "Tedarikçi silindi!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _northwndContext.Suppliers.ToList();
        }

        public Supplier FindSupplierById(int SupplierId)
        {
            return _northwndContext.Suppliers.Find(SupplierId);
        }

        public string UpdateSupplier(Supplier supplier)
        {
            var updatedId = FindSupplierById(supplier.SupplierId);
            if (updatedId != null)
            {
                _northwndContext.Entry(updatedId).CurrentValues.SetValues(supplier);
                _northwndContext.SaveChanges();
                return "Tedarikçi Güncellendi!";
            }
            else
            {
                return "Tedarikçi bulunamadı!";
            }

        }
    }
}
