namespace FactoryPattern
{
    public interface ICar
    {
        string GetCarInfo();
    }

    public class Sedan : ICar
    {
        public string Color;
        public static int NumberOfPeople = 4;

        public Sedan(string color)
        {
            Color = color;
        }

        public string GetCarInfo()
        {
            return $"{Color} {nameof(Sedan)}. Can fit {NumberOfPeople} people.";
        }
    }

    public class Van : ICar
    {
        public string Color;
        public static int NumberOfPeople = 8;

        public Van(string color)
        {
            Color = color;
        }

        public string GetCarInfo()
        {
            return $"{Color} {nameof(Van)}. Can fit {NumberOfPeople} people.";
        }
    }
}
