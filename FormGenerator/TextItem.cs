namespace FormGenerator
{
    class TextItem : Item
    {
        public TextItem(string name, string placeholder, string required, 
            ValidationRules validationRules, string value, string label, 
            string classCSS, string disabled)
        {
            Type = "text";
            Name = name;
            Placeholder = placeholder;
            Required = required;
            rules = validationRules;
            Value = value;
            Label = label;
            Class = classCSS;
            Disabled = disabled;
        }

        private readonly ValidationRules rules;

        protected override string GetHTML()
        {
            string nameText = $"name=\"{Name}\"";
            string placeholderText = $"placeholder=\"{Placeholder}\"";
            string requiredText = Required == "true" ? "required" : "";
            string valueText = $"value=\"{Value}\"";
            string classCSSText = $"class=\"{Class}\"";
            string disabledText = Disabled == "true" ? "disabled" : "";
            string typeText = $"type=\"{rules.Type}\"";

            return $"<label><input {placeholderText} {requiredText} {disabledText} " +
                $"{valueText} {classCSSText} {nameText} {typeText}>{Label}</label><br />";
        }
    }
}
