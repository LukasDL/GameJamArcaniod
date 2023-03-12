using UnityEngine;

public class GameZone : MonoBehaviour
{


    [SerializeField] private BallCreatorAndMove _ballRestart;


    private void OnTriggerEnter(Collider other)
    {

        _ballRestart.BallRestart();
        //ballManager.BallCount--;

    }





}
