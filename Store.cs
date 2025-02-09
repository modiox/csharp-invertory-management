﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement

{

    public enum SortOrder
    {
        ASC,
        DESC
    }
    public class Program
    {

        public class Store
        {
            private List<Item> items = new List<Item>();

            public int MaxCapacity { get; }
            public Store(int maxCapacity)
            {
                MaxCapacity = maxCapacity;
            }
            public void AddItem(Item item)
            {
                //Do not add if it already exists
                bool itemExists = items.Any((i) => i.Name == item.Name);
                if (itemExists)
                {
                    Console.WriteLine($"Item with name '{item.Name}' already exists in the store.");
                    return;
                }

                if (GetCurrentVolume() + item.Quantity <= MaxCapacity)
                {
                    items.Add(item);
                    Console.WriteLine($"Item '{item.Name}' added successfully.");
                }
                else
                {
                    Console.WriteLine($"Store is at maximum capacity. Cannot add '{item.Name}'.");
                }
            }
            public bool DeleteItem(string itemName)
            {
                //Find the item then remove 
                Item deleteItem = items.FirstOrDefault(i => i.Name == itemName);
                if (deleteItem != null)
                {
                    items.Remove(deleteItem);
                    Console.WriteLine($"Item is deleted: {deleteItem}");
                    return true;
                }
                else
                {
                    Console.WriteLine("Item not found");
                    return false;
                }

            }
            public Item FindItemByName(string itemName)
            {
                //Find the item then remove 
                Item ItemFound = items.FirstOrDefault(i => i.Name == itemName);
                if (ItemFound != null)
                {
                    Console.WriteLine($"Item Found: {ItemFound} ");
                    return ItemFound;
                }
                else
                {
                    Console.WriteLine("Item not found");
                    return null;
                }

            }
            public int GetCurrentVolume()
            {
                return items.Sum(i => i.Quantity);
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
            public Dictionary<string, List<Item>> GroupByDate()
            {

                var today = DateTime.Now;
                var newThresholdDate = today.AddMonths(-3); // Three months ago from today

                var newItems = items.Where(item => item.CreatedDate >= newThresholdDate).ToList();
                var oldItems = items.Where(item => item.CreatedDate < newThresholdDate).ToList();

                var groupedItems = new Dictionary<string, List<Item>> {
                         { "New Arrival", newItems },
                         { "Old", oldItems }
                 };

                return groupedItems;


            }

    
            public void PrintItems()
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }

            }

        }


        public class MyClass
        {
            public static void Main(string[] args)
            {

                //100 max capacity
                var store = new Store(100);

                var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
                var waterBottle2 = new Item("Water Gallon", 14, new DateTime(2023, 1, 1));
                var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
                var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
                var pen = new Item("Pen", 20, new DateTime(2023, 3, 1));
                var tissuePack = new Item("Tissue Pack", 30, new DateTime(2024, 1, 1));
                var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 12, 1));
                var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 12, 12));
                var soap = new Item("Soap", 12, new DateTime(2023, 8, 10));
                var shampoo = new Item("Shampoo", 40, new DateTime(2023, 12, 12));
                // var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
                // var coffee = new Item("Coffee", 20);
                // var sandwich = new Item("Sandwich", 15);
                // var batteries = new Item("Batteries", 10);
                // var umbrella = new Item("Umbrella", 5);
                // var sunscreen = new Item("Sunscreen", 8);


                //Adding items
                store.AddItem(waterBottle);
                store.AddItem(waterBottle2);
                store.AddItem(chocolateBar);
                store.AddItem(notebook);
                store.AddItem(tissuePack);

                // store.AddItem(coffee);
                // store.AddItem(pen);
                // store.AddItem(sunscreen);
                // store.AddItem(sandwich);
                // store.AddItem(umbrella);
                // store.AddItem(toothbrush);
                // store.AddItem(batteries);
                store.AddItem(shampoo);
                store.AddItem(soap);
                store.AddItem(chipsBag);
                store.AddItem(sodaCan);


                //Delete an item
                store.DeleteItem("Water Gallon");

                //Retrieve volume
                var volume = store.GetCurrentVolume();
                Console.WriteLine($"The voulme is == {volume}");


                //Finding by name
                store.FindItemByName("Coffee");

                // Sorting items by name ASC
                var collections = store.SortByNameAsc();
                foreach (var item in collections)
                {
                    Console.WriteLine($"Sorted ASC: {item}");
                }

                // Sorting items by date
                var sortedItemsByDate = store.SortByDate(SortOrder.DESC);
                Console.WriteLine("Sorted items by date:");
                foreach (var item in sortedItemsByDate)
                {
                    Console.WriteLine($"{item.Name} - {item.CreatedDate.ToShortDateString()}");
                }

                // Grouping items by date
                var groupByDate = store.GroupByDate();
                foreach (var group in groupByDate)
                {
                    Console.WriteLine($"{group.Key} Items:");
                    foreach (var item in group.Value)
                    {
                        Console.WriteLine($" - {item.Name}, Created: {item.CreatedDate.ToShortDateString()}");
                    }
                }
            }


        }


    }
}
