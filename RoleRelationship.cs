namespace RoleRelationships{

public enum Roles
{
    Captain,
    Striker,
    Anchor,
    Flex,
    Tactician,
    Independent,
    Supporter
}

public class RoleRelationship{
    public Roles Role1 { get; set; }
    public Roles Role2 { get; set; }
    public int Score { get; set; }
}

}