using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public static Action<PlatformController> PlatformDie;
    private float _angles = 1f;
    private int _lives = 1;
    private int _energy = 100;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            --_lives;
            if (_lives <= 0 && _energy <= 0)
            {
                PlatformDie?.Invoke(this);
            }
        }
    }
    public void SetLives(int count)
    {
        _lives = count;
    }

    public void SetEnergy(int count)
    {
        _energy = count;
    }  
    public void AddEnergy(int count)
    {
        _energy += count;
    }    
    public void MinuseEnergy(int count)
    {
        _energy -= count;
    }
    public int GetEnergy()
    {
        return _energy;
    }
    public float GetAngles()
    {
        return _angles;
    }
    public void SetAngles(float agles)
    {
        _angles = agles;
    }
}
