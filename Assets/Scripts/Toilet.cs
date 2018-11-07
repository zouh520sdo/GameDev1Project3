using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : Interactable {

    public GameObject poop;

    private GameManager1 _gm;

	// Use this for initialization
	void Start () {
        poop.SetActive(false);
        _gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void producePoop()
    {
        poop.SetActive(true);
    }

    public override void Interact()
    {
        base.Interact();
        if (poop.activeInHierarchy)
        {
            poop.SetActive(false);
            _gm.goodJobCounter++;
        }
    }

    public override string getAction()
    {
        return "Flush";
    }
}
