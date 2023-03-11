using UnityEngine;

public class GameZone : MonoBehaviour
{

    [SerializeField] private BallManager ballManager;


    private void OnTriggerEnter(Collider other)
    {
        ballManager.BallCount--;
    }





}
