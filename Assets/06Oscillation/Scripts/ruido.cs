using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruido : MonoBehaviour
{
    [SerializeField] private float amplitude;
    [SerializeField] private float period;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        
    }

    private void Update()
    {
        float x = Mathf.Sin(5 * Time.time) + Mathf.Cos(Time.time / 3f) + Mathf.Sin(Time.time/13);
        transform.position = initialPosition + new Vector3(x, 0, 0);
        

    }
}
