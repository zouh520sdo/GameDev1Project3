using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndTextMessages : MonoBehaviour
{

  public GameObject babysitter_text;
  public GameObject babysitterBubble;
  public Text mom_text;
  public GameObject momBubble;
  public GameObject button;
  public Button continueButton;

  public GameObject allPhone;
  public Text ScoreSummary;

  // Use this for initialization
  void Start()
  {
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;

    StartCoroutine(ShowTextMessage());
    continueButton.onClick.AddListener(summarizeScore);
  }

  // Update is called once per frame
  void Update()
  {


  }

  IEnumerator ShowTextMessage()
  {
    yield return new WaitForSeconds(6f);
    setMomText();
    yield return new WaitForSeconds(6f);
    button.SetActive(true);




  }

  public void setMomText()
  {
    if (GlobalManager.instance != null)
    {
      Debug.Log(GlobalManager.instance.goodJobCounter);

      if (GlobalManager.instance.goodJobCounter <= 0)
      {
        mom_text.text = "Oh, right. It was such a disaster when I got back that I forgot I even hired a sitter! Come by when you have a chance and I can pay you exactly as much as that job deserved- one dollar. Its thanks to people like you that I should never, ever leave home.";
      }
      else if (GlobalManager.instance.goodJobCounter <= 5)
      {
        mom_text.text = "Well, it was messy. I thought you might be different, you know, but last night ended just like every other night. I thought maybe I would have a nice break away from mothering, but clearly I should never have left home. That being said, you did the best you could with a difficult crowd. I'll send you a check for $50.";
      }
      else if (GlobalManager.instance.goodJobCounter <= 10)
      {
        mom_text.text = "I expected total disaster when I came home last night, but all that I found was very slight evidence of disaster. Thank you for watching them, even one night off is very hard to get. I'll mail you a check for $100. You did a great job!";
      }
      else if (GlobalManager.instance.goodJobCounter <= 15)
      {
        mom_text.text = "Thank you so much for watching them last night! I know they can be little gremlins but everything was almost spotless! I couldn't believe it. I was starting to believe I shouldn't ever leave home, but you proved me wrong. I'll send you a check for $200. Thank you so much!";
      }
      else
      {
        mom_text.text = "Hah! Okay? Everything was more than okay. It was beautiful! The kids... they were like angels! The house looked like it was someone else's, it was so clean. I actually broke down and started crying, I had never seen it so spotless. Please accept this $1000 check I am mailing you. I want you to never leave my home!";
      }
    }
    mom_text.gameObject.SetActive(true);
    momBubble.SetActive(true);
  }

  public void summarizeScore()
  {
    allPhone.SetActive(false);
    ScoreSummary.gameObject.SetActive(true);
    StartCoroutine(listScoreItems());
    continueButton.onClick.AddListener(SwitchScene);
  }

  IEnumerator listScoreItems()
  {
    ScoreSummary.text = "SUMMARY OF SCORE:\n\n";
    for (int i = 0; i < GlobalManager.instance.jobs.Count; i++)
    {
      yield return new WaitForSeconds(0.4f);
      ScoreSummary.text += GlobalManager.instance.jobs[i]+" (+1pts)\n";
    }
    yield return new WaitForSeconds(0.4f);
    ScoreSummary.text += "\nTOTAL SCORE: "+GlobalManager.instance.goodJobCounter.ToString()+" POINTS"; ;
  }

  public void SwitchScene()
  {
    SceneManager.LoadScene("Title");
  }
}
