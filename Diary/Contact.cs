using System;

class Contact
{
    protected int id;
    protected string name;
    protected string phone;
    protected static int countId = 0;

    public Contact(int id, string name, string phone)
    {
        setId(id);
        this.name = name;
        this.phone = phone;
    }

    public Contact(string name, string phone) :
        this(countId, name, phone)
    {
    }

    public int GetId() { return id; }
    public string GetName() { return name; }
    public string GetPhone() { return phone; }

    protected void setId(int id)
    {
        this.id = id;
        countId = ++id;
    }
    public void SetName(string name) { this.name = name; }
    public void SetPhone(string phone) { this.phone = phone; }

    public override string ToString()
    {
        return name + "(" + phone + ")";
    }
}