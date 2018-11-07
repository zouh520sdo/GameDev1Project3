using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TextMessages : MonoBehaviour {

    public GameObject babysitter_text;
    public GameObject babysitterBubble;
    public GameObject button;
    

	// Use this for initialization
	void Start () {
        StartCoroutine(ShowTextMessage());
    }
	
	// Update is called once per frame
	void Update () {

        
	}

    IEnumerator ShowTextMessage()
    {
        yield return new WaitForSeconds(6f);
        babysitter_text.SetActive(true);
        babysitterBubble.SetActive(true);
        yield return new WaitForSeconds(3f);
        button.SetActive(true);
        
        
        

    }
}
