using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChildManager : MonoBehaviour {

    public Transform child_name;
    public GameManager1 game_manager;
    public Vector3 spawnPoint; //destination for child to move to 
    public Transform prevRoom; //room that child was currently in 
    public Transform nextRoom; //next room for child to go to 
    public Transform[] available_rooms; //array of rooms available for child to go to 
    public NavMeshAgent agent;


    public GameObject bowl;
    public GameObject spoon;


	// Use this for initialization
	void Start () {
        bowl.SetActive(false);
        spoon.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerStay(Collider other) //to keep track of where the child already was 
    {
        if(other.gameObject.name == "LivingRoomTrigger")
        {
            prevRoom = available_rooms[0];
        }
        if (other.gameObject.name == "GirlRoomTrigger")
        {
            prevRoom = available_rooms[1];
        }
        if (other.gameObject.name == "BoysRoomTrigger")
        {
            prevRoom = available_rooms[2];
        }
        if (other.gameObject.name == "MomRoomTrigger")
        {
            prevRoom = available_rooms[3];
        }
        if (other.gameObject.name == "KitchenTrigger")
        {
            prevRoom = available_rooms[4];
        }
        if (other.gameObject.name == "BathroomTrigger")
        {
            prevRoom = available_rooms[5];
        }

    }
}
