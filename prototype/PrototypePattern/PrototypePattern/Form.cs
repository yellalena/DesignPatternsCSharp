namespace PrototypePattern
{
    public class Form : BaseDeepCopyable<Form>
    {
        public int Width;
        public int Height;
        public Button Button;

        public Form(int width, int height, Button button)
        {
            Width = width;
            Height = height;
            Button = button;
        }

        // Needed for serialization and deepcopy.
        // Bad design.
        public Form()
        {
        }

        public override string ToString()
        {
            return $"Form<({Width}x{Height}), Button<{Button.Size},{Button.Text}>>";
        }
    }
}
