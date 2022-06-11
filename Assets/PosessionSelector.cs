using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PosessionSelector : MonoBehaviour
{
    List<GameObject> listOfPossessions = new List<GameObject>();
    [SerializeField] GameObject toPossesSelected;
    private void Awake()
    {
        toPossesSelected = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Body")) { return; } //Escape.

        //listOfPossessions.Add(other.gameObject);
        toPossesSelected = other.gameObject; 
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Body")) { return; }
        if (toPossesSelected = other.gameObject) { toPossesSelected = null; }
    }
    public GameObject getSelectedPosession() 
    {
        return toPossesSelected;
    }
    
}
