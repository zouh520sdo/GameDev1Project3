using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Interactable {

    public GameObject bowl;

    private Player _player;
	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player").GetComponent<Player>();
        bowl.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        if (_player.hasCookedFood)
        {
            bowl.SetActive(true);
            _player.hasCookedFood = false;

            Debug.Log("Looping thru "+ GameManager1.kids.Count+" kids");
            
            //TODO if child @ table, child eats
            for(int i = 0; i < GameManager1.kids.Count; i++)
            {
                Debug.Log(i+" is "+GameManager1.kids[i].isWaitingForFood());
              if (GameManager1.kids[i].isWaitingForFood())
              {
                GameManager1.kids[i].giveFood();
              }
            }
        }
    }

  public override string getAction()
  {
    if (!bowl.activeSelf)
    {
      if (_player.hasCookedFood)
      {
        return "Place food";
      }
      else
      {
        return "If you have cooked food, place it here";
      }
    }
    return "";
  }
}
