using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed=5;
    public float maxX=10.2f;
    public float minX=-10.2f;
    public float maxY=4.5f;
    public float minY=-4.5f;
    // Start is called before the first frame update
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
        
        Vector2 postition = transform.position;

        postition.x = Mathf.Clamp(postition.x, minX, maxX);
        postition.y = Mathf.Clamp(postition.y, minY, maxY);

        transform.position = postition;
    }
}
