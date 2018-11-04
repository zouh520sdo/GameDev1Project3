using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomChecker : MonoBehaviour {

    private Player _player;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "LivingRoomTrigger" && _player.room != Room.livingroom)
        {
            _player.room = Room.livingroom;
            Debug.Log("Enter living room.");
        }
        if (other.name == "Child1RoomTrigger" && _player.room != Room.childroom1)
        {
            _player.room = Room.childroom1;
            Debug.Log("Enter child 1 room.");
        }
        if (other.name == "Child2RoomTrigger" && _player.room != Room.childroom2)
        {
            _player.room = Room.childroom2;
            Debug.Log("Enter child 2 room.");
        }
        if (other.name == "Child3RoomTrigger" && _player.room != Room.childroom3)
        {
            _player.room = Room.childroom3;
            Debug.Log("Enter child 3 room.");
        }
        if (other.name == "KitchenTrigger" && _player.room != Room.kitchen)
        {
            _player.room = Room.kitchen;
            Debug.Log("Enter kitchen room.");
        }
        if (other.name == "BathroomTrigger" && _player.room != Room.bathroom)
        {
            _player.room = Room.bathroom;
            Debug.Log("Enter bathroom room.");
        }
        if (other.name == "MomRoomTrigger" && _player.room != Room.momroom)
        {
            _player.room = Room.momroom;
            Debug.Log("Enter mom room.");
        }
    }
}
