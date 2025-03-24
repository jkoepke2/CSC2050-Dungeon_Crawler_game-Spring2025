using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;
    
    private Monster theMonster;

    public Fight(Monster m)
    {
        this.theMonster = m;
       
        int roll = Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log("Monster goes first");
            this.attacker = m;
            this.defender = Core.thePlayer;
        }
        else
        {
            Debug.Log("Player goes first");
            this.attacker = Core.thePlayer;
            this.defender = m;
        }

    }

    public void attack(GameObject playerGO, GameObject monsterGO)
    {
        
        //should have the attacker and defender fight each until one of them dies.
        //the attacker and defender should alternate between each fight round and
        //the one who goes first was determined in the constructor.
        
		{
			//attacker attempts to attack the defender
            int attackRoll = Random.Range(0, 20) + 1;
			if(attackRoll >= this.defender.getAC())
			{
				//we have hit the defender
				int damage = Random.Range(1, 6);
				this.defender.takeDamage(damage);

				if(this.defender.isDead())
				{
					Debug.Log(this.attacker.getName() + " killed " + this.defender.getName());
					if(this.defender is Player)
                    {
                        Debug.Log("Player died");
                        playerGO.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("Monster died");
                        GameObject.Destroy(monsterGO);
                    }
                    return;
				}
			}
			else
			{
				//we missed
				Debug.Log(this.attacker.getName() + " missed " + this.defender.getName());
			}

			//defender is still alive! Switch roles
			Inhabitant temp = this.attacker;
			this.attacker = this.defender;
			this.defender = temp;
		} //end of the infinite loop
    }
}
