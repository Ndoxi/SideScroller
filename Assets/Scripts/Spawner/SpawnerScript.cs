using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [Header("List of enemys for curent level (excluding DEFAULT)")]
    public EnemyList enemyList;

    [Header("List of enemys for curent level")]
    [SerializeField] private EnemiesWaveForLevel enemiesWaveForLevel;

    [Header("Ammo for curent level")]
    [SerializeField] private List<GameObject> ammoList;

    private Stack<GameObject> _ammoStack = new Stack<GameObject>();

    //Screen settings
    private float _minY;
    private float _maxY;

    //Enemys data
    private Dictionary<Enemy.EnemyType, GameObject> _enemies = new Dictionary<Enemy.EnemyType, GameObject>();

    //Spawner settings
    private float _nextWave = 0;
    private float _wavesInterval = 5f;


    private void Awake()
    {
        Camera camera = Camera.main;

        Vector2 leftBottomCorner = camera.ViewportToWorldPoint(Vector3.zero);
        Vector2 rightTopCorner = camera.ViewportToWorldPoint(Vector3.one);

        _maxY = rightTopCorner.y + 0.5f;
        _minY = leftBottomCorner.y - 0.5f;
    }


    private void Start()
    {
        //InitializeEnemies();
        //InitializeAmmo();
    }


    private void Update()
    {
        //SpawnWave();
    }


    private void InitializeEnemies()
    {
        foreach (Enemy enemy in enemyList.enemies)
        {
            if (!_enemies.ContainsKey(enemy.enemyType)) {
                _enemies.Add(enemy.enemyType, enemy.enemyPrefab);      
            }
        }
    }


    private void InitializeAmmo()
    {
        foreach (GameObject ammo in ammoList)
        {
            _ammoStack.Push(ammo);
        }
    }


    public void AddAmmo(GameObject ammo)
    {
        _ammoStack.Push(ammo);
    }


    public GameObject GetAmmo()
    {
        if (_ammoStack.Count == 1) { return _ammoStack.Peek(); }
        return _ammoStack.Pop();
    }


    /// <summary>
    /// Add enemy to spawner
    /// </summary>
    /// <param name="newEnemy">Info about new enemy</param>
    public void AddEnemy(Enemy newEnemy)
    {
        if (_enemies.ContainsKey(newEnemy.enemyType)) { return; }

        _enemies.Add(newEnemy.enemyType, newEnemy.enemyPrefab);
    }


    public void SpawnEnemy(Enemy.EnemyType enemyType)
    {
        if (!_enemies.ContainsKey(enemyType)) { return; }

        GameObject newEnemy = Instantiate(_enemies[enemyType]);
        SpriteRenderer sprite = newEnemy.GetComponentInChildren<SpriteRenderer>();

        float size = 1;
        if (sprite != null) { size = sprite.size.y; }

        newEnemy.transform.position = new Vector2(gameObject.transform.position.x, 
            Random.Range(_minY + size, _maxY - size));

        if (enemyType == Enemy.EnemyType.METEOR) { newEnemy.GetComponent<MeteorScript>().loot = GetAmmo(); }
    }


    public void SpawnWave()
    {
        if (_nextWave > Time.time) { return; }
        _nextWave = Time.time + _wavesInterval;

        SpawnEnemy(Enemy.EnemyType.DEFAULT);
        SpawnEnemy(Enemy.EnemyType.DEFAULT);
        SpawnEnemy(Enemy.EnemyType.METEOR);
    }


    public void StartSpawnEnemies()
    {
        StartCoroutine(SpawnEnemies());
    }


    IEnumerator SpawnEnemies()
    {
        foreach (Wave enemyWave in enemiesWaveForLevel.EnemyWeves)
        {
            foreach (GameObject enemy in enemyWave.WaveEnemies)
            {
                SpawnEnemy(enemy);
            }

            yield return new WaitForSeconds(enemyWave.timeToNextWave);
        }
    }


    public void SpawnEnemy(GameObject enemy)
    {
        if (enemy == null) { return; }

        GameObject newEnemy = Instantiate(enemy);
        SpriteRenderer sprite = newEnemy.GetComponentInChildren<SpriteRenderer>();

        float size = 1;
        if (sprite != null) { size = sprite.size.y; }

        newEnemy.transform.position = new Vector2(gameObject.transform.position.x,
            Random.Range(_minY + size, _maxY - size));

        //if (enemyType == Enemy.EnemyType.METEOR) { newEnemy.GetComponent<MeteorScript>().loot = GetAmmo(); }
    }
}
