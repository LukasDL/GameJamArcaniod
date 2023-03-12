using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public int Score;
    public int ScoreClose;
    public GameObject PlayWin;
    public PlatformManager PlatformMan;
    public BallCreatorAndMove AddBall;

    public AudioSource AudioSource;
    void Start()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        UpdateText();
    }

      void UpdateText()
     {
         ScoreText.text = "SCORE: " + Score.ToString();
     }

    public void Update()
    {
        //    if (ScoreCount.Count == 0)
        //    WinText.gameObject.SetActive(true);
        //    if (ScoreCount.Count == 0)
        //    Iconca.gameObject.SetActive(false);

    }
    public void AddScore(int points)
    {
        Score += points;
        ScoreClose += points;
        ScoreText.text = "Score: " + Score.ToString();
        WinText();
        AudioSource.Play();
    }

    public void NewPlatform()
    {
        if (Score >= 1000)
        {
            PlatformMan.NewPlatforms();
            Score = Score - 1000;
            ScoreText.text = "Score: " + Score.ToString();
        }
    }
    public void NewBall()
    {
        if (Score >= 1000)
        {
            AddBall.AddToBall();
            Score = Score - 1000;
            ScoreText.text = "Score: " + Score.ToString();
        }
    }
    public void NewLife()
    {
        if (Score >= 1000)
        {
            //spawn health
            Score = Score - 1000;
            ScoreText.text = "Score: " + Score.ToString();
        }

    }
        public void WinText()
        {

            if (ScoreClose >= 1130000)
            {
                PlayWin.SetActive(true);

            }

        }



    }

