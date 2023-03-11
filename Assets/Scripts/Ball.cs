using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _ballPoint;
    [SerializeField] bool _beginGameCheck;
    [Space]
    [Header("BallStartSpeed")]
    [SerializeField][Range(-10f, 0f)] private float _startForceMinX;
    [SerializeField][Range(0f, 10f)] private float _startForceMaxX;
    [SerializeField][Range(10f, 30f)] private float _startForceMMinY;
    [SerializeField][Range(10f, 30f)] private float _startForceMMaxY;

    Vector3 lastvelocity;
    bool boostCheck = false;
    Vector3 startBallSpeed;

    [SerializeField] private float _tiner;
    void Update()
    {
        if (_beginGameCheck == false)
        {
            transform.position = _ballPoint.position;
            transform.rotation = _ballPoint.rotation;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _beginGameCheck = true;
                _rigidbody.AddRelativeForce(Random.Range(_startForceMinX, _startForceMaxX),
                                            Random.Range(_startForceMMinY, _startForceMMaxY),
                                            0f, ForceMode.VelocityChange);

            }
        }

        else if (_beginGameCheck == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                BallRestart();
            }

        }


        if (boostCheck == false)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                BallSpeedBoost();
                boostCheck = true;
            }
        }

        else if (boostCheck == true)
        {
            BallSpeedNormal();
        }


        lastvelocity = _rigidbody.velocity;


    }


    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.velocity = Vector3.Reflect(lastvelocity, collision.contacts[0].normal);
    }

    public void BallSpeedBoost()
    {
        startBallSpeed = _rigidbody.velocity;
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x * 1.5f, _rigidbody.velocity.y * 1.5f, 0f);

    }

    public void BallSpeedNormal()
    {
        _tiner += Time.deltaTime;
        if (_tiner >= 3f)
        {
            _rigidbody.velocity = startBallSpeed;
            _tiner = 0f;
            boostCheck = false;
        }



    }

    public void BallRestart()
    { 
    _beginGameCheck = false;
                transform.position = _ballPoint.position;
                transform.rotation = _ballPoint.rotation;
                _rigidbody.velocity = Vector3.zero;
        }



}

