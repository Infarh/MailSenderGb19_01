using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatabaseTest.Data;

namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SongsDatabase())
            {
                db.Database.Log = s => Console.WriteLine("EF>> {0}", s);

                if (!db.Tracks.Any())
                {
                    for (var i = 0; i < 200; i++)
                        db.Tracks.Add(new Track
                        {
                            Name = $"Song {i + 1}",
                            Artist = $"Artist {i + 5}"
                        });
                    db.SaveChanges();
                }
            }

            Console.WriteLine("Обновление БД завершено.");
            Console.ReadLine();

            using (var db = new SongsDatabase())
            {
                db.Database.Log = s => Console.WriteLine("EF>> {0}", s);

                foreach (var track in db.Tracks.Where(t => t.Name.Length == 7))
                {
                    Console.WriteLine("Track: {0}, artist: {1}", track.Name, track.Artist);       
                }
            }

            Console.ReadLine();
        }
    }
}
