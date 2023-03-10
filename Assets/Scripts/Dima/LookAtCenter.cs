using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCenter : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.x == 0)
        {
            transform.position = new Vector3(0.01f, transform.position.y, transform.position.z);
        }
        transform.LookAt(Vector3.zero);
    }
}
