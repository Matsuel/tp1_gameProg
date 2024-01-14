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

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(moveX, moveY);

        transform.Translate(move * Time.deltaTime* speed);


        postition.x = Mathf.Clamp(postition.x, minX, maxX);
        postition.y = Mathf.Clamp(postition.y, minY, maxY);
        Vector2 postition = transform.position;

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
