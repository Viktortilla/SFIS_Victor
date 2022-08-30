using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolita : MonoBehaviour
{
    private MyVector2D position;
    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private MyVector2D velocity;
    [Range(0f,1f)][SerializeField] private float dampingFactor=0.9f;
    [Header("World")]
    [SerializeField]new Camera camera;
    private byte cont = 0;
    private float x;
    private float y;

    void Start()
    {

        position = new MyVector2D(transform.position.x, transform.position.y);
        
    }
    void FixedUpdate()
    {
        Move();
    }
    void Update()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = new MyVector2D(transform.position.x, transform.position.y);
        velocity.Draw(position,Color.red);
        position.Draw(Color.blue);
        acceleration.Draw(Color.green);
        

        if (Input.GetKeyDown(KeyCode.Space))//si se presiona espacio
        {
            cont++;
            if (cont == 1)
            {
                x = -acceleration.y;
                y = -acceleration.x;
                acceleration = new MyVector2D(x, y);
                velocity = new MyVector2D(0,0);
            }
            if (cont == 2)
            {
                x = acceleration.y;
                y = acceleration.x;
                acceleration = new MyVector2D(x, y);
                cont = 0;
                velocity = new MyVector2D(0, 0);

            }
        }


    }
    public void Move()
    {
        
        position = position + velocity * Time.fixedDeltaTime;

        if(Mathf.Abs(position.x)> camera.orthographicSize)
        {
            velocity.x = velocity.x * (-1);
            position.x = Mathf.Sign(position.x) * camera.orthographicSize;
            velocity *= dampingFactor;

        }
        if (Mathf.Abs(position.y) > camera.orthographicSize)
        {
            velocity.y = velocity.y * (-1);
            position.y = Mathf.Sign(position.y) * camera.orthographicSize;
            velocity *= dampingFactor;
        }

        transform.position = new Vector3(position.x,position.y);
    }
}
