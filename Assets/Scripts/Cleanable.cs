using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanable : Interactable {

    public float _completeness;
    public float _fullCompleteness;
    private float _fallOffSpeed;
    private float _increaseSpeed;
    private Player _player;

	// Use this for initialization
	void Start () {
        _completeness = 0;
        _fullCompleteness = 100;
        _fallOffSpeed = 30;
        _increaseSpeed = 8;
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        _completeness = Mathf.Max(0, _completeness - _fallOffSpeed * Time.deltaTime);
    }

    public override void Interact()
    {
        base.Interact();

        _player.cleanable = this;

        _completeness += _increaseSpeed;

        if (_completeness >= _fullCompleteness)
        {
            // Clean it up
            OnCleanUp();
        }
    }

    public virtual void OnCleanUp()
    {

    }
}
