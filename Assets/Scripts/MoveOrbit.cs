using UnityEngine;

public class MoveOrbit : MonoBehaviour
{

    [SerializeField] private float _rotateSpeed;
    Vector3 _rotationY = new(0f, 0f, 1f);


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localEulerAngles += _rotationY * Time.deltaTime * _rotateSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles -= _rotationY * Time.deltaTime * _rotateSpeed;
        }



    }
    



}

