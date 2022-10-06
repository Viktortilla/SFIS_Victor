using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrices : MonoBehaviour
{
    [SerializeField] private Vector4 location;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Matrix4x4 matrix = new Matrix4x4(new Vector4(1,0,0,0),new Vector4(0,1,0,0),new Vector4(0,0,1,0),location);
        
        transform.localPosition = matrix * new  Vector4(0,0,0,1);
    }
}
