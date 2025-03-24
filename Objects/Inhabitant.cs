using UnityEngine;

public abstract class Inhabitant
{
    public int currHp;
    public int maxHp;
    protected int ac;
    protected string name;

    public Inhabitant(string name)
    {
        this.name = name;
        this.maxHp = Random.Range(30, 50);
        this.currHp = this.maxHp;
        this.ac = Random.Range(10, 20);
    }

    public bool isDead()
    {
        return this.currHp <= 0;
    }
    
    public void takeDamage(int damage)
    {
        this.currHp = this.currHp - damage;
    }
    
    public int getAC()
    {
        return this.ac;
    }
    
    public string getName()
    {
        return this.name;
    }
}