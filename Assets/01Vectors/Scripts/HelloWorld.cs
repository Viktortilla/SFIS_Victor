using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class HelloWorld : MonoBehaviour
{
    [SerializeField]
    private MyVector2D v1 = new MyVector2D(5,5);
    [SerializeField]
    private MyVector2D v2 = new MyVector2D(5,-5);
    private MyVector2D v3 = new MyVector2D(0,0);
    private MyVector2D v4 = new MyVector2D(0,0);
    [Range(0, 1), SerializeField] private float scalar = 0;

    private float mitad;
    void Start()
    {
        MyVector2D a = new MyVector2D(2, 3);
        MyVector2D b = new MyVector2D(4, 5);
        MyVector2D d = a+b;
        Debug.Log(d);
        MyVector2D e = a -b;
        Debug.Log(e);
        MyVector2D f = a *2f;
        Debug.Log(f);


    }

    // Update is called once per frame
    void Update()
    {
        //vector triangulo
        v1.Draw(Color.green);
        v2.Draw(Color.red);
        
        //Debug.DrawLine(new Vector3(v1.x,v1.y,0),
            //(new Vector3(v1.x+(v2.x-v1.x)*scalar,v1.y+(v2.y-v1.y)*scalar,0)),
           // Color.yellow);
        v3 = new MyVector2D(v2.x+(v1.x-v2.x)*scalar,v2.y+(v1.y-v2.y)*scalar);
        v3.Draw(Color.yellow,v2);
        Debug.DrawLine(Vector3.zero, new Vector3(-v2.x+v3.x,v1.y-v3.y,0),Color.yellow);
        Debug.DrawLine(Vector3.zero,new Vector3(v3.x,v3.y,0),Color.blue);
        /*
        //vector triangula rectangulo
        v1.Draw(Color.green);
        v2.Draw(Color.red);
        
        Debug.DrawLine(new Vector3(v1.x,v1.y,0),new Vector3((float)((v1.x+v2.x)*0.5),(float)((v1.y+v2.y)*0.5),0),Color.yellow);
        Debug.DrawLine(Vector3.zero,new Vector3((float)((v1.x+v2.x)*0.5),(float)((v1.y+v2.y)*0.5),0),Color.blue);
        */
        /*
        //v1.Draw(Color.yellow);
        //Debug.DrawLine(Vector3.zero,new Vector3(v1.x,v1.y,0),Color.blue);
        Debug.DrawLine(Vector3.zero,new Vector3(v1.x,v1.y,0),Color.red);
        Debug.DrawLine(new Vector3(v1.x,v1.y,0),new Vector3(v2.x+v1.x,v1.y+v2.y,0),Color.green);
        //Debug.DrawLine(new Vector3(v1.x,v1.y,0),new Vector3(v2.x,v2.y,0),Color.yellow);
        MyVector2D result = v1 + v2;//trata de entender la resta
        result.Draw(Color.yellow);
        */
    }

    
    
}
