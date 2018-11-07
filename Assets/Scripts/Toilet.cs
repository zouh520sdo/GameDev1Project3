using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : Interactable {

    public GameObject poop;
    private AudioSource _audioSource;

    public AudioClip flush_snd;

    private GameManager1 _gm;

	// Use this for initialization
	void Start () {
        poop.SetActive(false);
        _gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>();

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        _audioSource.clip = flush_snd;
        _audioSource.spatialize = true;
        _audioSource.spatialBlend = 1;
        _audioSource.maxDistance = 50;
        _audioSource.minDistance = 2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void producePoop()
    {
        poop.SetActive(true);
    }

    public void flush()
    {
        _audioSource.Play();
    }

    public override void Interact()
    {
        base.Interact();
        if (poop.activeInHierarchy)
        {
            poop.SetActive(false);
            _gm.goodJobCounter++;
        }
    }

    public override string getAction()
    {
        return "Flush";
    }
}
