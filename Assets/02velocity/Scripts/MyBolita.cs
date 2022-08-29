using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolita : MonoBehaviour
{
    private MyVector2D position;
    [SerializeField]
    private MyVector2D displacement;
    [SerializeField] Camera camera;

    void Start()
    {

        position = new MyVector2D(transform.position.x, transform.position.y);
        
    }

    void Update()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
        displacement.Draw(position,Color.red);
        position.Draw(Color.blue);
    }
    public void Move()
    {
        position = position + displacement;

        if(Mathf.Abs(position.x)> camera.orthographicSize)
        {
            displacement.x = displacement.x * (-1);
            position.x = Mathf.Sign(position.x) * camera.orthographicSize;
        }
        if (Mathf.Abs(position.y) > camera.orthographicSize)
        {
            displacement.y = displacement.y * (-1);
            position.y = Mathf.Sign(position.y) * camera.orthographicSize ;
        }

        transform.position = new Vector3(position.x,position.y);
    }
}
