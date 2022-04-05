using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public RocketStats rocketStats;


    private float playerSpeed;
    private Vector2 playerDirection;
    //private Vector2 screenBounds;
    //private BoxCollider2D boxCollider;
    //private float minX;
    //private float maxX;
    //private float minY;
    //private float maxY;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = rocketStats.speed;
        //SetBounds();
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;

        float x = transform.position.x + playerDirection.x * playerSpeed * Time.deltaTime;
        float y = transform.position.y + playerDirection.y * playerSpeed * Time.deltaTime;

        

        //x = Mathf.Clamp(x, minX, maxX);
        //y = Mathf.Clamp(y, minY, maxY);

        transform.position = new Vector2(x, y);
    }


    //private void SetBounds()
    //{
    //    boxCollider = GetComponent<BoxCollider2D>();
    //    screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    //    //minX = -1 * screenBounds.x + boxCollider.size.x / 2;
    //    //maxX = screenBounds.x - boxCollider.size.x / 2;
    //    //minY = -1 * screenBounds.y + boxCollider.size.y / 2;
    //    //maxY = screenBounds.y - boxCollider.size.y / 2;
    //}
}