namespace PrototypePattern
{
    public class Button : BaseDeepCopyable<Button>
    {
        public string Text;
        public int Size;
        public Button(string text, int size)
        {
            Text = text;
            Size = size;
        }

        // Needed for serialization and deepcopy.
        // Bad design.
        public Button()
        {
        }
    }
}
