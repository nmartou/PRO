using System;

abstract class Car {
    protected float fuel;
    protected float maxFuel;
    protected float maxSpeed;
    protected string color = "";
    protected string name = "";
    protected string brand = "";

    public abstract string NameCar();

    public float widthdrawnFuel(float quantityFuelToWithdraw) {
        if(quantityFuelToWithdraw > this.fuel) return -1f;
        return this.fuel -= quantityFuelToWithdraw;
    }

    public float addFuel(float fuelToAdd) {
        return this.fuel += fuelToAdd;
    }
}

class Porsche : Car {

    public new string brand;
    public Porsche(string name, string color, float maxFuel, float fuel, float maxSpeed) {
        this.brand = "Porsche";
        this.name = name;
        this.maxSpeed = maxSpeed;
        this.color = color;
        this.fuel = fuel;
    }

    public override string NameCar() {
        return "This car's name is " + this.name;
    }
}

class Program {
    static void Main() {
        Porsche porsche911 = new Porsche("911", "red", 50f, 5f, 230f);
        Console.WriteLine("Hello World!");
        Console.WriteLine(porsche911.NameCar());
        Console.WriteLine(porsche911.brand);
    }
}