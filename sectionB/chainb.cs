using System;
class Device{
    public string id;
    public Device(string deviceId){
        id = deviceId;
        Console.WriteLine("Device initialized");
    }
}
class Sensor : Device{
    public string type;
    public Sensor(string deviceId, string sensorType) : base(deviceId){
        type = sensorType;
        Console.WriteLine("Sensor initialized");
    }
}
class program{
    static void Main(string[] args){
        Sensor s = new Sensor("D001", "Temperature");
    }
}