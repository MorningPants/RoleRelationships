using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleRelationships
{
    public class DatabaseRepository
    {
        public string ReadFromDatabase()
        {
            if (File.Exists("RoleRelationships.json"))
            {
                string data = File.ReadAllText("RoleRelationships.json");
                return data;
            }

            return "";
        }

        public void WriteToDatabase(string data)
        {
            File.WriteAllText("RoleRelationships.json", data);
        }
    }
}
