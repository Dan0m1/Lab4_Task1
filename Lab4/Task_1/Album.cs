using System.Text;

namespace Lab4.Task_1;

public class Album
{
    private string _name;
    private const int PhotosPerPage = 10;
    private int _photoAmount = 0;
    private int _currentPage = -1;
    private List<Page> _pages = new List<Page>();

    public Album()
    {
        _name = "Album";
        Console.WriteLine("Album \"Album\" created");
    }
    
    public Album(string name, Photo[] photos)
    {
        _name = name;
        
        foreach (Photo photo in photos)
        {
            AddPhoto(photo);
        }
        
        Console.WriteLine($"Album \"{name}\" created");
    }

    
    public void AddPhoto(Photo photograph)
    {
        if (_pages.Count == 0 || _photoAmount%PhotosPerPage == 0)
        {
            _pages.Add(new Page(++_currentPage, PhotosPerPage));
        }
        _pages[_currentPage].AddPhoto(photograph);
        _photoAmount++;
        
        Console.WriteLine("New photo added to album");
    }

    public void PrintPhotoAmount()
    {
        Console.WriteLine($"Amount of photos in album: {_photoAmount}");
    }

    public void SetPhotoName(int pageNum, int photoNum, string name)
    {
        if (_pages.Count < pageNum || photoNum > PhotosPerPage || _pages[pageNum - 1].GetPhoto(photoNum - 1) == null)
        {
            Console.WriteLine("Something went wrong. Check your input data");
        }

        _pages[pageNum - 1].GetPhoto(photoNum - 1).Name = name;

        Console.WriteLine("The photo's name was set");
    }

    public override int GetHashCode()
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            Console.WriteLine("Creating hashcode for album");
            StringBuilder str = new StringBuilder(_photoAmount+" ");
            foreach (Page page in _pages)
            {
                str.Append(page.PageNum+" ");
            }
            
            byte[] inputBytes = Encoding.ASCII.GetBytes(str.ToString());
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(hashBytes);
            
            return BitConverter.ToInt32(hashBytes, 0);
        }
    }

    public override bool Equals(object? obj)
    {
        Console.WriteLine("Deciding whether albums are equal");
        if (obj is Album album)
        {
            return album._name == _name && album._pages.Equals(_pages);
        }
    
        return false;
    }

    public override string ToString()
    {
        Console.WriteLine("Converting album to string");
        return new string($"Name {_name}, Pages: {_currentPage + 1}, Photos: {_photoAmount}");
    }
}