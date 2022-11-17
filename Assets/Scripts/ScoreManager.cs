using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class ScoreManager : NetworkBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;

    public int score = 0;
    public int highscore = 0;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " Score";
        highscoreText.text = "Highscore " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }


    [ClientRpc]
    public void AddScoreClientRpc()
    {
        score += 1;
        scoreText.text = score.ToString() + " Score";
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
