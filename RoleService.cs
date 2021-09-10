using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace RoleRelationships
{
    public class RoleService
    {
        private List<RoleRelationship> relationshipMapping { get; set; } = new();

        public void WriteRelationship(Roles role1, Roles role2, int score)
        {
            RoleRelationship newRelationship = new RoleRelationship();
            newRelationship.Role1 = role1;
            newRelationship.Role2 = role2;
            newRelationship.Score = score;
            relationshipMapping.Add(newRelationship);
        }
        public void PrintValues()
        {
            foreach (var relationship in relationshipMapping)
            {
                Console.WriteLine($"{relationship.Role1}, {relationship.Role2}, {relationship.Score}");
            }
        }

        public void LoadFromDatabase()
        {
            DatabaseRepository repository = new();
            string valueFromDatabase = repository.ReadFromDatabase();
            relationshipMapping = JsonSerializer.Deserialize<List<RoleRelationship>>(valueFromDatabase);
        }

        private int score = new();
        public void GetPairing(Roles role1, Roles role2)
        {
            LoadFromDatabase();

            RoleRelationship Inquiry = new RoleRelationship();
            Inquiry.Role1 = role1;
            Inquiry.Role2 = role2;

            foreach (RoleRelationship pair in relationshipMapping)
            {
                if (Inquiry.Role1 == pair.Role1 && Inquiry.Role2 == pair.Role2)
                {
                    Inquiry.Score = pair.Score;
                }

            }
            Console.WriteLine($"{Inquiry.Role1} + {Inquiry.Role2} = {Inquiry.Score}");
            score = Inquiry.Score;
        }

        public void GetTrio(Roles role1, Roles role2, Roles role3)
        {
            int TeamScore = 0;
            GetPairing(role1, role2);
            TeamScore += score;
            GetPairing(role2, role3);
            TeamScore += score;
            GetPairing(role3, role1);
            TeamScore += score;
            Console.WriteLine($"Team Score = {TeamScore}");
        }

        public void ChangeRelationship(Roles role1, Roles role2, int newScore)
        {
            LoadFromDatabase();

            foreach (RoleRelationship pair in relationshipMapping)
            {
                if (role1 == pair.Role1 && role2 == pair.Role2 || role1 == pair.Role2 && role2 == pair.Role1)
                {
                    Console.WriteLine($"{pair.Role1}/{pair.Role2} was {pair.Score}");
                    pair.Score = newScore;
                    Console.WriteLine($"{pair.Role1}/{pair.Role2} is now {pair.Score}");
                }
            }
            SaveToDatabase();
        }


        public void SaveToDatabase()
        {
            DatabaseRepository repository = new();

            List<string> rolesToAdd = new();

            string jsonstring = JsonSerializer.Serialize(relationshipMapping);

            repository.WriteToDatabase(jsonstring);
        }
    }
}


