namespace InheritanceProject;

public interface ITarget
{
    public void TakeDamage(int incomingDamage);
    public string DisplayStatus();
    public bool IsDead();
}