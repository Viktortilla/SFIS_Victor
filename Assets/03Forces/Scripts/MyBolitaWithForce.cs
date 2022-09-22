using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolitaWithForce : MonoBehaviour
{
    public enum BolitaRunMode
    {
        Friction,
        FluidFriction,
        Gravity
    }

    public float Masa => masa;
    
    private MyVector2D position;
    [SerializeField] private BolitaRunMode runMode;
    [SerializeField] private MyVector2D velocity;
    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private float masa=1f;

    
    
    [Header("Forces")]
    [SerializeField] private MyVector2D gravedad;
    [SerializeField] private MyVector2D gravityAttraction;
    [SerializeField] private MyVector2D viento;
    
    
    
    
    private MyVector2D peso;
    private MyVector2D friccion;
    
    
    [Header("World")]
    [SerializeField]new Camera camera;
    [SerializeField] private MyBolitaWithForce otherBolita;
    [Range(0f,1f)][SerializeField] private float dampingFactor=0.9f;
    [Range(0f,1f)][SerializeField] private float coeficienteDeF=0.9f;
    
    void Start()
    {

        position = new MyVector2D(transform.position.x, transform.position.y);
        
    }
    void FixedUpdate()
    {
        acceleration = new MyVector2D(0,0);
        
        if (runMode==BolitaRunMode.FluidFriction)
        {
            peso = masa * gravedad;
            ApplyForce(peso);
            if (transform.localPosition.y <= 0)
            {
                ApplyFluidFriction();
            }
        }
        else if(runMode==BolitaRunMode.Friction)
        {
            peso = masa * gravedad;
            ApplyForce(peso);
            ApplyStandardFriction();
        }
        else if(runMode==BolitaRunMode.Gravity)
        {
            MyVector2D diferencia = otherBolita.position - position;
            float r = diferencia.magnitude;
            gravityAttraction = ((masa * otherBolita.masa) / (r * r))*diferencia.normalized;
            ApplyForce(gravityAttraction);
        }
        
        Move();
    }
    void Update()
    {
        position.Draw(Color.blue);
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = new MyVector2D(transform.position.x, transform.position.y);
        velocity.Draw(position,Color.red);
        acceleration.Draw(Color.green);
        

    }
    public void Move()
    {
        
        position = position + velocity * Time.fixedDeltaTime;

        if (runMode != BolitaRunMode.Gravity)
        {
            CHeckBoxBounds();
        }
        else
        {
            if (velocity.magnitude >= 7) velocity = 7f * velocity.normalized;
        }

        transform.position = new Vector3(position.x,position.y);
    }

    private void ApplyForce(MyVector2D force)
    {
        acceleration += force / masa;
    }

    private void ApplyStandardFriction()
    {
        float N = -masa * gravedad.y;
        friccion=-coeficienteDeF*N*velocity.normalized;
        ApplyForce(friccion);
        friccion.Draw(position,Color.magenta);
    }

    private void ApplyFluidFriction()
    {
        float frontalArea = transform.localScale.x;
        float rho = 1;
        float fluidDragCoefficient = 1f;
        float velocityMagnitude = velocity.magnitude;
        float scalarPart = -0.5f * rho *velocityMagnitude*velocityMagnitude*frontalArea*fluidDragCoefficient;
        MyVector2D friction = scalarPart *velocity.normalized;
        ApplyForce(friction);
    }

    private void CHeckBoxBounds()
    {
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
    }
}
