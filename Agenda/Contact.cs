class Contact
{
    protected int id;
    protected string name;
    protected string number;

    public Contact(int id, string name, string number)
    {
        this.id = id;
        this.name = name;
        this.number = number;
    }

    public int GetId() { return id; }
    public string GetName() { return name; }
    public string GetNumber() { return number; }
    
    public void SetName(string name) { this.name = name; }
    public void SetNumber(string number) { this.number = number; }

    public override string ToString()
    {
        return name + "(" + number + ")";
    }
}