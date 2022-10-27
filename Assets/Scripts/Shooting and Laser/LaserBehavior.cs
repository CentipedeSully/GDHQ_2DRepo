using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SullysToolkit;

public class LaserBehavior : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _lifeExpectancy = 5;
    [SerializeField] private float _currentLifetime = 0;

    private bool _isEnabled = false;


    private void Update()
    {
        TrackLifetime();
        MoveLaser();
    }


    private void OnDisable()
    {
        ResetProjectile();
        PoolSelf();
    }


    public void EnableLaserBehavior()
    {
        if (!_isEnabled)
            _isEnabled = true;
        //else Debug.LogError("Attempting to enable laser that's already enabled");
    }

    private void TrackLifetime()
    {
        if (_isEnabled)
        {
            _currentLifetime += Time.deltaTime;

            if (_currentLifetime >= _lifeExpectancy)
            {
                _isEnabled = false;
                gameObject.SetActive(false);
            }
        }
    }

    private void MoveLaser()
    {
        transform.Translate(Vector2.up * Time.deltaTime * _moveSpeed);
    }

    private void ResetProjectile()
    {
        _currentLifetime = 0;
        _isEnabled = false;

    }

    private void PoolSelf()
    {
        ObjectPooler.PoolObject(this.gameObject);
    }

}