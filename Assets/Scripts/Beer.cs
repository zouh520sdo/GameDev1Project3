﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : Interactable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        gameObject.SetActive(false);
    }

    public override string getAction()
    {
      return "Take beer";
    }
}
