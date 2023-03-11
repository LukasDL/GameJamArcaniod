using UnityEngine;
public class Laser : MonoBehaviour
{

    [SerializeField] private GameObject _laser;
    [SerializeField] private float _lengh = 25f;
    [SerializeField] private float _scaleSpeed = 10f;
    private bool _laserOn = false;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _laserOn = true;
        }

        if (_laserOn == true)
        {
            LaserActivate(_laser, _lengh, _scaleSpeed);
        }

    }


    public void LaserActivate(GameObject laser, float lengh, float scaleSpeed)
    {

        _laser.SetActive(true);

        if (laser.transform.localScale.y <= lengh )
        {
            _laser.transform.localScale += new Vector3(0f, scaleSpeed, 0f) * Time.deltaTime;

        }





    }
}
