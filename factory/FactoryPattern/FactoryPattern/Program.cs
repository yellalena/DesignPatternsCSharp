using FactoryPattern;

class Factory
{
    public static void Main()
    {
        /* FactoryMethod */

        var mySweetPastry = Pastry.NewFlakyPastry("Apple jam");
        Console.WriteLine(mySweetPastry);

        /* Factory */

        var myVanCar = CarFactory.CreateVan("White");
        Console.WriteLine(myVanCar.GetCarInfo());

        var mySedanCar = CarFactory.CreateCar("Green", CarType.Sedan);
        Console.WriteLine(mySedanCar.GetCarInfo());
    }
}