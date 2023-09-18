using System;
using UnityEngine;

[Serializable]
public struct LevelData
{
    [SerializeField] private string _name;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _minWallsSpawnFrequency;
    [SerializeField] private float _maxWallsSpawnFrequency;
    [SerializeField] private float _minEntrySize;
    [SerializeField] private float _maxEntrySize;

    public string Name => _name;
    public float MovementSpeed => _movementSpeed;
    public float MinWallSpawnFrequency => _minWallsSpawnFrequency;
    public float MaxWallSpawnFrequency => _maxWallsSpawnFrequency;
    public float MinEntrySize => _minEntrySize;
    public float MaxEntrySize => _maxEntrySize;
}