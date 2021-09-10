using System;
using System.Collections.Generic;

namespace RoleRelationships
{
    class Program
    {
        static void Main(string[] args)
        {
            RoleService roleService = new RoleService();
            roleService.ChangeRelationship(Roles.Supporter, Roles.Independent, 4);
            Console.ReadKey();
        }
    }
}
