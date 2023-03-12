using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    [SerializeField] private BallCreatorAndMove _ballRestart;
    public int BallCount;

    public List <GameObject> BallssList = new();

    private void Start()
    {
       // BallCounter();
    }

    private void Update()
    {
        
            //_ballRestart.BallRestart();
            //BallCounter();
        
    }



    private void BallCounter()
    {



    }







}
