using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    /// <summary>
    /// Need to overrided by child class
    /// </summary>
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + name);
    }

    //override in child with appropriate action
    public virtual string getAction()
    {
        return "";
    }

}