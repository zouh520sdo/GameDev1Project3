﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : Interactable {

    public Animator microwaveAnimator;

    public GameObject bowl;
    public GameObject cube;
    public GameObject bear;

    public GameObject cubeInRoom;
    public GameObject bearInRoom;

    public bool isCooking = false;
    public float cookingTime = 5;

    private GameManager1 _gm;
    private Player _player;
    // Use this for initialization
    void Start () {
        bowl.SetActive(false);
        cube.SetActive(false);
        bear.SetActive(false);

        _player = GameObject.Find("Player").GetComponent<Player>();
        _gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hideBear()
    {
        bear.SetActive(true);
        bearInRoom.SetActive(false);
    }

    public void hideCube()
    {
        cube.SetActive(true);
        cubeInRoom.SetActive(false);
    }

    public void takeBear()
    {
        bear.SetActive(false);
        bearInRoom.SetActive(true);
        _gm.goodJobCounter++;
    }

    public void takeCube()
    {
        cube.SetActive(false);
        cubeInRoom.SetActive(true);
        _gm.goodJobCounter++;
    }

    public override void Interact()
    {
        base.Interact();

        microwaveAnimator.SetTrigger("Open");

        if (bear.activeInHierarchy)
        {
            takeBear();
        }
        if (cube.activeInHierarchy)
        {
            takeCube();
        }

        /*
        if (!isCooking)
        {
            microwaveAnimator.SetTrigger("Open");

            if (cube.activeInHierarchy)
            {
                cube.SetActive(false);
                _player.hasCube = true;
            }

            if (bowl.activeInHierarchy)
            {
                bowl.SetActive(false);
                _player.hasCookedFood = true;
            }

            if (bear.activeInHierarchy)
            {
                bear.SetActive(false);
                _player.hasBear = true;
            }

            if (!bowl.activeInHierarchy && !cube.activeInHierarchy && !bear.activeInHierarchy)
            {
                if (_player.hasBowl)
                {
                    _player.hasBowl = false;
                    bowl.SetActive(true);
                    StartCoroutine(cookingCountDown(cookingTime));
                }
            }
        }*/
    }

    IEnumerator cookingCountDown(float duration)
    {
        isCooking = true;
        float timestamp = Time.time;

        while (Time.time - timestamp < duration)
        {
            yield return null;
        }

        isCooking = false;
    }

  public override string getAction()
  {
    if (!isCooking)
    {
      if (_player.hasBowl)
      {
        return "Cook bowl";
      }
      else
      {
        if (bowl.activeInHierarchy)
        {
          return "Get cooked bowl";
        }
        else
        {
          if (false && microwaveAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !microwaveAnimator.IsInTransition(0))
          {
            return "Open microwave";
          }
        }
      }
    }
    return "Check";
  }
}
