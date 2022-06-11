using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    // Singleton code
    public static PlayerScript Instance { get; private set; }

    int state; // 0 means in ghost form, 1 means in body.
    [SerializeField] GameObject controlledObject; // The object currently being handled by the player. In 0 will be ghost, in 1 will be a body.
    [SerializeField] GameObject ghostPrefab;
    [SerializeField] PlayerInput pInput;
    [SerializeField] PlayerMovement pMovement;
    [SerializeField] CameraFollow mainCamera;
    [SerializeField] PosessionSelector posessionSelector;
    //Unity Events that this script will fire off.


    private void Awake()
    {
        // Singleton code: if there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        state = 0;
        changeBody(spawnGhost(new Vector3(0f, 0f, 0f)));
        
        mainCamera.setFollowTarget(controlledObject.transform);
        posessionSelector = controlledObject.GetComponentInChildren<PosessionSelector>();
    }
    //These two methods will manage the movement of the body/ghost.
    private void Update()
    {
        pInput.checkForInput();
    }
    private void FixedUpdate()
    {
        pMovement.move(pInput.xAxis, pInput.yAxis);
    }
    //_______________
    //This method spawns a ghost and adjusts the game state so the player is controlling the ghost.
    public GameObject spawnGhost(Vector3 ghostPosition)
    {
        return Instantiate(ghostPrefab, ghostPosition, Quaternion.identity);        
        /*pMovement.setRigidBody(controlledObject.GetComponent<Rigidbody>());
        */
    }
    //____________
    //This method deals with the posession
    public void listenToEClick() 
    {
        print("E pressed");
        if (state == 1)
        {
            unpossess();
        }
        else if (state == 0) 
        {
            possess();
        }
            
    }
    private void possess()
    {        
        if (posessionSelector.getSelectedPosession() == null) { print("Trying to change to a body when no one is posessable"); return; }
        state = 1;
        GameObject ghostForm = controlledObject;
        changeBody(posessionSelector.getSelectedPosession());
        Destroy(ghostForm);
    }
    private void unpossess() 
    {
        changeBody( spawnGhost(new Vector3(controlledObject.transform.position.x, controlledObject.transform.position.y + 1, controlledObject.transform.position.z)));
        state = 0;
        posessionSelector = controlledObject.GetComponentInChildren<PosessionSelector>();
    }
    
    private void changeBody(GameObject newBody)
    {
        controlledObject = newBody;
        pMovement.setRigidBody(newBody.GetComponent<Rigidbody>());
        mainCamera.setFollowTarget(newBody.transform);
    }
    //_______________
    //Public getter
    public GameObject getBody()
    {
        return controlledObject;
    }

}
