namespace FactoryPattern
{
    public enum DoughType
    {
        Flaky,
        Shortcrust,
        Choux
    }

    /* an example of FactoryMethod implementation */
    public class Pastry
    {
        public string filling;
        public DoughType dough;
        public bool butter;

        protected Pastry(string fillingName, DoughType doughType, bool needsButter) 
        {
            filling = fillingName;
            dough = doughType;
            butter = needsButter;
        }

        public override string ToString()
        {
            return $"{dough} pastry with {filling} filling.";
        }

        public static Pastry NewFlakyPastry(string fillingName)
        {
            return new Pastry(fillingName, DoughType.Flaky, true);
        }

        public static Pastry NewShortCrustPastry(string fillingName)
        {
            return new Pastry(fillingName, DoughType.Shortcrust, false);
        }

        public static Pastry NewChouxPastry(string fillingName)
        {
            return new Pastry(fillingName, DoughType.Choux, false);
        }
    }
}
