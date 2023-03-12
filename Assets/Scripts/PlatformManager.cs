using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [Header("StartPoints")]
    [SerializeField] private Transform _pointPlatform1;
    [SerializeField] private Transform _pointPlatform2;
    [SerializeField] private Transform _pointPlatform3;
    [SerializeField] private Transform _pointPlatform4;
    public Transform StartPlatform;

    [SerializeField] private List<GameObject> PlatformsList = new(4);
    [SerializeField] private int NumberIfmainPlatform;
    [SerializeField] private Vector3 deltaOfBallSpawn;
    [SerializeField] private BallCreatorAndMove SceneBallCenter;




    private void Start()
    {
        MainPlatformSelected();
    }


    public void MainPlatformSelected()
    {

        for (int i = 0; i < PlatformsList.Count; i++)
        {

            if (PlatformsList[i].activeSelf == true)
            {
                NumberIfmainPlatform = i;
                break;
            }
        }


        if (NumberIfmainPlatform == 0)
        {
            StartPlatform = _pointPlatform1;
        }

        else if (NumberIfmainPlatform == 1)
        {
            StartPlatform = _pointPlatform2;

        }

        else if (NumberIfmainPlatform == 2)
        {
            StartPlatform = _pointPlatform3;

        }

        else if (NumberIfmainPlatform == 3)
        {
            StartPlatform = _pointPlatform4;
        }

        SceneBallCenter.SpawnPoint = StartPlatform;


    }



    public void DestroyPlartform(GameObject _platform)
    {

        _platform.SetActive(false);
    }


}
