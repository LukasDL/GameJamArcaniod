using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverMenu;
    public BallManager _ballManager;

    private void Start()
    {
        _ballManager = GameObject.FindObjectOfType<BallManager>();
    }

    void Update()
    {
        if (_ballManager.BallCount == 0)
        {

            {
                GameOverMenu.SetActive(true);
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverMenu.SetActive(false);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GameOverMenu.SetActive(false);
    }
}
