using System.Data;

namespace PetManagement.Business.Interface
{
    public interface IPetService
    {
        DataTable FindAll();
    }
}
