namespace InheritanceProject;

// Parent class
public abstract class Character : ITarget
{
    protected string _displayName;
    protected int _currentHealth;
    protected int _maxHealth;
    protected Attributes _attributes;
    protected Weapon _equippedWeapon = new Weapon("Bare Fists", 1, 2);

    public Character(string displayName, Attributes attributes)
    {
        _displayName = displayName;
        _attributes = attributes;
    }

    protected void InitializeCharacter(int healthMultiplier)
    {
        _maxHealth = _attributes.constitution * healthMultiplier;
        _currentHealth = _maxHealth;
    }

    public virtual void Attack(ITarget target)
    {
        int outgoingDamage = _equippedWeapon.ReturnDamage();
        outgoingDamage += _attributes.strength;
        Console.WriteLine($"{_displayName} attacked {target}");
        target.TakeDamage(outgoingDamage);
    }

    public virtual void TakeDamage(int incomingDamage)
    {
        Console.WriteLine($"{_displayName} took {incomingDamage} damage");
        _currentHealth = Math.Clamp(_currentHealth - incomingDamage, 0, _maxHealth);
        if (_currentHealth == 0)
        {
            Console.WriteLine($"{_displayName} was killed");
        }
    }

    public void EquipWeapon(Weapon weaponToEquip)
    {
        _equippedWeapon = weaponToEquip;
    }

    public string WeaponName()
    {
        return _equippedWeapon.ToString();
    }
    
    public string DisplayStatus()
    {
        return $"{_displayName}: {_currentHealth}/{_maxHealth}";
    }
    
    public override string ToString()
    {
        return _displayName;
    }
    
    public bool IsDead()
    {
        return _currentHealth == 0;
    }
}