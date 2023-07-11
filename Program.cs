using System;

abstract class Car {
    protected float fuel;
    protected float maxFuel;
    protected float maxSpeed;
    protected float speed;
    protected string color = "";
    protected string name = "";
    public string brand = "";

    public abstract string GetNameCar();

    public float WidthdrawnFuel(float quantityFuelToWithdraw) {
        if(quantityFuelToWithdraw > this.fuel) return -1f;
        return this.fuel -= quantityFuelToWithdraw;
    }

    public float AddFuel(float fuelToAdd) {
        if(fuelToAdd > this.maxFuel - this.fuel) return -1f;
        return this.fuel += fuelToAdd;
    }

    public string GetFuel() {
        return "You have " + this.fuel + "l on " + this.maxFuel + "l";
    }

    public float AddSpeed(float speed) {
        if(this.speed + speed > this.maxSpeed) return this.speed = this.maxSpeed;
        return this.speed += speed;
    }

    public float DecreaseSpeed(float speed) {
        if(this.speed - speed < 0) return this.speed = 0;
        return this.speed -= speed;
    }

    public string GetSpeed() {
        return "Your speed is : " + this.speed + "km/h.";
    }
}

class Porsche : Car {

    public Porsche(string name, string color, float maxFuel, float fuel, float maxSpeed) {
        this.brand = "Porsche";
        this.name = name;
        this.maxSpeed = maxSpeed;
        this.color = color;
        this.fuel = fuel;
        this.maxFuel = maxFuel;
    }

    public override string GetNameCar() {
        return "This car's name is a" + this.brand + " " + this.name;
    }
}

class Audi : Car {

    public Audi(string name, string color, float maxFuel, float fuel, float maxSpeed) {
        this.brand = "Audi";
        this.name = name;
        this.maxSpeed = maxSpeed;
        this.color = color;
        this.fuel = fuel;
        this.maxFuel = maxFuel;
    }

    public override string GetNameCar() {
        return "You choose this car : " + this.brand + ' ' + this.name;
    }
}

class Program {
    static void Main() {
        IList<Car> cars = new List<Car>();
        Porsche porsche911 = new Porsche("911", "red", 50f, 5f, 230f);
        Audi audiA6 = new Audi("A6", "grey", 70f, 50f, 210f);
        cars.Add(porsche911);
        cars.Add(audiA6);
        string console = "";
        Car myCar = cars[0];
        do {
            Console.WriteLine("Please enter command (car, drive or exit)");
            console = Console.ReadLine();
            if(console == null) break;
            switch(console) {
                case "car":
                    Console.WriteLine("You can choose a car : Porsche or Audi");
                    try {
                        string car = Console.ReadLine();
                        if(car == null || car == "exit") break;
                        myCar = FindCar(car, cars);
                        Console.WriteLine(myCar.GetNameCar());
                        System.Threading.Thread.Sleep(1500);
                    }
                    catch(Exception e) {
                        Console.WriteLine("Your exception :" + e);
                    }
                    break;
                case "drive":
                    if(myCar == null) {
                        Console.WriteLine("You didn't choose any car !");
                        System.Threading.Thread.Sleep(1500);
                        break;
                    }
                    string temp;
                    do {
                        Console.WriteLine("What do you want to do with your car ? (add, decrease or exit)");
                        temp = Console.ReadLine();
                        if(temp == null || temp == "exit") break;
                        AddOrDecreaseSpeed(temp);
                    } while(temp != "exit");
                    break;
                default:
                    break;
            }
        } while(console != "exit");

        void AddOrDecreaseSpeed(string consoleResponse) {
            if(consoleResponse == "add") {
                Console.WriteLine("How much speed would you add ?");
                float speed;
                try {
                    speed =  float.Parse(Console.ReadLine());
                }
                catch(Exception e) {
                    Console.WriteLine(e);
                    return;
                }
                if(speed > 500f) return;
                float tempMySpeed;
                tempMySpeed = myCar.AddSpeed(speed);
                WriteLineVroum(speed);
                Console.WriteLine(myCar.GetSpeed());
            }
            else if(consoleResponse == "decrease") {
                Console.WriteLine("How much speed would you decrease ?");
                float speed;
                try {
                    speed =  float.Parse(Console.ReadLine());
                }
                catch(Exception e) {
                    Console.WriteLine(e);
                    return;
                }
                if(speed > 500f) return;
                float tempMySpeed;
                tempMySpeed = myCar.DecreaseSpeed(speed);
                Console.WriteLine(myCar.GetSpeed());
            }
            System.Threading.Thread.Sleep(1000);
        }

        void WriteLineVroum(float addedSpeed) {
            for(int i = 0; i < (float) addedSpeed / 10; i++) {
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("Vroum");
            }
        }

        Car FindCar(string car, IList<Car> cars) {
            foreach(Car i in cars) {
                if(i.brand == car) return i;
            }
            Console.WriteLine("We do not found the car you asked for so we gave you the " + cars[0].brand);
            return cars[0];
        }
    }
}