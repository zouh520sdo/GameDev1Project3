using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour {

    public bool occupied;

    public Room roomType;
    public GameManager1 gamemanager;

    public enum Action
    {
        puke,
        flush,
        puckAndFlush,
        beer
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
        }
        catch (System.Exception)
        {

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
