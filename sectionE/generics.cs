using System;
using System.Collections.Generic;
using System.Linq;
public class Repository<T>{
    private readonly List<T> items = new List<T>();
    public void Add(T item){
        items.Add(item);
    }
    public void Update(T oldItem, T newItem) {
        int index = items.IndexOf(oldItem);
        if (index != -1){
            items[index] = newItem;
        }
    }
    public void Delete(T item){
        items.Remove(item);
    }
    public IEnumerable<T> GetAll(){
        return items;
    }
}
public class Product{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString(){
        return $"Id: {Id}, Name: {Name}";
    }
    public override bool Equals(object obj){
        if (obj is Product other)
            return this.Id == other.Id;
        return false;
    }
    public override int GetHashCode(){
        return Id.GetHashCode();
    }
}
class Program{
    static void Main(string[] args){
        Repository<Product> productRepo = new Repository<Product>();
        //add
        productRepo.Add(new Product { Id = 1, Name = "Laptop" });
        productRepo.Add(new Product { Id = 2, Name = "Phone" });
        // Update product
        var oldProduct = new Product { Id = 2, Name = "Phone" };
        var newProduct = new Product { Id = 2, Name = "Smartphone" };
        productRepo.Update(oldProduct, newProduct);
        // Delete product
        productRepo.Delete(new Product { Id = 1, Name = "Laptop" });
        // Get all products
        foreach (var product in productRepo.GetAll()){
            Console.WriteLine(product);
        }
    }
}
