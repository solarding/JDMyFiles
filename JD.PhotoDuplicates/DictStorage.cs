using System;
using System.Collections.Concurrent;
using System.Text.Json;

namespace JD.PhotoDuplicates
{
    public class FileInfoData
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public string Name { get; set; }
        public string FullName { get; set; }
        public long Length { get; set; }
        public DateTime LastWriteTime { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public static FileInfoData FromFileInfo(FileInfo fileInfo)
        {
            if(fileInfo.Exists == false) return null;

            return new FileInfoData
            {
                Name = fileInfo.Name,
                FullName = fileInfo.FullName,
                Length = fileInfo.Length,
                LastWriteTime = fileInfo.LastWriteTimeUtc
            };
        }

        public FileInfo ToFileInfo()
        {
            return new FileInfo(FullName);
        }
    }

    public class DictionaryStorage
    {
        public static void SaveToJson(ConcurrentDictionary<ulong, List<FileInfo>> dictionary, string filePath)
        {
            var converted = dictionary.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Select(FileInfoData.FromFileInfo).ToList()
            );
            
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(converted, options);
            File.WriteAllText(filePath, json);
        }

        public static ConcurrentDictionary<ulong, List<FileInfo>> LoadFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var loaded = JsonSerializer.Deserialize<Dictionary<ulong, List<FileInfoData>>>(json);

            if (loaded == null)
            {
               MessageBox.Show("The JSON file could not be deserialized.");
                return new ConcurrentDictionary<ulong, List<FileInfo>>();
            }

            var result = new ConcurrentDictionary<ulong, List<FileInfo>>();
            foreach (var kvp in loaded)
            {
                result.TryAdd(kvp.Key, kvp.Value.Select(f => f.ToFileInfo()).ToList());
            }

            return result;
        }
    }
}