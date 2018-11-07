using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

    public Animator doorAnimator;
    //must have access to children scripts so door can open when near 
    public ChildManager GirlChildManager;
    public ChildManager BadBoyManager;
    public ChildManager MildBoyManager;
    public bool canOpen;

    public Transform associatedRoom;


    // Use this for initialization
    void Start () {
        canOpen = true;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        if (canOpen)
        {
            doorAnimator.SetTrigger("trigger");
        }
    }

    public void OpenCloseDoor()
    {
        doorAnimator.SetTrigger("trigger");

    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Girl" || other.name == "bad_boy" || other.name == "mild_boy")
        {
            OpenCloseDoor();
          //  StartCoroutine(WaitToClose);

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.name == "Girl" || other.name == "bad_boy" || other.name == "mild_boy")
        {
            OpenCloseDoor();
            //  StartCoroutine(WaitToClose);

        }
    }
    private void StartCoroutine(Func<IEnumerator> waitToClose)
    {
        throw new NotImplementedException();
    }

    IEnumerator WaitToClose()
    {
        yield return new WaitForSeconds(2.0f);
        OpenCloseDoor();
    }
}
