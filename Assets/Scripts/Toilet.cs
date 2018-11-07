using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : Interactable {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
    }

    public override string getAction()
    {
        return "Flush";
    }
}
