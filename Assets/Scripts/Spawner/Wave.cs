using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Wave
{
    [SerializeField] public List<GameObject> WaveEnemies;
    [SerializeField] public float timeToNextWave;
}
