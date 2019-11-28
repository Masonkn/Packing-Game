using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    public Text totalScore;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        totalScore.text = PlayerPrefs.GetInt("TotalMoney", 0).ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public static void UpdateTotalMoney(int score)
    {
        score = score + PlayerPrefs.GetInt("TotalMoney", 0);
        PlayerPrefs.SetInt("TotalMoney", score);
    }

    public static void UpdateHighScore(int score)
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("TotalMoney");
        totalScore.text = "0";
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
    }
}
