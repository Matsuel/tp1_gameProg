using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 5;
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

        transform.Translate(move * Time.deltaTime * speed);

        Vector2 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;

        float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }
}
