namespace FormGenerator
{
    class FillerItem : Item
    {
        public FillerItem(string message)
        {
            Type = "filler";
            Message = message;
        }
        protected override string GetHTML()
            => $"<span>{Message}</span><br />";
    }
}
