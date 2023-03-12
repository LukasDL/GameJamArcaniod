using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [Header("StartPoints")]
    [SerializeField] private Transform _spawnPointPlatform1;
    [SerializeField] private Transform _spawnPointPlatform2;
    [SerializeField] private Transform _spawnPointPlatform3;
    [SerializeField] private Transform _spawnPointPlatform4;
    public Transform StartPlatform;

    public List<GameObject> PlatformsList = new(4);


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
            StartPlatform = _spawnPointPlatform1;
        }

        else if (NumberIfmainPlatform == 1)
        {
            StartPlatform = _spawnPointPlatform2;

        }

        else if (NumberIfmainPlatform == 2)
        {
            StartPlatform = _spawnPointPlatform3;

        }

        else if (NumberIfmainPlatform == 3)
        {
            StartPlatform = _spawnPointPlatform4;
        }

        SceneBallCenter.SpawnPoint = StartPlatform;

    }



    public void DestroyPlartform(GameObject _platform)
    {

        _platform.SetActive(false);
    }

    public void NewPlatforms()
    {
        for (int i = 0; i < PlatformsList.Count; i++)
        {

            if (PlatformsList[i].activeSelf == false)
            {
                PlatformsList[i].SetActive (true);
                break;
            }
        }



    }





}
