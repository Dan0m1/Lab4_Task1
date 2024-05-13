namespace Lab4.Task_1
{
    class Program
    {
        public static void Main()
        {
            List<Photo> photos = new List<Photo>();
            for (int i = 0; i < 23; i++)
            {
                photos.Add(new Photo($"Photo #{i+1}"));
            }

            Album album = new Album("my new album",photos.ToArray());

            album.AddPhoto(new Photo("adding new photo via album's method"));
            album.PrintPhotoAmount();
            album.SetPhotoName(2,3,"custom name");
            Console.WriteLine(album.GetHashCode());
            Console.WriteLine(album.ToString());
            Console.WriteLine(album.Equals(new Album()));
        }
    }
}

