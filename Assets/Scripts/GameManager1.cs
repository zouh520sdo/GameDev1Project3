using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(ChildManager))]
public class GameManager1 : MonoBehaviour {

 
    //for setting destinations/checking previous rooms 
    public ChildManager girl_manager;
    public ChildManager badb_manager;
    public ChildManager mildb_manager;

    //for moving the children according to NavMesh 
    //public UnityEngine.AI.NavMeshAgent girl_agent;
    //public UnityEngine.AI.NavMeshAgent badBoy_agent;
    //public UnityEngine.AI.NavMeshAgent mildBoy_agent;

    /* rooms that each child can go to. In determine choices function, these arrays are copied into a list.
     we check the room that the child was already in (aka the current room they are in) and give it a random other
     'next room' to travel to. we determine this one by one for each child so that the next child will have that choice removed from their
     option of the next room. */
    public Transform[] girlChoices;
    public Transform[] bad_boyChoices;
    public Transform[] mild_boyChoices;

    public Transform livingroom;
    public Transform mom_room;
    public Transform girl_room;
    public Transform boys_room;
    public Transform kitchen;
    public Transform bathroom;

    public float gameTime = 360; //game is 6 minutes long, so 360 seconds 

    // public Transform[] spawnPoints; //array of places children can move to 

    public GameObject[] kids;
    
    public NavMeshAgent girlAgent; //for navMesh navigation
    public NavMeshAgent bad_boyAgent;
    public NavMeshAgent mild_boyAgent;

    // Prefabs for events
    public GameObject pukeObject;
    public Transform pukeTransform;

    public int goodJobCounter;

    bool start_game; 
    
	// Use this for initialization
	void Start () {

        goodJobCounter = 0;

        InvokeRepeating("DetermineChoices", 3.0f, 22.0f); //start the game in 3 seconds, call this function every 22 seconds 
        
        girlAgent.GetComponent<NavMeshAgent>();
        bad_boyAgent.GetComponent<NavMeshAgent>();
        mild_boyAgent.GetComponent<NavMeshAgent>();
       
	}
	
	// Update is called once per frame
	void Update () {

        gameTime -= Time.deltaTime;
      //  print(gameTime);

    }
    /*
    IEnumerator BeginGame()
    {
        yield return new WaitForSeconds(3.0f);
        start_game = true;
    }
    
     currently using this as a reference to determine choices 
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
    public void DetermineChoices()
    {
        //for the girl -------------------------------------------
        List<Transform> temp_girl_choices = new List<Transform>(girlChoices); //copy the list of options for the girl 
        if (temp_girl_choices.Contains(girl_manager.prevRoom))
        {
            temp_girl_choices.Remove(girl_manager.prevRoom); //take the room she was currently in out of the list 
        }
        int girl_index = Random.Range(0, temp_girl_choices.Count); //determine next room randomly 

        Transform girl_next = temp_girl_choices[girl_index];
        girl_manager.nextRoom = girl_next; //make that room the next girls room 

        //for the bad boy ----------------------------------------
        List<Transform> temp_badBoy_choices = new List<Transform>(bad_boyChoices);
        if (temp_badBoy_choices.Contains(badb_manager.prevRoom))
        {
            temp_badBoy_choices.Remove(badb_manager.prevRoom);
        }
        temp_badBoy_choices.Remove(girl_next); //remove the girls next choice from bad boys choices 
        int badB_index = Random.Range(0, temp_badBoy_choices.Count); //get random index of what is left 
        Transform badB_next = temp_badBoy_choices[badB_index];
        badb_manager.nextRoom = badB_next;

        //for the mild boy --------------------------------------
        List<Transform> temp_mildB_choices = new List<Transform>(mild_boyChoices);
        if (temp_mildB_choices.Contains(mildb_manager.prevRoom))
        {
            temp_mildB_choices.Remove(mildb_manager.prevRoom);
        }
        temp_mildB_choices.Remove(girl_next); //remove the girls next room 
        temp_mildB_choices.Remove(badB_next); //remove the bad boys next room 
        int mildB_index = Random.Range(0, temp_mildB_choices.Count);
        Transform mildB_next = temp_mildB_choices[mildB_index];
        mildb_manager.nextRoom = mildB_next;

        //allow the navMeshes of the kids to move to their destionations 
        girl_manager.canMove = true;
        mildb_manager.canMove = true;
        badb_manager.canMove = true;
        
        


    }
    //make the navmesh agent move to the destination 
    public void MoveChildren()
    {
      




    }


    public void pukeInToilet()
    {
        Instantiate(pukeObject, pukeTransform.position, Quaternion.identity);
    }

}
