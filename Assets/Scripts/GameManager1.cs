using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour {

    public Transform girl;
    public Transform bad_boy;
    public Transform odd_boy;

    //for setting destinations/checking previous rooms 
    public ChildManager girl_manager;
    public ChildManager badb_manager;
    public ChildManager oddb_manager;

    Transform[] girlChoices;
    Transform[] bad_boyChoices;
    Transform[] mild_boyChoices;

    public float gameTime = 360; //game is 6 minutes long, so 360 seconds 
    public Transform[] spawnPoints; //array of places children can move to 
    public GameObject[] kids; 
    public ChildManager[] kidAgents; //for navMesh navigation 
    bool start_game; 
    
	// Use this for initialization
	void Start () {


        StartCoroutine(BeginGame());
        if (start_game)
        {

        }


	}
	
	// Update is called once per frame
	void Update () {

        gameTime -= Time.deltaTime;
        print(gameTime);

    }
    IEnumerator BeginGame()
    {
        yield return new WaitForSeconds(3.0f);
        start_game = true;
    }
    /*
    public void SpawnChildren()
    {
        List<Transform> freeSpawnPoints = new List<Transform>(spawnPoints);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int index = Random.Range(0, freeSpawnPoints.Count);
            Transform pos = freeSpawnPoints[index];
            freeSpawnPoints.RemoveAt(index);
           // Instantiate(kids[i], pos.x, 0, pos.z, pos.rotation);
             Instantiate(kids[i], pos.position, pos.rotation);
        }
    }
    */
    public void MoveChildren()
    {
      //  List<Transform> girl_destinations;
    }


}
