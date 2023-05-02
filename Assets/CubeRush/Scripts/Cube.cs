using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _speed;
    private float _distance;
    private float _movedDistance = 0;

    private void Update()
    {
        Move();
    }

    public void SetVolue(float speed, float distance)
    {
        _speed = speed;
        _distance = distance;
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        _movedDistance += _speed * Time.deltaTime;

        if (_movedDistance >= _distance)
        {
            Destroy(gameObject);
        }
    }
}

