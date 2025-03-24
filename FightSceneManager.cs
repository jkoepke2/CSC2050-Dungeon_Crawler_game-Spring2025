using System;
using UnityEngine;

public class fightSceneManager : MonoBehaviour
{
    private Monster theMonster;
    
    public GameObject player;
    public GameObject monster;
    private Fight f;
    private float elapsedTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.theMonster = new Monster("Goblin");
        f = new Fight(this.theMonster);
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime; // Add the time since the last frame to the elapsed time
        if (elapsedTime >= 1f) // Check if one second has passed
        {
            elapsedTime = 0f; // Reset the elapsed time
            if(!Core.thePlayer.isDead() && !this.theMonster.isDead())
            {
                f.attack(player, monster);
            }
        }
    }
}