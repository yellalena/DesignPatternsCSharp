using PrototypePattern;

class Prototype
{
    public static void Main()
    {
        var largeButtonForm = FormFactory.NewFormWithLargeButton(50, 50, "I am a Laaarge Button Form!");
        var smallButtonForm = FormFactory.NewFormWithSmallButton(20, 30, "I am a small button Form!");

        Console.WriteLine(largeButtonForm.ToString());
        Console.WriteLine(smallButtonForm.ToString());
    }
}