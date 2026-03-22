using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Gym_Management__Project_.INFRASTRUCTURE
{
    public class FileStorage
    {
        private readonly string _filePath;

        public FileStorage(string filePath)
        {
            _filePath = filePath;
        }

        public GymStorage Load()
        {
            if(!File.Exists(_filePath))
            {
                return new GymStorage();
            }
            var json = File.ReadAllText(_filePath);
               
            var storage = JsonSerializer.Deserialize<GymStorage>(json);
            if(storage== null)
            {
                throw new Exception("Deserialization failed. The file content is not valid.");
            }
            return storage;
        }
        public void Save(GymStorage storage)
        {
            var json = JsonSerializer.Serialize(storage);
            File.WriteAllText(_filePath, json);
        }
    }
}
