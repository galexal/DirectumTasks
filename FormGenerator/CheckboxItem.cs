namespace FormGenerator
{
    class CheckboxItem : Item
    {
        public CheckboxItem(string name, string placeholder, string required, 
            ValidationRules validationRules, string label, string classCSS, 
            string disabled, string isChecked)
        {
            Type = "checkbox";
            Name = name;
            Placeholder = placeholder;
            Required = required;
            rules = validationRules;
            Label = label;
            Class = classCSS;
            Disabled = disabled;
            Checked = isChecked;
        }

        private readonly ValidationRules rules;

        protected override string GetHTML()
        {
            string nameText = $"name=\"{Name}\"";
            string placeholderText = $"placeholder=\"{Placeholder}\"";
            string requiredText = Required == "true" ? "required" : "";
            string classCSSText = $"class=\"{Class}\"";
            string disabledText = Disabled == "true" ? "disabled" : "";
            string checkedText = Checked == "true" ? "checked" : "";
            string typeText = $"type=\"{rules.Type}\"";

            return $"<label><input {placeholderText} {requiredText} {disabledText} " +
                $"{classCSSText} {nameText} {typeText}{checkedText}>{Label}</label><br />";
        }
    }
}
