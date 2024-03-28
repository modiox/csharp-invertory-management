using System; 

namespace  StoreManagement {

    public class Item
{
    public string? Name { get; }
    private int quantity;
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
    public DateTime CreatedDate { get; }

    private DateTime DateCreated { get; set; }
    //Constructor parameter 
    public Item(string name, int quantity, DateTime dateCreated = default)
    {
        if (quantity < 0)
        {
            Console.WriteLine("Quantity cannot be negative");
        }
        Name = name;
        Quantity = quantity;
        CreatedDate = dateCreated != default ? dateCreated : DateTime.Now;


    }

    //To define how the object itmes are represented
    public override string ToString()
    {
        return $"Item Name: {Name}, Item Quanitity: {Quantity}, Date Created: {CreatedDate}";
    }

}

}

