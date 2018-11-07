using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable {

    public Light pointLight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        pointLight.enabled = !pointLight.enabled;
    }

  public override string getAction()
  {
    if (pointLight.enabled)
    {
      return "Turn off light";
    }
    else return "Turn on light";
  }
}
