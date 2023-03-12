using System;
using UnityEngine;


public class EnemyOne : MonoBehaviour
{
    public GameObject center;
    public Vector3 axis;
    public static Action<int> DestrouEnemy;
    [SerializeField] private int numberEnemy = 1;
    public ScoreManager _scoreManager;
  


    //  public ScoreManager ScoreManager;
    void Start()
    {
       
        _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        transform.RotateAround(center.transform.position, axis, 0.1f);
        if (numberEnemy == 0)
        {
            DestroyEnemy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (numberEnemy == 1)
            {
                DestroyEnemy();
            }
            else
            {
                numberEnemy = numberEnemy - 1;
            }
        }
    }
    public void DestroyEnemy()
    {
        
              DestrouEnemy?.Invoke(0);
        Destroy(gameObject);
        _scoreManager.AddScore(100);
        

    }
}
