using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using System.Text.RegularExpressions;

namespace JD.MF
{
    public static class AudioTagUtil 
    {
        private static IList<string> _ARTISTS;
        
        public static void ParseFilename(string fileName, Tag tag)
        {
            if (_ARTISTS == null) Init();
            var t = new AudioTag();
            var fn = ZH.ToDBC(ZH.ToSimplified(fileName)).Trim();
            fn = Regex.Replace(fn, @"[\[\<].*?[\]\>]", string.Empty);
            fn = fn.Replace("《", "").Replace("》", "");
            fn = fn.Replace(":", "-").Replace("/", "-").Replace("_","-");
            var ss = fn.Split('-');
            foreach(string s1 in ss)
            {
                var s = s1.Trim();
                if (string.IsNullOrWhiteSpace(s)) continue;
                if (_ARTISTS.Contains(s)) t.Artist = s;
                else if (t.Title == null) t.Title = s;
            }

            if(!string.IsNullOrWhiteSpace(t.Album)) tag.Album = t.Album;
            if (!string.IsNullOrWhiteSpace(t.Artist))
            {
                if (tag.AlbumArtists.Length == 0) tag.AlbumArtists = new[] { t.Artist };
                if(tag.Performers.Length == 0) tag.Performers = new[] { t.Artist };
            }
            if (!string.IsNullOrWhiteSpace(t.Title)) tag.Title = t.Title;
            if (!string.IsNullOrWhiteSpace(t.Album)) tag.Track = t.Track;
            if (!string.IsNullOrWhiteSpace(t.Album)) tag.Year = t.Year;

        }

        private static void Init()
        {
            _ARTISTS = System.IO.File.ReadAllLines(@"Config\artists.txt");
        }

        
    }
    public struct AudioTag
    {
        public string Title;
        public string Artist;
        public string Album;
        public uint Track;
        public uint Year;
    }
}
