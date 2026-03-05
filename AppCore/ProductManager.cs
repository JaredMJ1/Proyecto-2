using DataAccess.CRUD;
using Entities.DTO;

namespace Core.Managers
{
    public class ProductManager : BaseManager
    {
        public void Create(ProductDTO p)
        {
            try
            {
                if (string.IsNullOrEmpty(p.Name))
                    throw new Exception("El nombre es requerido.");

                if (p.Price <= 0)
                    throw new Exception("El precio debe ser mayor a 0.");

                var crud = new ProductCrudFactory();
                crud.Create(p);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public void Update(ProductDTO p)
        {
            try
            {
                var crud = new ProductCrudFactory();
                crud.Update(p);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var crud = new ProductCrudFactory();
                crud.Delete(id);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public List<ProductDTO> RetrieveAll()
        {
            var list = new List<ProductDTO>();

            try
            {
                var crud = new ProductCrudFactory();
                list = crud.RetrieveAll<ProductDTO>();
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }

            return list;
        }

        public ProductDTO RetrieveById(int id)
        {
            var product = new ProductDTO();

            try
            {
                var crud = new ProductCrudFactory();
                product = crud.RetrieveById<ProductDTO>(id);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }

            return product;
        }
    }
}