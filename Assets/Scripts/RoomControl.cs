using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour {

    public bool occupied;

    public Room roomType;
    public GameManager1 gamemanager;
    public Transform sitTranform;
    public Transform crayonTransform;

    public enum Action
    {
        // Bathroom
        puke,
        flush,
        puckAndFlush,

        // bedroom
        beer,
        light,
        sit,
        crayon,

        // Living room
        goodTV,
        badTV,
        sadTV,

        // Kitchen
        hideBear,
        hideCube,
        eat,
        openFridge
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
            actions.Add(Action.crayon);
            actions.Add(Action.sit);
            actions.Add(Action.beer);
        }
        else if (roomType == Room.girlroom)
        {
            actions.Add(Action.crayon);
            actions.Add(Action.sit);
            actions.Add(Action.beer);
        }
        else if (roomType == Room.kitchen)
        {
            //actions.Add(Action.sit);
            actions.Add(Action.hideCube);
            actions.Add(Action.hideBear);
            actions.Add(Action.eat);
        }
        else if (roomType == Room.livingroom)
        {
            actions.Add(Action.sit);
            actions.Add(Action.sadTV);
            actions.Add(Action.badTV);
            actions.Add(Action.goodTV);
        }
        else if (roomType == Room.momroom)
        {
            actions.Add(Action.crayon);
            actions.Add(Action.sit);
            actions.Add(Action.beer);
        }
        ///
	}

    public void takeAction(ChildManager child)
    {
        try
        {
            Action action = actions[Random.Range(0, actions.Count)];
            print(child.name + " pick action " + action + " to " + child.nextRoom);

            if (action == Action.puke)
            {
                gamemanager.pukeInToilet(child);
            }
            else if (action == Action.flush)
            {
                gamemanager.flushToilet();
            }
            else if (action == Action.puckAndFlush)
            {
                gamemanager.flushAndPuke(child);
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
            else if (action == Action.crayon)
            {
                gamemanager.crayon(crayonTransform);
            }
            else if (action == Action.goodTV)
            {
                gamemanager.goodTV(child, sitTranform);
            }
            else if (action == Action.badTV)
            {
                gamemanager.badTV(child, sitTranform);

            }
            else if (action == Action.sadTV)
            {
                gamemanager.sadTV(child, sitTranform);
            }
            else if (action == Action.eat)
            {

                Debug.Log("bowl is "+gamemanager.bowl.activeSelf);
                if (gamemanager.bowl.activeSelf)
                {
                  gamemanager.eat(child, sitTranform);
                }
                else
                {
                  child.isWaitingForFood = true;
                  gamemanager.sit(child, sitTranform);
                }
            }
            else if (action == Action.hideBear)
            {
                gamemanager.hideBear(child, sitTranform);
            }
            else if (action == Action.hideCube)
            {
                gamemanager.hideCube(child, sitTranform);
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
