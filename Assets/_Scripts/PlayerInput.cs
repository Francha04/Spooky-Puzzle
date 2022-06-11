using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class PlayerInput : MonoBehaviour
{
    public float xAxis;
    public float yAxis;
    [SerializeField] private UnityEvent EClick;
    
    public void checkForInput()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.E))
        {
            EClick.Invoke();
        }
    }
}
