using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnerCube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private TMP_InputField _speedInputField;
    [SerializeField] private TMP_InputField _distanceInputField;
    [SerializeField] private TMP_InputField _timeSpawnInputField;

    private float _speed;
    private float _distance;
    private float _timeSpawn;
    private IEnumerator _spawnCubes;

    public float Speed => _speed;
    public float Distance => _distance;

    private void Start()
    {
        _spawnCubes = SpawnCubes();
        StartCoroutine(_spawnCubes);
    }

    private void Update()
    {
        SetSpeed();
        SetDistance();
        SetTimeSpawn();
    }

    private void SetSpeed()
    {
        if (float.TryParse(_speedInputField.text, out float value))
        {
            _speed = value;
        }
    }

    private void SetDistance()
    {
        if (float.TryParse(_distanceInputField.text, out float value))
        {
            _distance = value;
        }
    }

    private void SetTimeSpawn()
    {
        if (float.TryParse(_timeSpawnInputField.text, out float value))
        {
            _timeSpawn = value;       
        }
    }

    private IEnumerator SpawnCubes()
    {
        while (true)
        {
            Cube newCube = Instantiate(_cubePrefab, _spawnPoint.position, Quaternion.identity);
            newCube.SetVolue(_speed, _distance);
            yield return new WaitForSeconds(_timeSpawn);
        }
    }
}
