using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridger : Interactable {

    public Animator fridgerAnimator;

	// Use this for initialization
	void Start () {
        Debug.Log("I'm fridger.");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        fridgerAnimator.SetTrigger("Open");
    }
}
