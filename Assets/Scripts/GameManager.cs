using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Room
{
    none,
    livingroom,
    childroom1,
    childroom2,
    childroom3,
    kitchen,
    bathroom,
    momroom
}

public class GameManager : MonoBehaviour {

    public float gameDuration = 10;


	// Use this for initialization
	void Start () {
        StartCoroutine(GameCountDown(gameDuration));
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
