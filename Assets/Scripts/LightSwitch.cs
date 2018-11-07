using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable {

    public Light pointLight;

    public static int numLightsOff = 0;

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

      if (pointLight.enabled)
      {
        LightSwitch.numLightsOff--;
      }
      else
      {
        LightSwitch.numLightsOff++;
      }
  }

  public override string getAction()
  {
    if (pointLight.enabled)
    {
      LightSwitch.numLightsOff++;
      return "Turn off light";
    }
    else
    {
      LightSwitch.numLightsOff--;
      return "Turn on light";
    }
  }
}
