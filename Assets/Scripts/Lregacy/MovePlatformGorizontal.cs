using System.Runtime.CompilerServices;
using UnityEngine;

public class MovePlatformGorizontal : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField][Range(5f, 50f)] private float _platsformSpeed;

    private void FixedUpdate()
    {

        _rigidbody.AddForce(Input.GetAxis("Horizontal") * 25f, 0f, 0f);
    }

    private void Update()
    {

        transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * _platsformSpeed * Time.deltaTime);

    }


}
