namespace FormGenerator
{
    class ButtonItem : Item
    {
        public ButtonItem(string text, string classCSS)
        {
            Type = "button";
            Text = text;
            Class = classCSS;
        }

        protected override string GetHTML()
        {
            string classCSSText = $"class=\"{Class}\"";
            return $"<button {classCSSText}>{Text}</button><br />";
        }
    }
}
