using System;
using UnityEngine;


[Serializable]
public struct MyVector2D
{
    public float x;
    public float y;

    public float magnitude
    {
        get { return Mathf.Sqrt(x * x + y * y); }
    }
    //es lo mismo que escrivir float magnitude => Mathf.S...
    public MyVector2D normalized
    {
        get
        {
            if (magnitude <= 0.0001f)
            {
                return new MyVector2D(0, 0);
            }
            return new MyVector2D(x/magnitude,y/magnitude);
        }
    }
    

    public MyVector2D(float x, float y)//constructor= estado inicial del objeto al inicializarlo 
    {
        this.x = x;
        this.y = y;
    }
    public MyVector2D sum(MyVector2D par)
    {
        MyVector2D temp=new MyVector2D(x+par.x,y+par.y);


        return temp;
    }

    public MyVector2D Sub(MyVector2D a)
    {
        return new MyVector2D(
            x - a.x,
            y - a.y
        );
    }

    public MyVector2D Scale(float a)
    {
        return new MyVector2D(
            x * a,
            y * a
        ); ;
    }

    public static MyVector2D operator +(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(
            a.x + b.x,
            a.y + b.y
        );
    }
    public static MyVector2D operator -(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(
            a.x - b.x,
            a.y - b.y
        );
    }

    public static MyVector2D operator *(MyVector2D a, float b)
    {
        return new MyVector2D(
            a.x * b,
            a.y * b
        );
    }
    
    public static MyVector2D operator *( float b,MyVector2D a)
    {
        return new MyVector2D(
            a.x * b,
            a.y * b
        );
    }
    public static MyVector2D operator /( float b,MyVector2D a)
    {
        return new MyVector2D(
            a.x / b,
            a.y / b
        );
    }
    public static MyVector2D operator /( MyVector2D a,float b)
    {
        return new MyVector2D(
            a.x / b,
            a.y / b
        );
    }
    private Vector3 PolarToCartesian(float radius,float angle)
    {
        
        float x = radius*Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = radius*Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector3(x, y, 0);
    }
    
    public void Draw(Color color)
    {
        Debug.DrawLine(
            Vector3.zero,
            new Vector3(x, y, 0),
            color
        );
    }
    public void Draw(Color color,MyVector2D origen)
    {
        Vector3 origen3d =new Vector3(origen.x,origen.y,0);
        Debug.DrawLine(
            origen3d,
            new Vector3(x, y, 0),
            color
        );
    }
    public void Draw(MyVector2D origen, Color color)
    {
        Vector3 origen3d = new Vector3(origen.x, origen.y, 0);
        Debug.DrawLine(
            origen3d,
            new Vector3(x + origen.x, y + origen.y, 0),
            color
        );
    }

    public override string ToString()
    {
        return $"[{x}, {y}]";
    }

    public void Normalize()
    {
        float tolerance = 0.0001f;//para evitar diviciones de numeros muy pequenos
        if (magnitude <= tolerance)
        {
            x = 0;
            y = 0;
           return; 
        }
        
        x /= magnitude;
        y /= magnitude;
    }
}
