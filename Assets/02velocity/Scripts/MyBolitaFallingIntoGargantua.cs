using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolitaFallingIntoGargantua : MonoBehaviour
{
    private MyVector2D position;
    private MyVector2D gargantuaPosition;
    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private MyVector2D velocity;
    [Header("World")]
    [SerializeField] private new Camera camera;
    [SerializeField] private Transform gargantua;
    

    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);

    }
    void FixedUpdate()
    {
        Move();
        position = new MyVector2D(transform.position.x, transform.position.y);
        gargantuaPosition = new MyVector2D(gargantua.position.x, gargantua.position.y);
        acceleration = gargantuaPosition - position;
    }
    void Update()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
 
        velocity.Draw(position,Color.red);
        position.Draw(Color.blue);
        acceleration.Draw(position,Color.green);


    }
    public void Move()
    {   
        position = position + velocity * Time.fixedDeltaTime;
        transform.position = new Vector3(position.x,position.y);
    }
}
