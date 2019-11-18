using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    public Text totalScore;

    // Start is called before the first frame update
    void Start()
    {
        totalScore.text = PlayerPrefs.GetInt("TotalMoney", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public static void UpdateScore(int score)
    {
        score = score + PlayerPrefs.GetInt("TotalMoney", 0);
        PlayerPrefs.SetInt("TotalMoney", score);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("TotalMoney");
        totalScore.text = "0";
    }
}
