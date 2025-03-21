using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;

    public void setAttacker(Inhabitant attacker)
    {
        this.attacker = attacker;
    }

    public void setDefender(Inhabitant defender)
    {
        this.defender = defender;
    }

    public Fight()
    {
        int roll = Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            setAttacker(Core.theMonster);
            setDefender(Core.thePlayer);
        }
        else
        {
            setAttacker(Core.thePlayer);
            setDefender(Core.theMonster);   
        }

    }

    public void startFight()
    {
        
        //should have the attacker and defender fight each until one of them dies.
        //the attacker and defender should alternate between each fight round and
        //the one who goes first was determined in the constructor.
        while(true) //we internally break out as part of the logic
		{
			//attacker attempts to attack the defender
            int attackRoll = Random.Range(0, 20) + 1;
			if(attackRoll >= defender.getAC())
			{
				//we have hit the defender
				int damage = Random.Range(1, 6);
				defender.takeDamage(damage);

				if(defender.isDead())
				{
					Debug.Log(attacker.getName() + " has won the fight!");
					break; //stop fighting!!!!
				}
			}
			else
			{
				//we missed
				Debug.Log(attacker.getName() + " swings and misses");

				if(attackRoll == 1)
				{
					Debug.Log("**** Critical Miss **** " + attacker.getName() + " stumbles and stabs themselves in the foot!");
				}
			}

			//defender is still alive! Switch roles
			Inhabitant temp = attacker;
			attacker = defender;
			defender = temp;
		} //end of the infinite loop
    }
}
