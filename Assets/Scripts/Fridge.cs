using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Interactable {

    public Animator fridgeAnimator;

    private Player _player;
	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        fridgeAnimator.SetTrigger("Open");
        _player.hasBowl = true;
    }
}
