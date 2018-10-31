using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float gameDuration = 180;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator GameCountDown(float duration)
    {
        float timestamp = Time.time;
        while (Time.time - timestamp < duration)
        {
            yield return null;
        }

        print("Game ends");
    }
}
