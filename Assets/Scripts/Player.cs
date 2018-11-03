﻿using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Some properties
    public float speed = 10f;
    public float sensitivity = 1f;

    // Inventory
    public List<GameObject> inventory;

    // Room player are current 
    public Room room;

    // Camera
    public CinemachineVirtualCamera myCam;
    private CinemachineComposer _myCamComposer;

    // 
    private SphereCollider pickupTrigger;
    
    private Vector3 _moveDirection;

	// Use this for initialization
	void Start () {
        _moveDirection = new Vector3(0, 0, 0);
        _myCamComposer = myCam.GetCinemachineComponent<CinemachineComposer>();

        // Lock the cursor in the center of screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        // Initialization
        inventory = new List<GameObject>();
        room = Room.none;
    }
	
	// Update is called once per frame
	void Update () {

        // Rotation-related
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        _myCamComposer.m_TrackedObjectOffset.y += Input.GetAxis("Mouse Y") * sensitivity;
        _myCamComposer.m_TrackedObjectOffset.y = Mathf.Max(-100, _myCamComposer.m_TrackedObjectOffset.y);
        _myCamComposer.m_TrackedObjectOffset.y = Mathf.Min(100, _myCamComposer.m_TrackedObjectOffset.y);

        // Reset moving direction
        _moveDirection.x = 0;
        _moveDirection.z = 0;

        // Respond to input
		if (Input.GetKey(KeyCode.A))
        {
            _moveDirection.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveDirection.x = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveDirection.z = -1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            _moveDirection.z = 1;
        }

        // Interaction
        if (Input.GetKey(KeyCode.E))
        {

        }

        transform.Translate(_moveDirection.normalized * speed * Time.deltaTime, Space.Self);
    }

    /// <summary>
    /// For interaction with pickable item
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        // Show pickable indicator icon if any item is avaiable

        // Interaction
        if (Input.GetKey(KeyCode.E))
        {

        }

    }
}
