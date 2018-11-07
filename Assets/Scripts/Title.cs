using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

  public float rotationSpeed = 5;
  public Button startButton;
  public Button creditsButton;
  public GameObject credits;

  // Use this for initialization
  void Start () {
    startButton.onClick.AddListener(LoadGameplay);
    creditsButton.onClick.AddListener(ToggleCredits);
    credits.gameObject.SetActive(false);
  }
	
	// Update is called once per frame
	void Update () {
    Vector3 rotation = transform.eulerAngles;

    rotation.y += rotationSpeed * Time.deltaTime; // Standart Left-/Right Arrows and A & D Keys

    transform.eulerAngles = rotation;

    if (Input.GetKey("escape"))
    {
      Application.Quit();
    }
  }

  void LoadGameplay()
  {
    SceneManager.LoadScene("Gameplay");
  }

  void ToggleCredits()
  {
    credits.gameObject.SetActive(!credits.gameObject.activeSelf);
  }
}
