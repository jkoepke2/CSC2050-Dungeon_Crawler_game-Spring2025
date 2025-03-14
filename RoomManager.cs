using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] theDoors;
    public GameObject mmRoomPrefab;
    private Dungeon theDungeon;
    private Dictionary<string, GameObject> instantiatedRooms = new Dictionary<string, GameObject>();
    private Vector3 currentMapPosition = Vector3.zero;

    void Awake()
    {
        currentMapPosition = new Vector3(20, 0, 0);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Core.thePlayer = new Player("Mike");
        this.theDungeon = new Dungeon();
        this.setupRoom();
    }

    //disable all doors
    private void resetRoom()
    {
        this.theDoors[0].SetActive(false);
        this.theDoors[1].SetActive(false);
        this.theDoors[2].SetActive(false);
        this.theDoors[3].SetActive(false);
    }

    //show the doors appropriate to the current room
    private void setupRoom()
    {
        Room currentRoom = Core.thePlayer.getCurrentRoom();
        this.theDoors[0].SetActive(currentRoom.hasExit("north"));
        this.theDoors[1].SetActive(currentRoom.hasExit("south"));
        this.theDoors[2].SetActive(currentRoom.hasExit("east"));
        this.theDoors[3].SetActive(currentRoom.hasExit("west"));
    }

    // Update is called once per frame
    void Update()
    {
        Room currentRoom = Core.thePlayer.getCurrentRoom();
        Vector3 position = new Vector3(0, 0, 0);
        bool didChangeRoom = false;
        if(Input.GetKeyDown(KeyCode.UpArrow) && currentRoom.hasExit("north"))
        {
            //try to goto the north
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("north");
            position = new Vector3(0, 0, 1.2f);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && currentRoom.hasExit("west"))
        {
            //try to goto the west
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("west");
            position = new Vector3(-1.2f, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && currentRoom.hasExit("east"))
        {
            //try to goto the east
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("east");
            position = new Vector3(1.2f, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && currentRoom.hasExit("south"))
        {
            //try to goto the south
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("south");
            position = new Vector3(0, 0, -1.2f);
        }

        //did we change rooms?
        if(didChangeRoom)
        {
            currentMapPosition += position;
        
            this.setupRoom();
        
            // Check if we've already instantiated a room for this position
            string positionKey = $"{currentMapPosition.x},{currentMapPosition.y},{currentMapPosition.z}";
        
            if(!instantiatedRooms.ContainsKey(positionKey))
            {
                // Create a new room representation
                GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                newMMRoom.transform.position = currentMapPosition;
            
                // Store the reference
                instantiatedRooms[positionKey] = newMMRoom;
            }
        }
    }
}