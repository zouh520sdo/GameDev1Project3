using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour {

    public bool occupied;

    public Room roomType;
    public GameManager1 gamemanager;
    public Transform sitTranform;

    public enum Action
    {
        // Bathroom
        puke,
        flush,
        puckAndFlush,

        // Boys room
        beer,
        light,
        sit,
        crayon
    }

    public List<Action> actions;
    
    // Use this for initialization
	void Start () {

        actions = new List<Action>();
		
        if (roomType == Room.bathroom)
        {
            actions.Add(Action.puke);
            actions.Add(Action.flush); 
            actions.Add(Action.puckAndFlush);
        }
        else if (roomType == Room.boysroom)
        {
            actions.Add(Action.beer);
        }
        else if (roomType == Room.girlroom)
        {
            actions.Add(Action.beer);
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
            Action action = actions[Random.Range(0, actions.Count)];
            print(name + " pick action " + action);

            if (action == Action.puke)
            {
                gamemanager.pukeInToilet();
            }
            else if (action == Action.flush)
            {
                gamemanager.flushToilet();
            }
            else if (action == Action.puckAndFlush)
            {
                gamemanager.flushAndPuke();
            }
            else if (action == Action.sit)
            {
                gamemanager.sit(child, sitTranform);
            }
            else if (action == Action.beer)
            {
                if (child.tag == "Girl")
                {
                    gamemanager.sit(child, sitTranform);
                }
                else
                {
                    gamemanager.beer(child, sitTranform);
                }
            }
        }
        catch (System.Exception)
        {

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
