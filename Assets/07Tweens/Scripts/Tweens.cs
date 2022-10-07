using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    [Header("Tween related")]
    [SerializeField, Range(0, 1)] 
    private float normalizedTime;
    [SerializeField] 
    private float duration = 1;
    [SerializeField]
    private Color initialColor;
    [SerializeField]
    private Color finalColor;
    [SerializeField] 
    private AnimationCurve curve;
    
    private float currenTime = 5 ;
    [Header("Parameters")]
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartTween();
    }

    
    void Update()
    {
        normalizedTime = currenTime/duration ;
        transform.position =Vector3.Lerp(initialPosition,finalPosition,curve.Evaluate(normalizedTime));
        spriteRenderer.color=Color.Lerp(initialColor,finalColor,curve.Evaluate(normalizedTime));
        
        currenTime += Time.deltaTime;

        if (normalizedTime>=1)
        {
            Debug.Log("Complete");
        }
        if(Input.GetKeyDown(KeyCode.Space))StartTween();
        
    }

    private void StartTween()
    {
        currenTime = 0f;
        initialPosition = transform.position;
        finalPosition = targetTransform.position;


    }

    private float EaseInQuad(float x)
    {
        return x * x* x;
    }
}
