using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class for set bullet parameters. 
/// <b>All</b> bullet prefabs must contain this script.
/// </summary>
public class Bullet : MonoBehaviour
{
    private Vector2 _direction;
    private float _speed = 0;
    private int _damage = 0;

    private void Awake()
    {
        _direction = new Vector2(1, 0);
    }


    private void Update()
    {
        Move(_direction);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) { return; }

        collision.gameObject.GetComponent<EnemyTemplate>()?.TakeDamage(_damage);
        Destroy(gameObject);
    }


    /// <summary>
    /// Set bullet fligh direction
    /// </summary>
    /// <param name="direction">Fligh direction. Must be set relatively to the spawn point.
    /// <br></br>
    /// <b>Examples:</b>
    /// <br></br>
    /// Vector2(1,0) - fly parallel <b>X</b> axis in positive direction 
    /// <br></br>
    /// Vector2(1,1) - fly in 45 degrees to <b>X</b> axis in positive direction of
    /// <br></br>
    /// Vector2(-1,1) - fly in -45 degrees to <b>X</b> axis in positive direction of
    /// <br></br>
    /// Vector2(-1,0) - fly parallel <b>X</b> axis in negative direction 
    /// </param>
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    /// <summary>
    /// Set bullet fligh direction in degrees
    /// </summary>
    /// <param name="degrees">Angle between bullet flight direction and <b>X</b> axis</param>
    public void SetDirection(float degrees)
    {
        float radians = degrees * Mathf.PI / 180;
        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);
        _direction = new Vector2(x, y);
    }


    /// <summary>
    /// Gets bullet curent flight direction 
    /// </summary>
    /// <returns>Bullet curent flight direction </returns>
    public Vector2 GetDirection()
    {
        return _direction;
    }


    /// <summary>
    /// Set bullet flight speed
    /// </summary>
    /// <param name="speed">Bullet speed</param>
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }


    /// <summary>
    /// Gets bullet curent flight speed 
    /// </summary>
    /// <returns>Bullet speed</returns>
    public float GetSpeed()
    {
        return _speed;
    }


    /// <summary>
    /// Set bullet damage
    /// </summary>
    /// <param name="damage">Bullet damage</param>
    public void SetDamage(int damage)
    {
        _damage = damage;
    }


    /// <summary>
    /// Gets bullet damage
    /// </summary>
    /// <returns>Bullet damage</returns>
    public int GetDamage()
    {
        return _damage;
    }


    /// <summary>
    /// Set bullet rotation in Euler angles
    /// </summary>
    /// <param name="rotation">Bullet rotation in Euler angles</param>
    public void SetRotation(float rotation)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotation);
    }


    /// <summary>
    /// Get bullet rotation in Euler angles
    /// </summary>
    /// <returns>Bullet rotation in Euler angles</returns>
    public float GetRotation()
    {
        return transform.eulerAngles.z;
    }



    /// <summary>
    /// Set bullet parameters
    /// </summary>
    /// <param name="damage">Bullet damage</param>
    /// <param name="speed">Bullet speed</param>
    /// <param name="direction">Bullet direction</param>
    /// <param name="rotation">Bullet rotation in Euler angles</param>
    public void SetBuletParams(int damage, float speed, float direction = 0, float rotation = 0)
    {
        SetDamage(damage);
        SetSpeed(speed);
        SetDirection(direction);
        SetRotation(rotation);
    }


    /// <summary>
    /// Moves bullet in given dirrection
    /// </summary>
    /// <param name="direction">Flight direction</param>
    public void Move(Vector2 direction)
    {
        transform.position = new Vector2(transform.position.x + direction.x * _speed * Time.deltaTime,
            transform.position.y + direction.y * _speed * Time.deltaTime);
    }
}
