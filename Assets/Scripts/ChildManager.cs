using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChildManager : MonoBehaviour {

    public Transform child_name;
    public GameManager1 game_manager;
    public Transform prevRoom; //room that child was currently in 
    public Transform nextRoom; //next room for child to go to 
    public Transform[] available_rooms; //array of rooms available for child to go to 
    public UnityEngine.AI.NavMeshAgent agent;
    public bool canMove;
    public Door[] Doors;
    //public Door currentDoor;


    public GameObject bowl;
    public GameObject spoon;

    private Animator _animator;
    public enum ChildrenAnimation
    {
        Eat,
        Walk,
        Idle,
        Run,
        Cry,
        SitOnSofa
    }

	// Use this for initialization
	void Start () {
        // For animations
        bowl.SetActive(false);
        spoon.SetActive(false);
        _animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (canMove)
        {
            agent.destination = nextRoom.position;
        }
		
 
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
