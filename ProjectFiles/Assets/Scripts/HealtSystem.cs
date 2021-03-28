 

public class HealtSystem 
{
    private int health;
    public HealtSystem(int health)
    {
        this.health = health;
    }
    public int Gethealth()
    {
        return health;
    }
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }
    public void Heal(int healAmount)
    {
        health += healAmount;
    }
}
