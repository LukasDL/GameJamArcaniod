using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public int ScoreCount;
    void Start()
    {
        UpdateText();
    }

    void UpdateText()
    {
        ScoreText.text = "SCORE: " + ScoreCount.ToString();
    }

    public void Update()
    {
    //    if (ScoreCount.Count == 0)
        //    WinText.gameObject.SetActive(true);
    //    if (ScoreCount.Count == 0)
       //     Iconca.gameObject.SetActive(false);

    }
    public void NewPlatform()
    {

    }
    public void NewBall()
    {

    }
}
