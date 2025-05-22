using Eticaret.Models;

namespace Eticaret.Services
{
    public class ComputerService : IComputerService
    {
        private List<Computer> _computers = new()
        {
            new Computer{ Id=1,Name="Lonovo",Description="i7, 16GB RAM, 512GB SSD, 2GB Ekran Kartı",Price=57542,ImageUrl="/images/lenova.jpg"},
            new Computer{Id=2,Name="Mac Book",Description = "i8,16GB RAM.....",Price=59999,ImageUrl="/images/macbook.jpg"},
            new Computer{Id=3,Name="HP",Description="i9 işlemci, 64GB RAM",Price=65000,ImageUrl="/images/HP.jpg"},
            new Computer{Id=4,Name = "Casper",Description="Excalibur......", Price=25555,ImageUrl="/images/Casper.jpg"}
        };
        public List<Computer> GetAll() => _computers;
        public Computer GetById(int id) => _computers.FirstOrDefault(x => x.Id == id);





        //public List<Computer> GetAll()
        //{
        //    return _computers;
        //}
        //public Computer GetById(int id)
        //{
        //    return _computers.FirstOrDefault(x => x.Id == id);
        //}


    }
}
