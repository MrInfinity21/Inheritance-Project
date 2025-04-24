namespace InheritanceProject;

public class Player : Character
{
    public Player(string displayName, Attributes attributes) : base(displayName, attributes)
    {
        InitializeCharacter(10);
    }
}