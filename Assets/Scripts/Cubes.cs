using UnityEngine;

public class Cubes : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        Destroy(gameObject);

    }
}
