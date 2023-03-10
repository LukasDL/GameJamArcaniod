using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _ballPoint;
    [SerializeField] bool _beginGameCheck;
    [SerializeField][Range(5f, 50f)] private float _startForceX;
    [SerializeField][Range(5f, 50f)] private float _startForceY;

    [SerializeField] private float _speed = 20f;

    Vector3 lastvelocity;
    void Update()
    {

     
        if (_beginGameCheck == false)
        {
            transform.position = _ballPoint.position;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _beginGameCheck = true;
                _rigidbody.AddForce(_startForceX, _startForceY, 0f, ForceMode.VelocityChange);


            }

        }


        else if (_beginGameCheck == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _beginGameCheck = false;
                transform.position = _ballPoint.position;
                _rigidbody.velocity = Vector3.zero;
            }

        }


       lastvelocity = _rigidbody.velocity;


    }

    private void OnCollisionEnter(Collision collision)
    {

        _rigidbody.velocity = Vector3.Reflect(lastvelocity, collision.contacts[0].normal);
    

    }




}
