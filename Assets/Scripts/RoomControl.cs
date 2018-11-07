using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour {

    public bool occupied;

    public Room roomType;
    public GameManager1 gamemanager;
    
    // Use this for initialization
	void Start () {
		
        if (roomType == Room.bathroom)
        {

        }
        else if (roomType == Room.boysroom)
        {

        }
        else if (roomType == Room.girlroom)
        {

        }
        else if (roomType == Room.kitchen)
        {

        }
        else if (roomType == Room.livingroom)
        {

        }
        else if (roomType == Room.momroom)
        {

        }
        ///
	}

    public void takeAction(ChildManager child)
    {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
