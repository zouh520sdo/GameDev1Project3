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
            _cm.SwitchToState(ChildManager.ChildrenAnimation.Idle);
        }
        if (_cm.isEatingBad)
        {
            _gm.goodJobCounter++;
            _cm.SwitchToState(ChildManager.ChildrenAnimation.Idle);
        }
        if (_cm.isHoldingBeer)
        {
            _gm.goodJobCounter++;
            _cm.beer.SetActive(false);
        }
    }
}
