using System;
class Vehicle{
	public string Brand { get; set; }
	public string Model { get; set; }
	public int Year { get; set; }
	public Vehicle(string brand, string model, int year){
		Brand = brand;
		Model = model;
		Year = year;
	}
	public virtual void VehicleInfo(){
		Console.WriteLine($"{Year} {Brand} {Model}");
	}
	public void StartEngine(){
		Console.WriteLine("Engine started");
	}
}
class Car : Vehicle{
	public int Doors { get; set; }
	public Car(string brand, string model, int year, int doors): base(brand, model, year){
		Doors = doors;
	}
	public override void VehicleInfo(){
		Console.WriteLine($"{Year} {Brand} {Model} with {Doors} doors");
	}
	public void OpenTrunk(){
		Console.WriteLine("Trunk opened");
	}
}
class Bike : Vehicle{
	public string BikeType { get; set; }
	public Bike(string brand, string model, int year, string bikeType): base(brand, model, year){
		BikeType = bikeType;
	}
	public override void VehicleInfo(){
		Console.WriteLine($"{Year} {Brand} {Model} - {BikeType} bike");
	}
	public void DoWheelie(){
		Console.WriteLine("Doing a wheelie!");
	}
}
class Program{
	static void Main(){
		Car myCar = new Car("Toyota", "Corolla", 2023, 4);
		Bike myBike = new Bike("Yamaha", "R1", 2022, "Sport");

		myCar.VehicleInfo();  // Overridden method
		myCar.StartEngine();  // Inherited method
		myCar.OpenTrunk();    // Car-specific method

		myBike.VehicleInfo();  // Overridden method
		myBike.StartEngine();  // Inherited method
		myBike.DoWheelie();    // Bike-specific method
	}
}
