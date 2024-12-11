using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogicManagerScript : MonoBehaviour
{
    private int score = 0;
    private GameObject userInterface;
    private TMP_Text scoreText;

    void Start()
    {
        userInterface = GameObject.Find("UserInterface");
        scoreText = userInterface.gameObject.transform.GetChild(1).GetComponent<TMP_Text>();
    }

    public void updateScore(int scoreToAdd) {
        int oldScore = int.Parse(scoreText.text);
        int newScore = oldScore + scoreToAdd;

        string newText = newScore.ToString();
        scoreText.SetText(newText);
    }
}
