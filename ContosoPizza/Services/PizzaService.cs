using ContosoPizza.Data;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public class PizzaService
    {
        private readonly PizzaContext _context = default!;

        public PizzaService(PizzaContext context) 
        {
            _context = context;
        }
        
        public IList<Pizza> GetPizzas()
        {
            if(_context.Pizzas != null)
            {
                return _context.Pizzas.ToList();
            }
            return new List<Pizza>();
        }

        public void AddPizza(Pizza pizza)
        {
            if (_context.Pizzas != null)
            {
                _context.Pizzas.Add(pizza);
                _context.SaveChanges();
            }
        }

        public void DeletePizza(int id)
        {
            if (_context.Pizzas != null)
            {
                var pizza = _context.Pizzas.Find(id);
                if (pizza != null)
                {
                    _context.Pizzas.Remove(pizza);
                    _context.SaveChanges();
                }
            }            
        } 
        
        // create a function that will compute the cost of pizza
        public decimal ComputeCost(Pizza pizza)
        {
            decimal cost = 0;
            if(pizza.Toppings != null)
            {
                foreach(var topping in pizza.Toppings)
                {
                    cost += topping.Price;
                }
            }
            cost += pizza.Size.Price;
            return cost;
        }
        
        
        //compute the number of pizzas in the inventory
        public int ComputeInventory()
        {
            
            int inventory = 0;
            if (_context.Pizzas != null)
            {
                inventory = _context.Pizzas.Count();
            }
            return inventory;
        }
        
    }
}
