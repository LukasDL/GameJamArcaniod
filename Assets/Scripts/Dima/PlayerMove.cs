using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float _radios;
    [SerializeField] private float _speedLerp;
    [SerializeField] private float _angleSpeed;
    private float C;
    private float _angle;
    [SerializeField] private List<GameObject> _platforms;
    [SerializeField] private List<PlatformController> _platformControllers;

    void Start()
    {
        float C = 2f * 3.14f * _radios;
        if (_platforms.Count < 1) return;
        float angleMidle = (C / _platforms.Count);
        print(C);
        for (int i = 0; i < _platforms.Count; i++)
        {
            float angle = angleMidle + i * angleMidle;
            float posX = Mathf.Cos(angle) * _radios;
            float posY = Mathf.Sin(angle) * _radios;
            GameObject platform = Instantiate(_platforms[i], new Vector3(posX, posY, 0f), transform.rotation);
            PlatformController heroControll = platform.GetComponent<PlatformController>();
            heroControll.SetAngles(angle);
            _platformControllers.Add(heroControll);
            platform.transform.parent = transform;
        }
    }
    void Update()
    {

        float vectorSpeed = Input.GetAxis("Horizontal") * _angleSpeed * Time.deltaTime;

        transform.Rotate(0f, 0f, vectorSpeed);

    }

    public void AddPlatform()
    {
        C = 2f * 3.14f * _radios;
        float angleMidle = (C / _platformControllers.Count + 1);
       
        for (int i = 0; i < _platformControllers.Count; i++)
        {
            _platformControllers[i].SetAngles(angleMidle * i);
        }
         PlatformController platform = new PlatformController();
        float angle = _platformControllers.Count * angleMidle;
        float posX = Mathf.Cos(angle) * _radios;
        float posY = Mathf.Sin(angle) * _radios;
        Instantiate(platform.gameObject, new Vector3(posX, posY, 0f), transform.rotation);
        platform.SetAngles(angle);
        _platformControllers.Add(platform);
        platform.transform.parent = transform;
    }

}
