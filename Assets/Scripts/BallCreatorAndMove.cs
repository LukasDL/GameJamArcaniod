
using UnityEngine;

public class BallCreatorAndMove : MonoBehaviour
{
    [Header("SpawnBall")]
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject PlatformCenter;
    public float _deltaRotateZ;
    public GameObject ball;
    Rigidbody _ballRigitbody;

    [Space]
    [Header("MoveBall")]
    [SerializeField] bool _checkGameBegin;

    [SerializeField][Range(-10f, 0f)] private float _startForceMinX;
    [SerializeField][Range(0f, 10f)] private float _startForceMaxX;
    [SerializeField][Range(10f, 30f)] private float _startForceY;

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
            ball.transform.position = spawnPoint.position;
            _deltaRotateZ = PlatformCenter.GetComponent<PlatformManager>().deltaOfBallSpawn;

            transform.rotation = Quaternion.EulerRotation(PlatformCenter.transform.rotation.x,
                                                PlatformCenter.transform.rotation.y,
                                                PlatformCenter.transform.rotation.z + _deltaRotateZ);





            if (Input.GetKeyDown(KeyCode.Space))
            {

                _ballRigitbody.AddRelativeForce(Random.Range(_startForceMinX, _startForceMaxX),
                    _startForceY, 0f, ForceMode.VelocityChange);
                _checkGameBegin = true;

            }
        }

        else if (_checkGameBegin == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                BallRestart();
            }

        }



        //if (boostCheck == false)
        //{
        //    if (Input.GetKeyDown(KeyCode.T))
        //    {
        //        BallSpeedBoost();
        //        boostCheck = true;
        //    }
        //}

        //else if (boostCheck == true)
        //{
        //    BallSpeedNormal();
        //}





    }



    public GameObject CreateBall()
    {
        GameObject spawnBall = Instantiate(_ballPrefab, spawnPoint.position, Quaternion.identity);
        return spawnBall;

    }

    private void OnCollisionEnter(Collision collision)
    {
        _ballRigitbody.velocity = Vector3.Reflect(lastvelocity, collision.contacts[0].normal);
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
        _checkGameBegin = false;
        // ball.transform.rotation = spawnPoint.rotation;
        _ballRigitbody.velocity = Vector3.zero;
    }


}
