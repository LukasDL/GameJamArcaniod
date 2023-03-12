
using UnityEngine;

public class BallCreatorAndMove : MonoBehaviour
{
    [Header("SpawnBall")]
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Transform PlatformCenter;
    public PlatformManager _platformManager;

    [Space]
    public Transform SpawnPoint;
    public GameObject ball;
    Rigidbody _ballRigitbody;

    [Space]
    [Header("MoveBall")]
    [SerializeField] bool _checkGameBegin;

    [SerializeField][Range(0f, 25f)] private float _startForceUp;
    [SerializeField][Range(0f, 15f)] private float _startForceLeftRight;


    [Header("TEST")]
    [SerializeField] private float _timeOfBoost;
    private Vector3 lastvelocity;
    private bool boostCheck = false;
    private Vector3 startBallSpeed;
    private float _tiner;


    void Start()
    {

        ball = CreateBall();
        _ballRigitbody = ball.GetComponent<Rigidbody>();

    }


    void Update()
    {
        lastvelocity = _ballRigitbody.velocity;


        if (_checkGameBegin == false)
        {
            AddForceToBall();
        }

        else if (_checkGameBegin == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                BallRestart();
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ball = CreateBall();
            _ballRigitbody = ball.GetComponent<Rigidbody>();

            AddForceToBall();


        }




            ////////////       Activate Boost Speed x2     /////////////////

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



        


    }



    private void OnCollisionEnter(Collision collision)
    {
        _ballRigitbody.velocity = Vector3.Reflect(lastvelocity, collision.contacts[0].normal);
    }

    public GameObject CreateBall()
    {
        GameObject spawnBall = Instantiate(_ballPrefab, SpawnPoint.position, Quaternion.identity);
       // BallManager.BallssList.Add(spawnBall);
        return spawnBall;

    }



    public void BallSpeedBoost()
    {
        startBallSpeed = _ballRigitbody.velocity;
        _ballRigitbody.velocity = new Vector3(_ballRigitbody.velocity.x * 1.5f, _ballRigitbody.velocity.y * 1.5f, 0f);

    }

    public void BallSpeedNormal()
    {
        _tiner += Time.deltaTime;
        if (_tiner >= _timeOfBoost)
        {
            _ballRigitbody.velocity = startBallSpeed;
            _tiner = 0f;
            boostCheck = false;
        }
    }
    public void BallRestart()
    {
        _platformManager.MainPlatformSelected();

        _checkGameBegin = false;
        _ballRigitbody.velocity = Vector3.zero;
        
    }

    public void AddForceToBall()
    {

        ball.transform.position = SpawnPoint.position;
        ball.transform.rotation = SpawnPoint.rotation;

        if (Input.GetKeyDown(KeyCode.Space))
        {

            _ballRigitbody.AddRelativeForce(Random.Range(-1f, 1f) * _startForceLeftRight, _startForceUp, 0f,
                                            ForceMode.VelocityChange);
            _checkGameBegin = true;
        }

    }



}
