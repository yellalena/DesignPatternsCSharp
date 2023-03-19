namespace PrototypePattern
{
    public class FormFactory
    {
        private static Form largeButton = new Form(0, 0, new Button("", 15));
        private static Form smallButton = new Form(0, 0, new Button("", 5));
        public static Form NewFormWithLargeButton(int formWidth, int formHeight, string buttonText)
            => NewForm(largeButton, formWidth, formHeight, buttonText);

        public static Form NewFormWithSmallButton(int formWidth, int formHeight, string buttonText)
            => NewForm(smallButton, formWidth, formHeight, buttonText);

        public static Form NewForm(Form formToCopy, int formWidth, int formHeight, string buttonText)
        {
            var form = formToCopy.DeepCopy();
            form.Width = formWidth;
            form.Height = formHeight;
            form.Button.Text = buttonText;

            return form;
        }

    }
}
