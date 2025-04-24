namespace InheritanceProject;

public class Goblin : Character
{
    private int _hitMultiplier = 2;
    int dodgeChance = 2;
    
    public Goblin(string displayName, Attributes attributes) : base(displayName, attributes)
    {
        InitializeCharacter(2);
    }

    public override void TakeDamage(int damage)
    {
        Random rnd = new Random();
        bool dodgedHit = rnd.Next(1, _attributes.dexterity) > dodgeChance;
        if (dodgedHit)
        {
            Console.WriteLine($"{_displayName} dodged the hit!");
        }
        else
        {
            damage *= _hitMultiplier;
            base.TakeDamage(damage);
        }
    }
}