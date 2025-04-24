namespace InheritanceProject;

public class Crate : ITarget
{
    private string _displayName = "Flimsy Crate";
    private bool _hasBeenDestroyed = false;
    
    public void TakeDamage(int incomingDamage)
    {
        Console.WriteLine("The crate shatters to pieces.");
        _hasBeenDestroyed = true;
    }

    public string DisplayStatus()
    {
        return _displayName;
    }

    public bool IsDead()
    {
        return _hasBeenDestroyed;
    }


    public override string ToString()
    {
        return _displayName;
    }
}