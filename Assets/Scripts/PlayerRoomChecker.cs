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

        if (other.name == "LivingRoomTrigger")
        {
            _player.room = Room.livingroom;
            Debug.Log("Enter living room.");
        }
        if (other.name == "ChildRoomTrigger")
        {
            _player.room = Room.childroom;
            Debug.Log("Enter child room.");
        }
        if (other.name == "KitchenTrigger")
        {
            _player.room = Room.kitchen;
            Debug.Log("Enter kitchen room.");
        }
        if (other.name == "BathroomTrigger")
        {
            _player.room = Room.bathroom;
            Debug.Log("Enter bathroom room.");
        }
        if (other.name == "MomRoomTrigger")
        {
            _player.room = Room.momroom;
            Debug.Log("Enter mom room.");
        }
    }
}
