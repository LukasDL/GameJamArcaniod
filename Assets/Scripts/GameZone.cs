using UnityEngine;

public class GameZone : MonoBehaviour
{


    [SerializeField] private BallCreatorAndMove _ballRestart;
    public BallManager _ballManager;

    private void OnTriggerEnter(Collider other)
    {


        _ballManager.BallCount--;

        //_ballRestart.BallRestart();



    }





}
