using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


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

    public Text time;
    public float gameTime = 360; //game is 6 minutes long, so 360 seconds 
    private float timeElapsed = 0;

    // public Transform[] spawnPoints; //array of places children can move to 

    public GameObject[] kids;
    
    public NavMeshAgent girlAgent; //for navMesh navigation
    public NavMeshAgent bad_boyAgent;
    public NavMeshAgent mild_boyAgent;

    // Prefabs for events
    public GameObject pukeObject;
    public Transform pukeTransform;
    public GameObject crayonPrefab;
    public TV tv;
    public Microwave microwave;
    public GameObject bowl;

    public int goodJobCounter;

    bool start_game; 
    
	// Use this for initialization
	void Start () {

        goodJobCounter = 0;

        InvokeRepeating("DetermineChoices", 3.0f, 40.0f); //start the game in 3 seconds, call this function every 22 seconds 
        
        girlAgent.GetComponent<NavMeshAgent>();
        bad_boyAgent.GetComponent<NavMeshAgent>();
        mild_boyAgent.GetComponent<NavMeshAgent>();
       
	}
	
	// Update is called once per frame
	void Update () {

        timeElapsed = gameTime - Time.time;
        if ((360 -timeElapsed)%60 >= 10)
            time.text = "" + ((int)(3 + (360 - timeElapsed) / 60)) + ":" + ((int)(360 - timeElapsed) % 60);
        else
            time.text = "" + ((int)(3 + (360 - timeElapsed) / 60)) + ":0" + ((int)(360 - timeElapsed) % 60);

        //  print(gameTime);

    }

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
        girl_manager.ResetChild();
        girl_manager.agent.isStopped = false;
        girl_manager.SwitchToState(ChildManager.ChildrenAnimation.Run);

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
        badb_manager.ResetChild();
        badb_manager.agent.isStopped = false;
        badb_manager.SwitchToState(ChildManager.ChildrenAnimation.Run);

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
        mildb_manager.ResetChild();
        mildb_manager.agent.isStopped = false;
        mildb_manager.SwitchToState(ChildManager.ChildrenAnimation.Run);

        //allow the navMeshes of the kids to move to their destionations 
        girl_manager.canMove = true;
        mildb_manager.canMove = true;
        badb_manager.canMove = true;

        // For bowl
        bowl.SetActive(true);
        // For TV
        tv.StopTV();
    }
   
    // Puke
    public void pukeInToilet()
    {
        Instantiate(pukeObject, pukeTransform.position, Quaternion.identity);
    }

    // Flush
    public void flushToilet()
    {
        // Playing flushing sound
    }

    // Flush and puke
    public void flushAndPuke()
    {
        // Playing flushing sound
        Instantiate(pukeObject, pukeTransform.position, Quaternion.identity);
    }

    public void sit(ChildManager child, Transform sitTransform)
    {
        child.transform.position = sitTransform.position;
        child.transform.rotation = sitTransform.rotation;

        child.SwitchToState(ChildManager.ChildrenAnimation.SitOnSofa);
    }

    public void beer(ChildManager child, Transform sitTransform)
    {
        if (child.beer)
        {
            child.beer.SetActive(true);
            child.isHoldingBeer = true;
        }
        child.transform.position = sitTransform.position;
        child.transform.rotation = sitTransform.rotation;

        child.SwitchToState(ChildManager.ChildrenAnimation.SitOnSofa);
    }

    public void crayon(Transform crayonTransform)
    {
        Instantiate(crayonPrefab, crayonTransform.position, crayonTransform.rotation);
    }

    public void goodTV(ChildManager child, Transform sitTransform)
    {
        // Sit
        child.transform.position = sitTransform.position;
        child.transform.rotation = sitTransform.rotation;

        child.SwitchToState(ChildManager.ChildrenAnimation.SitOnSofa);

        // Play good TV
        tv.PlayTV(tv.goodClip);
    }

    public void badTV(ChildManager child, Transform sitTransform)
    {
        // Sit
        child.transform.position = sitTransform.position;
        child.transform.rotation = sitTransform.rotation;

        child.SwitchToState(ChildManager.ChildrenAnimation.SitOnSofa);

        // Play bad TV
        tv.PlayTV(tv.badClip);
    }

    public void sadTV(ChildManager child, Transform sitTransform)
    {
        child.transform.position = sitTransform.position;
        child.transform.rotation = sitTransform.rotation;

        child.SwitchToState(ChildManager.ChildrenAnimation.Cry);
        child.isCrying = true;
        // Play sad TV
        tv.PlayTV(tv.sadClip);
    }

    public void eat(ChildManager child, Transform sitTransform)
    {
        child.transform.position = sitTransform.position;
        child.transform.rotation = sitTransform.rotation;

        bowl.SetActive(false);
        child.isEatingBad = true;
        child.SwitchToState(ChildManager.ChildrenAnimation.Eat);
    }

    public void hideBear(ChildManager child, Transform sitTransform)
    {
        child.transform.position = sitTransform.position;
        child.transform.rotation = sitTransform.rotation;

        child.SwitchToState(ChildManager.ChildrenAnimation.SitOnSofa);
        microwave.hideBear();
    }

    public void hideCube(ChildManager child, Transform sitTransform)
    {
        child.transform.position = sitTransform.position;
        child.transform.rotation = sitTransform.rotation;

        child.SwitchToState(ChildManager.ChildrenAnimation.SitOnSofa);
        microwave.hideCube();
    }
}
