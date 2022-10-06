using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private GameObject m_prefab;
    [SerializeField] private int m_totalPoints=10;
    [SerializeField] private float m_distanceFactor = 1;
    private GameObject[] m_allPoints;
    
    [SerializeField] private float amplitud = 1;

    //[SerializeField] private LineRenderer m_lineRender;
    
    // Start is called before the first frame update
    void Start()
    {
        m_allPoints = new GameObject[m_totalPoints];
        
        for (int i = 0; i < m_totalPoints; ++i)
        {
            m_allPoints[i] = Instantiate(m_prefab, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_allPoints.Length; ++i)
        {
            
            
            float x = i  *m_distanceFactor;
            float y = amplitud* Mathf.Sin(x+Time.time);
            m_allPoints[i].transform.localPosition = new Vector3(x,y,0);
            

        }
    }
}
