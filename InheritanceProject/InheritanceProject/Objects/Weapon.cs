namespace InheritanceProject;

public class Weapon
{
    private string _displayName;
    private int _minDamage;
    private int _maxDamage;

    public Weapon(string displayName, int minDamage, int maxDamage)
    {
        _displayName = displayName;
        _minDamage = minDamage;
        _maxDamage = maxDamage;
    }

    public int ReturnDamage()
    {
        Random rnd = new Random();
        return rnd.Next(_minDamage, _maxDamage);
    }

    public override string ToString()
    {
        return _displayName;
    }
}