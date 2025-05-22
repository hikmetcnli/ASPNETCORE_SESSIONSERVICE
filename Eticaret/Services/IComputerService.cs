using Eticaret.Models;

namespace Eticaret.Services
{
    public interface IComputerService
    {
        List<Computer> GetAll();
        Computer GetById(int id);

    }
}
