using UnityEngine;

public class UltaLasers : MonoBehaviour
{

    [SerializeField] GameObject _lasers;
    [SerializeField] GameObject _ball;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            _lasers.SetActive(true);
            _ball.SetActive(false);

        }








    }
}
