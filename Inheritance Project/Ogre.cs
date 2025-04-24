namespace InheritanceProject;

public class Ogre : Character
{
    private int _damageReduction = 2;
    private int _damageMultipliter = 2;
    
    public Ogre(string displayName, Attributes attributes) : base(displayName, attributes)
    {
        InitializeCharacter(5);
    }

    public override void Attack(ITarget target)
    {
        Random random = new Random();
        bool missedAttack = random.Next(2) == 0;
        if (missedAttack)
        {
            Console.WriteLine($"{_displayName} flails around and misses its target!");
        }
        else
        {
            Console.WriteLine($"{_displayName} attacked {target}");
            int outgoingDamage = _equippedWeapon.ReturnDamage() + _attributes.strength;
            outgoingDamage *= _damageMultipliter;
            base.TakeDamage(outgoingDamage);
        }
    }

    public override void TakeDamage(int damage)
    {
        damage /= _damageReduction;
        Console.WriteLine($"{_displayName} shrugged off half the damage!");
        base.TakeDamage(damage);
    }
}