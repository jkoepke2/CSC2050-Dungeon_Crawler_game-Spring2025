using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Room
{
    private Player thePlayer;

    private GameObject[] theDoors;
    private Exit[] availableExits = new Exit[4];
    private int currNumberOfExits = 0;

    private string name;

    public Room(string name)
    {
        this.name = name;
        this.thePlayer = null;
    }

    public string getName()
    {
        return this.name;
    }

    public void tryToTakeExit(string direction)
    {
        if(this.hasExit(direction))
        { 


            if(String.Equals(direction, "north"))
            {
                this.thePlayer = null;
                this.thePlayer.setCurrentRoom(this.availableExits[0].getDestination());
                setPlayer(thePlayer);
            }
            else if(String.Equals(direction, "south"))
            {
                this.thePlayer = null;
                this.thePlayer.setCurrentRoom(this.availableExits[1].getDestination());
                setPlayer(thePlayer);
            }
            else if(String.Equals(direction, "east"))
            {
                this.thePlayer = null;
                this.thePlayer.setCurrentRoom(this.availableExits[2].getDestination());
                setPlayer(thePlayer);
            }
            else if(String.Equals(direction, "west"))
            {
                this.thePlayer = null;
                this.thePlayer.setCurrentRoom(this.availableExits[3].getDestination());
                setPlayer(thePlayer);
            }
            

            //remove the player from the current room
            //place them in the destination room in that direction
            //update the room the player is currently in so the room exits visually update
        }
        else
        {
            Debug.Log("No Exit In This Direction");
        }
    }

    public bool hasExit(string direction)
    {
        for(int i = 0; i < this.currNumberOfExits; i++)
        {
            if(String.Equals(this.availableExits[i].getDirection(), direction))
            {
                return true;
            }
        }
        return false;
    }
    public void setPlayer(Player p)
    {
        this.thePlayer = p;
        this.thePlayer.setCurrentRoom(this);
    }
    public void addExit(string direction, Room destination)
    {
        if(this.currNumberOfExits <= 3)
        {
            Exit e = new Exit(direction, destination);
            this.availableExits[this.currNumberOfExits] = e;
            this.currNumberOfExits++;
        }
        else
        {
            Console.Error.WriteLine("there are too many exits!!!!");
        }
    }

}