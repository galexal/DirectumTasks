namespace FormGenerator
{
    class FormData
    {
        public string Name { get; set; }
        public Form Form { get; set; }
    }
    class Form
    {
        public string Postmessage { get; set; }
        public Item[] Items { get; set; }

        public string GetHTML()
        {
            string returnValue = $"<form onsubmit=\"alert('{Postmessage}')\">\n"; ;
            for (int i = 0; i < Items.Length; i++)
                returnValue += Items[i].Print() + "\n";
            returnValue += "<button type=\"submit\">Отправить форму</button>\n</form>";
            return returnValue;
        }
    }
    class ValidationRules
    {
        public string Type { get; set; }
    }

}
