using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    [SerializeField] public List<GameObject> _PlatformsList = new(4);
    public int NumberIfmainPlatform;
    public float deltaOfBallSpawn;


    private void Start()
    {
        //MaonPlatformSelect();

    }
    private void Update()
    {
        MaonPlatformSelect();
    }


    public void DestroyPlartform(GameObject _platform)
    {

        _platform.SetActive(false);
    }

    public void MaonPlatformSelect()
    {
      
            for (int i = 0; i < _PlatformsList.Count; i++)
            {

                if (_PlatformsList[i].activeSelf == true)
                {
                NumberIfmainPlatform = i;
                    break;
                }

            if (NumberIfmainPlatform == 0)
                deltaOfBallSpawn = 0f;

            else if (NumberIfmainPlatform == 1)
                deltaOfBallSpawn = -90f;

            else if (NumberIfmainPlatform == 2)
                deltaOfBallSpawn = 180f;

            else if (NumberIfmainPlatform == 3)
                deltaOfBallSpawn = 90f;          
                
                



            }



        }


    }
