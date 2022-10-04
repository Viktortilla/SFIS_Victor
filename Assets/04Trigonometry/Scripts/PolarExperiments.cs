using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Timeline;

public class PolarExperiments : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float angleDeg;
    [SerializeField] private Transform bolita;
    [SerializeField]new Camera camera;

    [SerializeField] private float angularSpeed;
    [SerializeField] private float angularAcceleration;
    [SerializeField] private float radialSpeed;
    [SerializeField] private float radialAcceleration;
    
    private void Start()
    {
        Assert.IsNotNull(bolita,"No hay bolita");
    }

    // Update is called once per frame
    private void Update()
    {
        
        //angularSpeed = angularSpeed + angularAcceleration * Time.fixedDeltaTime;
        //radialSpeed = radialSpeed + radialAcceleration * Time.fixedDeltaTime;
        
        

        if(Mathf.Abs(bolita.position.x)> camera.orthographicSize)
        {

            radialSpeed = radialSpeed * -1;
            

        }
        if (Mathf.Abs(bolita.position.y) > camera.orthographicSize)
        {
            
            radialSpeed = radialSpeed * -1;
            
        }
        angleDeg += angularSpeed*Time.fixedDeltaTime;
        radius += radialSpeed*Time.fixedDeltaTime;

        bolita.position = PolarToCartesian(radius, angleDeg);
        
        Debug.DrawLine(Vector3.zero, bolita.position,Color.red);
    }

    private Vector3 PolarToCartesian(float radius,float angle)
    {
        
        float x = radius*Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = radius*Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector3(x, y, 0);
    }
}
