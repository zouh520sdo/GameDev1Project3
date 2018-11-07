using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Interactable {

    public GameObject bowl;

    private Player _player;
	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player").GetComponent<Player>();
        bowl.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        if (_player.hasCookedFood)
        {
            bowl.SetActive(true);
            _player.hasCookedFood = false;
        }
    }
}
