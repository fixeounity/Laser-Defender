using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : Singleton {

    [SerializeField] int score = 0;

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }
	
	public void ResetGame()
    {
        score = 0;
    }
}
