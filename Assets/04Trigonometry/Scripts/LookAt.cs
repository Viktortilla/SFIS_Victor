using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour 
{
    // Update is called once per frame
    private float speed;
    void Update()
    {
        Vector3 mousePosition = GetWorldMousePosition();
        Vector3 diferencia = (mousePosition - transform.position);
        Vector3 lookAt = (mousePosition - transform.position).normalized*speed;
        float radians = Mathf.Atan2(diferencia.y, diferencia.x)- Mathf.PI / 2;
        
        RotateZ(radians);
        
        Vector3 posicionFinal = new Vector3(lookAt.x, lookAt.y, 0);
        Vector3 position = transform.position;
        position += posicionFinal * Time.deltaTime;
        transform.position = position;
    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;
    }

    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
    
}