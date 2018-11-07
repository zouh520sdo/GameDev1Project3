using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour {

  public static GlobalManager instance = null;
  public int goodJobCounter = 0;
  public List<string> jobs = new List<string>();

  //Awake is always called before any Start functions
  void Awake()
  {
    //Check if instance already exists
    if (instance == null)
    {
      //if not, set instance to this
      instance = this;
    }

    //If instance already exists and it's not this:
    else if (instance != this)
      //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
      Destroy(gameObject);



    //Sets this to not be destroyed when reloading scene
    DontDestroyOnLoad(gameObject);
  }

  // Update is called once per frame
  void Update () {

	}

  public void reset()
  {
    goodJobCounter = 0;
    jobs = new List<string>();
  }
}
