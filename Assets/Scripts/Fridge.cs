﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Interactable {

    public Animator fridgeAnimator;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        fridgeAnimator.SetTrigger("Open");
    }
}
