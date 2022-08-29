using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolita : MonoBehaviour
{
    private MyVector2D position;
    [SerializeField] private MyVector2D displacement;
    [SerializeField] private MyVector2D velocity;
    [Header("World")]
    [SerializeField] Camera camera;

    void Start()
    {

        position = new MyVector2D(transform.position.x, transform.position.y);
        
    }

    void Update()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
        velocity.Draw(position,Color.red);
        position.Draw(Color.blue);
        Move();
    }
    public void Move()
    {
        displacement = velocity * Time.deltaTime;
        position = position + velocity * Time.deltaTime;

        if(Mathf.Abs(position.x)> camera.orthographicSize)
        {
            velocity.x = velocity.x * (-1);
            position.x = Mathf.Sign(position.x) * camera.orthographicSize;
        }
        if (Mathf.Abs(position.y) > camera.orthographicSize)
        {
            velocity.y = velocity.y * (-1);
            position.y = Mathf.Sign(position.y) * camera.orthographicSize;
        }

        transform.position = new Vector3(position.x,position.y);
    }
}
