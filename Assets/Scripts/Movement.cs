using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 5;
    public int boost = 2;
    public float maxX = 10.2f;
    public float minX = -10.2f;
    public float maxY = 4.5f;
    public float minY = -4.5f;

    void Start()
    {

    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(moveX, moveY);

        if (move != Vector2.zero)
        {
            transform.up = move;
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        Vector2 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= boost;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= boost;
        }
    }
}