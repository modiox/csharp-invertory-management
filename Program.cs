using System; 

public class Program { 
    public class Item { 
        public string? Name { get; }
        public int Quantity { get; set; }

        private DateTime DateCreated { get; set; }

        public Item(string name, int quantity, DateTime dateCreated) { 
            if(Quantity < 0){ 
                Console.WriteLine("Quantity cannot be negative");
            }
            Name= name; 
            Quantity = quantity; 
            DateCreated = dateCreated; 

        }

    }

}
