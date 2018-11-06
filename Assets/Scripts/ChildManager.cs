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
