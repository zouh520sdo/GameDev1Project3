using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour {

    public Transform girl;
    public Transform bad_boy;
    public Transform odd_boy;
    public float gameTime = 360; //game is 6 minutes long, so 360 seconds 
    public Transform[] spawnPoints;


	// Use this for initialization
	void Start () {

        



	}
	
	// Update is called once per frame
	void Update () {

        gameTime -= Time.deltaTime;
        print(gameTime);

    }
}
