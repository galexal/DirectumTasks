namespace FormGenerator
{
    class RadioItem : Item
    {
        public RadioItem(string name, string placeholder, string required, 
            ValidationRules validationRules, string value, string label, 
            string className, string disabled, Items[] items)
        {
            Type = "radio";
            Name = name;
            Placeholder = placeholder;
            Required = required;
            rules = validationRules;
            Value = value;
            Label = label;
            Class = className;
            Disabled = disabled;
            Items = items;
        }

        private readonly ValidationRules rules;

        protected override string GetHTML()
        {
            string nameText = $"name=\"{Name}\"";
            string placeholderText = $"placeholder=\"{Placeholder}\"";
            string requiredText = Required == "true" ? "required" : "";
            string valueText = $"value=\"{Value}\"";
            string classCSS = $"class=\"{Class}\"";
            string disabledText = Disabled == "true" ? "disabled" : "";
            string typeText = $"type=\"{rules.Type}\"";

            string returnValue = "";
            for (int i = 0; i < Items.Length; i++)
            {
                string valueItemsText = $"value=\"{Items[i].Value}\"";
                string checkedItemsText = Items[i].Checked == "true" ? "checked" : "";
                returnValue += $"<label><input {placeholderText} {requiredText} " +
                    $"{disabledText} {valueText}{valueItemsText} {classCSS} {nameText} " +
                    $"{typeText} {checkedItemsText}>{Items[i].Label}</label>";
            }
            return returnValue + "<br />";
        }
    }

    class Items
    {
        public string Value { get; set; }
        public string Label { get; set; }
        public string Checked { get; set; }
    }
}
