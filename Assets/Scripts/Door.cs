using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

    public Animator doorAnimator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        doorAnimator.SetTrigger("trigger");
    }
}
