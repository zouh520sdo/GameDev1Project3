using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : Interactable {

    public Animator microwaveAnimator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        microwaveAnimator.SetTrigger("Open");
    }
}
