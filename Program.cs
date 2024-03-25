using System;
using System.Collections.Generic;
using System.Linq;
using static Program;

public enum SortOrder
{
    ASC,
    DESC
}
public class Program { 
    public class Item { 
        public string? Name { get; }
        private int Quantity;
        public int quantity { 
            get {return Quantity; }
            set{Quantity = value; }
        }
        public DateTime CreatedDate { get; }

        private DateTime DateCreated { get; set; }
          //Constructor parameter 
        public Item(string name, int quantity, DateTime dateCreated = default) { 
            if(Quantity < 0){ 
                Console.WriteLine("Quantity cannot be negative");
            }
            Name= name; 
            Quantity = quantity; 
            DateCreated = dateCreated == default ? DateTime.Now : dateCreated;

        }
         public override string ToString(){
         return $"Item Name: {Name}, Item Quanitity: {Quantity}, Date Created: {DateCreated}";
         }

    }

    public class Store {
      private List<Item> items = new List<Item>();

    public int MaxCapacity { get; }
    public void AddItem(Item item) {
        //Do not add if it already exists
        bool itemExists = items.Any((i) => i.Name == item.Name);
        if(itemExists)
        {
            Console.WriteLine($"Item with name '{item.Name}' already exists in the store.");
            return;
        }

        items.Add(item);

        // if (item.Count < MaxCapacity)
        // {
        //     item.Add(item);
        //     Console.WriteLine($"Item '{item.Name}' added successfully.");
        // }
        // else
        // {
        //     Console.WriteLine($"Store is at maximum capacity. Cannot add '{item.Name}'.");
        // }
    }
    public void DeleteItem(string itemName) {
        //Find the item then remove 
       Item DeleteItem = items.FirstOrDefault(i => i.Name == itemName);
       if(DeleteItem != null) { 
        items.Remove(DeleteItem);
        Console.WriteLine("Item is deleted..");
       }
       else 
       { Console.WriteLine("Item not found"); }

    }
     public Item FindItemByName(string itemName) {
        //Find the item then remove 
       Item ItemFound = items.FirstOrDefault(i => i.Name == itemName);
       if(ItemFound != null) { 
        Console.WriteLine( $"Item Found {ItemFound} "); 
        return ItemFound;
        
       }
       else 
       { Console.WriteLine("Item not found"); 
       return null; } //if I don't include this, it causes an error in the function name(: not all code paths return a value)

    }
     public int GetCurrentVolume(){
        return items.Sum(i => i.quantity);
    } 
      public List<Item> SortByNameAsc()
    {
        return items.OrderBy(i => i.Name).ToList();
    }

    public List<Item> SortByDate(SortOrder order)
    {
        if (order == SortOrder.ASC)
            return items.OrderBy(i => i.CreatedDate).ToList();
        else
            return items.OrderByDescending(i => i.CreatedDate).ToList();
    }
    public void PrintItems() {
        foreach( var item in items){ 
            Console.WriteLine(item); 
        }

    }

    }


     public class MyClass { 
     public static void Main(string [] args) { 
        var waterBottle = new Item ("Water Bottle", 10, new DateTime (2023, 1, 1));
        var waterBottle2 = new Item ("Water Gallon", 14, new DateTime (2023, 1, 1));
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
        var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
        var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
        var coffee = new Item("Coffee", 20);
        var sandwich = new Item("Sandwich", 15);
        var batteries = new Item("Batteries", 10);
        var umbrella = new Item("Umbrella", 5);
        var sunscreen = new Item("Sunscreen", 8);
        // Console.WriteLine($"Item {waterBottle}");
        var store = new Store();
        store.AddItem(waterBottle);
        store.AddItem(waterBottle2);
        store.AddItem(coffee);
        store.AddItem(pen);
       // store.DeleteItem("Water Gallon");
        store.PrintItems();
       var volume= store.GetCurrentVolume();
        Console.WriteLine($"The voulme is == {volume}");
       // store.FindItemByName("Water Gallon");
        var collections =store.SortByNameAsc();
        foreach(var item in collections){  
            Console.WriteLine($"Sorted ASC: {item}");


        }
       

        
       
  }
}
 

}
