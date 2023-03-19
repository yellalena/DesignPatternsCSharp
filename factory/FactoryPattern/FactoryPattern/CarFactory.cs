namespace FactoryPattern
{
    public enum CarType
    {
        Sedan,
        Van
    }

    public class CarFactory
    {
        public static Sedan CreateSedan(string color)
        {
            return new Sedan(color);
        }

        public static Van CreateVan(string color)
        {
            return new Van(color);
        }

        public static ICar CreateCar(string color, CarType type)
        {
            return type switch
            {
                CarType.Sedan => new Sedan(color),
                CarType.Van => new Van(color),
                _ => throw new Exception("Unknown car type"),
            };
        }
    }
}
