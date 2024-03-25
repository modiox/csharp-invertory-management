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
        public int Quantity { get; set; }

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
        // Console.WriteLine($"Item {waterBottle}");
        var store = new Store();
        store.AddItem(waterBottle);
        store.AddItem(waterBottle2);
        store.PrintItems();


        
       
  }
}
 

}
