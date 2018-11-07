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
    //public Door[] Doors;
    //public Door currentDoor;

    public RoomControl roomControl;
    

    public GameObject bowl;
    public GameObject spoon;
    public GameObject beer;

    public Door bathroomDoor;

    private bool _needAction;
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
        ResetChild();
        _animator = GetComponent<Animator>();
        _needAction = false;
    }

    public void ResetChild()
    {
        bowl.SetActive(false);
        spoon.SetActive(false);
        if (beer)
        {
            beer.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {

        if (canMove)
        {
            agent.destination = nextRoom.position;
        }

        if (_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "eat")
        {
            bowl.SetActive(true);
            spoon.SetActive(true);
        }
        else
        {
            bowl.SetActive(false);
            spoon.SetActive(false);
        }

        // For animation testing
        /*
        print(_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        */
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SwitchToState(ChildrenAnimation.Cry);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchToState(ChildrenAnimation.Eat);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchToState(ChildrenAnimation.Idle);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchToState(ChildrenAnimation.Run);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SwitchToState(ChildrenAnimation.SitOnSofa);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SwitchToState(ChildrenAnimation.Walk);
        }

        // Reach destination
        if (!agent.hasPath && _needAction && roomControl)
        {
            SwitchToState(ChildrenAnimation.Idle);
            agent.isStopped = true;
            _needAction = false;
            roomControl.takeAction(this);
        }

        if (agent.hasPath)
        {
            _needAction = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Room")
        {
            roomControl = other.GetComponent<RoomControl>();
            if (roomControl.roomType == Room.bathroom)
            {
                bathroomDoor.canOpen = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Room")
        {
            if (roomControl.roomType == Room.bathroom)
            {
                bathroomDoor.canOpen = true;
            }
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

    public void SwitchToState(ChildrenAnimation anim)
    {
        if (anim == ChildrenAnimation.Cry)
        {
            _animator.SetBool("Cry", true);
            _animator.SetBool("Eat", false);
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", false);
            _animator.SetBool("SitOnSofa", false);
            _animator.SetBool("Walk", false);
        }
        else if (anim == ChildrenAnimation.Eat)
        {
            _animator.SetBool("Cry", false);
            _animator.SetBool("Eat", true);
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", false);
            _animator.SetBool("SitOnSofa", false);
            _animator.SetBool("Walk", false);
        }
        else if (anim == ChildrenAnimation.Idle)
        {
            _animator.SetBool("Cry", false);
            _animator.SetBool("Eat", false);
            _animator.SetBool("Idle", true);
            _animator.SetBool("Run", false);
            _animator.SetBool("SitOnSofa", false);
            _animator.SetBool("Walk", false);
        }
        else if (anim == ChildrenAnimation.Run)
        {
            _animator.SetBool("Cry", false);
            _animator.SetBool("Eat", false);
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", true);
            _animator.SetBool("SitOnSofa", false);
            _animator.SetBool("Walk", false);
        }
        else if (anim == ChildrenAnimation.SitOnSofa)
        {
            _animator.SetBool("Cry", false);
            _animator.SetBool("Eat", false);
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", false);
            _animator.SetBool("SitOnSofa", true);
            _animator.SetBool("Walk", false);
        }
        else if (anim == ChildrenAnimation.Walk)
        {
            _animator.SetBool("Cry", false);
            _animator.SetBool("Eat", false);
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", false);
            _animator.SetBool("SitOnSofa", false);
            _animator.SetBool("Walk", true);
        }
    }
}
