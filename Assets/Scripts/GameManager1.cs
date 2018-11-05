using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour {

    public Transform girl;
    public Transform bad_boy;
    public Transform odd_boy;
    public float gameTime = 360; //game is 6 minutes long, so 360 seconds 
    public Transform[] spawnPoints;
    public GameObject[] kids;


	// Use this for initialization
	void Start () {


        SpawnChildren();


	}
	
	// Update is called once per frame
	void Update () {

        gameTime -= Time.deltaTime;
        print(gameTime);

    }

    public void SpawnChildren()
    {
        List<Transform> freeSpawnPoints = new List<Transform>(spawnPoints);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int index = Random.Range(0, freeSpawnPoints.Count);
            Transform pos = freeSpawnPoints[index];
            freeSpawnPoints.RemoveAt(index);
            Instantiate(kids[i], pos.position, pos.rotation);
        }
    }


}
