using System;
using System.Linq;

public class User
{
    private ushort age;
    private string city;
    private long id;
    private string name;

    private User(long id, string name, ushort age, string city)
    {
        Id = id;
        Name = name;
        Age = age;
        City = city;
    }

    private long Id
    {
        get => id;
        set
        {
            id = value;
        }
    }

    public string Name
    {
        get => name;
        private set
        {
            name = value;
        }
    }

    public ushort Age
    {
        get => age;
        private set
        {
            age = value;
        }
    }

    public string City
    {
        get => city;
        private set
        {
            city = value;
        }
    }

    public static User Parse(string str)
    {
        var data = str.Split(";");
        if (data.Length != 4 || !long.TryParse(data[0], out long id) ||
            id <= 0|| !ushort.TryParse(data[2], out ushort age) || age > 128
            || data[1].Any(char.IsDigit))
            throw new ArgumentException("Incorrect input");
        
        return new User(long.Parse(data[0]), data[1], ushort.Parse(data[2]), data[3]);
    }
}