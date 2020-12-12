namespace FormGenerator
{
    class Item
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public string Placeholder { get; set; }
        public string Required { get; set; }
        public ValidationRules ValidationRules { get; set; }
        public string Value { get; set; }
        public string Label { get; set; }
        public string Class { get; set; }
        public string Disabled { get; set; }
        public string Checked { get; set; }
        public string Text { get; set; }
        public Options[] Options { get; set; }
        public Items[] Items { get; set; }

        private Item GetTemplatedItem(string type)
        {
            switch (type)
            {
                case "filler":
                    return new FillerItem(Message);

                case "text":
                    return new TextItem(Name, Placeholder, Required, 
                        ValidationRules, Value, Label, Class, Disabled);

                case "textarea":
                    return new TextareaItem(Name, Placeholder, Required, 
                        ValidationRules, Value, Label, Class, Disabled);

                case "checkbox":
                    return new CheckboxItem(Name, Placeholder, Required, 
                        ValidationRules, Label, Class, Disabled, Checked);

                case "button":
                    return new ButtonItem(Text, Class);

                case "select":
                    return new SelectItem(Name, Placeholder, Required, 
                        ValidationRules, Value, Label, Class, Disabled, Options);

                case "radio":
                    return new RadioItem(Name, Placeholder, Required, 
                        ValidationRules, Value, Label, Class, Disabled, Items);

                default:
                    return this;
            }
        }

        protected virtual string GetHTML() => "";

        public string Print()
        {
            Item itemToPrint = GetTemplatedItem(Type);
            return itemToPrint.GetHTML();
        }
    }
}
