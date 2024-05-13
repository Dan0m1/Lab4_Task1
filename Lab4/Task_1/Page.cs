using System.Text;

namespace Lab4.Task_1;

public class Page
{
    private List<Photo> _photos = new List<Photo>();
    public int PageNum { get; }
    public Page(int photosPerPage, int pageNum)
    {
        PageNum = pageNum;
        Console.WriteLine("Created new page");
    }

    public void AddPhoto(Photo photograph)
    {
        _photos.Add(photograph); 
        Console.WriteLine($"Added new photo to page {PageNum}");
    }

    public Photo GetPhoto(int index)
    {
        Console.WriteLine("Here is your photo");
        return _photos[index];
    }

    public override string ToString()
    {
        Console.WriteLine("Converting page to string");
        return PageNum.ToString();
    }

    public override bool Equals(object? obj)
    {
        Console.WriteLine("Deciding whether pages are equal");
        if (obj is Page page)
        {
            if (PageNum != page.PageNum || _photos.Count != page._photos.Count || !_photos.SequenceEqual(page._photos))
                return false;
            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        Console.WriteLine("Creating hashcode for album");
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            StringBuilder str = new StringBuilder();
            foreach (Photo photo in _photos)
            {
                str.Append(photo.Name+" ");
            }
            
            byte[] inputBytes = Encoding.ASCII.GetBytes(str.ToString());
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(hashBytes);
            
            return BitConverter.ToInt32(hashBytes, 0);
        }
    }
}