using Eticaret.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Eticaret.Services
{
    public class CartService
    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        private const string CartKey = "Cart";
        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<CartItem> GetCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var json = session.GetString(CartKey);

            return string.IsNullOrEmpty(json) ? new List<CartItem>() : JsonSerializer.Deserialize<List<CartItem>>(json);

        }

        public void AddToCart(Computer computer)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.computer_.Id == computer.Id);

            if (item != null)
            { 
                item.Qunatity++;
            }
            else
            {
                cart.Add(new CartItem { computer_ = computer, Qunatity = 1 });
            }

            SaveCart(cart);
        }

        //public void DeleteCart(Computer computer) {
        //    var cart = GetCart();
        //    var item = cart.FirstOrDefault(x => x.computer_.Id == computer.Id);

        //    if (item != null)
        //    {
        //        cart.Remove(item);
        //        SaveCart(cart);
        //    } 
        //}

         
        public void SaveCart(List<CartItem> cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var json = JsonSerializer.Serialize(cart);
            session.SetString(CartKey, json); 
        }

        public int SepettekiUrunSayisi()
        {
            var cartList = GetCart();

            int SepettekiUrunAdeti = cartList.Sum(x=>x.Qunatity);
            return SepettekiUrunAdeti;
        }
        public void UrunMiktariArttir(int ComputerID)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.computer_.Id == ComputerID);

            if (item != null)
            { 
                item.Qunatity++;
            } 

            SaveCart(cart);
        }
        public void UrunMiktariAzalt(int ComputerID)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.computer_.Id == ComputerID);

            if (item != null)
            {
                item.Qunatity--;
            }

            if (item.Qunatity <= 0)
            {
                cart.Remove(item);
            }

            SaveCart(cart);
        }

        public void SepetiSil(int ComputerID)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x=> x.computer_.Id == ComputerID);
            if (item != null) {
                cart.Remove(item);
            }

            SaveCart(cart);

        }



        //public int CountChart()
        //{
        //    var session = _httpContextAccessor.HttpContext.Session;
        //    var json = session.GetString(CartKey);

        //    return string.IsNullOrEmpty(json) ? 0 : JsonSerializer.Deserialize<List<CartItem>>(json).Count();
        //}



    }
}
