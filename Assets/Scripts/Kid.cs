using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : Interactable {

    private ChildManager _cm;
    private GameManager1 _gm;

	// Use this for initialization
	void Start () {
        _cm = GetComponent<ChildManager>();
        _gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        base.Interact();
        if (_cm.isCrying)
        {
            _gm.goodJobCounter++;
            GlobalManager.instance.jobs.Add("Comforted a crying child");
            _cm.SwitchToState(ChildManager.ChildrenAnimation.Idle);
            _cm.isCrying = false;
        }
        if (_cm.isEatingBad)
        {
            _gm.goodJobCounter++;
            GlobalManager.instance.jobs.Add("Took junk food away from a child");
            _cm.SwitchToState(ChildManager.ChildrenAnimation.Idle);
            _cm.isEatingBad = false;
        }
        if (_cm.isHoldingBeer)
        {
            _gm.goodJobCounter++;
            GlobalManager.instance.jobs.Add("Took beer away from a child");
            _cm.beer.SetActive(false);
            _cm.isHoldingBeer = false;
        }
    }

    public override string getAction()
    {
        if (_cm.isCrying)
        {
            return "Comfort";
        }
        if (_cm.isEatingBad)
        {
            return "Stop";
        }
        if (_cm.isHoldingBeer)
        {
            return "Take Beer Away";
        }

        return "";
    }
}
