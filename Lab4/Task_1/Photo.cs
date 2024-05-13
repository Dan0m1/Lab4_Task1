using System.Text;

namespace Lab4.Task_1;

public class Photo
{
    private string _name = "";
    

    public Photo()
    {
        Name = "Photo";
        Console.WriteLine("Created new photo");
    }
    
    public Photo(string name)
    {
        Name = name;
        Console.WriteLine($"Created new photo named \"{name}\"");
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string ToString()
    {
        Console.WriteLine("Converting photo to string");
        return Name;
    }

    public override bool Equals(object? obj)
    {
        Console.WriteLine("Deciding whether photos are equal");
        if (obj is Photo photo)
        {
            return Name == photo.Name;
        }

        return false;
    }

    public override int GetHashCode()
    {
        Console.WriteLine("Creating hashcode for photo");
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{_name}");
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            
            if (BitConverter.IsLittleEndian)
                Array.Reverse(hashBytes);
            
            return BitConverter.ToInt32(hashBytes, 0);
        }
    }
}