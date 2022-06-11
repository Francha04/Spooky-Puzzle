using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform toFollow;
    [SerializeField] Vector3 distanceFromTarget;
    private void Start()
    {        
    }
    public void setFollowTarget(Transform newTarget) 
    {
        toFollow = newTarget;
    }
    private void Update()
    {
        this.transform.position = toFollow.transform.position + distanceFromTarget;
    }
}
