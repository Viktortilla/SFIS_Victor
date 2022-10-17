using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    private const int INDEX_OF_SQUARE_CHILD = 0;
    private const int INDEX_OF_CIRCLE_CHILD = 1;
    
    [SerializeField] private GameObject branchPrefab;
    [SerializeField] private int totalLevels = 3;
    [SerializeField] private float initialSize = 5f;
    [SerializeField,Range(0f,1f)] private float reductionPerLevel = 0.1f;
    private int currentLevel = 1;

    private Queue<GameObject> branchesQueue = new Queue<GameObject>();

    void Start()
    {
        
        GameObject rootBranch = Instantiate(branchPrefab, transform);
        ChangeBranchSize(rootBranch,initialSize);
        branchesQueue.Enqueue(rootBranch);
        GenerateTree();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateTree()
    {
        if (currentLevel >= totalLevels)
        {
            return;
        }
        Debug.Log(currentLevel);
        ++currentLevel;

        float newSize = Mathf.Max(initialSize - initialSize * reductionPerLevel*(currentLevel-1),0.1f);

        List<GameObject> branchesCreatedThisCycle = new List<GameObject>();
        while (branchesQueue.Count>0)
        {
            var rootBranch = branchesQueue.Dequeue();
            
            var legtBranch = CreateBranch(rootBranch,Random.Range(5f,25f));
            var rightBranch =   CreateBranch(rootBranch,-Random.Range(5f,25f));  
            
            ChangeBranchSize(legtBranch,newSize);
            ChangeBranchSize(rightBranch,newSize);
            
            branchesCreatedThisCycle.Add(legtBranch);
            branchesCreatedThisCycle.Add(rightBranch);
        }

        foreach (var newBranches in branchesCreatedThisCycle)
        {
            branchesQueue.Enqueue(newBranches);
        }
        GenerateTree();
        
    }

    private GameObject CreateBranch(GameObject branchPrevio,float relativeAngle)
    {
        GameObject newBranch = Instantiate(branchPrefab, transform);
        newBranch.transform.localPosition = branchPrevio.transform.localPosition + branchPrevio.transform.up * GetBranchLenght(branchPrevio);
        newBranch.transform.localRotation = branchPrevio.transform.localRotation * Quaternion.Euler(0,0,relativeAngle);
        return newBranch;
    }

    private void ChangeBranchSize(GameObject branchInstance, float newSize)
    {
        var square = branchInstance.transform.GetChild(INDEX_OF_SQUARE_CHILD);
        var circle = branchInstance.transform.GetChild(INDEX_OF_CIRCLE_CHILD);
        
        
        var newScale = square.transform.localScale;
        newScale.y = newSize;
        square.transform.localScale = newScale;
        
        var newPosition = square.transform.localPosition;
        newPosition.y = newSize/2;
        square.transform.localPosition = newPosition;
        
        var newCirclePosition = circle.transform.localPosition;
        newCirclePosition.y = newSize;
        circle.transform.localPosition = newCirclePosition;

    }

    private float GetBranchLenght(GameObject branchInstance)
    {
        return branchInstance.transform.GetChild(INDEX_OF_SQUARE_CHILD).localScale.y;
    }
    
}
