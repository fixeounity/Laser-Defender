using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour {

    // Cached references
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameSession gameSession;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }
	
	// Update is called once per frame
	void Update () {
        DisplayScore();
	}

    private void DisplayScore()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
