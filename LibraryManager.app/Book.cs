

class Book
{
    public string Name { get; set; }
    public string Type { get; set; }

    public Book(string name, string type)
    {
        this.Name = name;
        this.Type = type;
    }
}