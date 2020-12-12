namespace FormGenerator
{
    class SelectItem : Item
    {
        public SelectItem(string name, string placeholder, string required, 
            ValidationRules validationRules, string value, string label, 
            string classCSS, string disabled, Options[] options)
        {
            Type = "select";
            Name = name;
            Placeholder = placeholder;
            Required = required;
            rules = validationRules;
            Value = value;
            Label = label;
            Class = classCSS;
            Disabled = disabled;
            Options = options;
        }

        private readonly ValidationRules rules;

        protected override string GetHTML()
        {
            string nameText = $"name=\"{Name}\"";
            string placeholderText = $"placeholder=\"{Placeholder}\"";
            string requiredText = Required == "true" ? "required" : "";
            string valueText = $"value=\"{Value}\"";
            string classNameText = $"class=\"{Class}\"";
            string disabledText = Disabled == "true" ? "disabled" : "";
            string typeText = $"type=\"{rules.Type}\"";

            string returnValue = $"<select {placeholderText} {requiredText} " +
                $"{disabledText}{valueText} {classNameText} {nameText}{typeText}>";
            for (int i = 0, length = Options.Length; i < length; i++)
            {
                string selectedText = Options[i].Selected == "true" ? "selected" : "";
                returnValue += $"<option value=\"{Options[i].Value}\" " +
                    $"{selectedText}>{Options[i].Text}</option>";
            }
            returnValue += $"</select>{Label}<br />";
            return returnValue;
        }
    }

    class Options
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public string Selected { get; set; }
    }
}
