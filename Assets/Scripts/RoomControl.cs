using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour {

    public bool occupied;

    public Room roomType;
    public GameManager1 gamemanager;

    public List<string> actions;
    
    // Use this for initialization
	void Start () {

        actions = new List<string>();
		
        if (roomType == Room.bathroom)
        {
            actions.Add("puke");
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
        try
        {
            string action = actions[Random.Range(0, actions.Count)];
            print(name + " pick action " + action);
        }
        catch (Exception)
        {

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
