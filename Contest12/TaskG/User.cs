using System;
using System.Linq;

public class User
{
    private long id;
    private string name;
    private ushort age;

    public long Id
    {
        get => id;
        private set => id = value;
    }
    
    public string Name
    {
        get => name;
        private set => name = value;
    }
    
    public ushort Age
    {
        get => age;
        private set => age = value;
    }

    private User(long id, string name, ushort age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public static User Parse(string str)
    {
        var data = str.Split(";");
        if (data.Length != 3 || !long.TryParse(data[0], out long id) ||
                             id <= 0|| !ushort.TryParse(data[2], out ushort age) || age > 128
                             || data[1].Any(char.IsDigit))
            throw new ArgumentException("Incorrect input");
        
        return new User(long.Parse(data[0]), data[1], ushort.Parse(data[2]));
    }
}