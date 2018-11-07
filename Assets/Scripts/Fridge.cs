using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Interactable {

    public Animator fridgeAnimator;

    private Player _player;
	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        fridgeAnimator.SetTrigger("Open");
        _player.hasBowl = true;
    }

  public override string getAction()
  {
    if (!_player.hasBowl)
    {
      return "Get bowl from fridge";
    }
    else
    {
      if (false && fridgeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !fridgeAnimator.IsInTransition(0))
      {
        return "Open fridge";
      }
    }
    return "";
  }
}
