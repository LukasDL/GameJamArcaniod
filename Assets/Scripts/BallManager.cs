using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    [SerializeField] private Ball _ball;
    public int BallCount;

    List <Ball> BallsList= new ();


    private void Start()
    {
        BallCounter();
    }

    private void Update()
    {
        if (BallCount == 0)
        {
            _ball.BallRestart();
            BallCounter();
        }
    }



    private void BallCounter()
    {

        if (FindObjectOfType<Ball>().gameObject)
        {
            BallCount++;
        }


    }


}
