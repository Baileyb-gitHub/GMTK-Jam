using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{

    public enum Commands { Forward, Backward, Left, Right, Halt };

    [Header ("Power")]
    public bool powered;
    public float storedPower;
    [Header("Connection")]
    public bool connected = true;
    public bool delayed = false;
    public float signalDelay;
    [Space]
    public string myName;
    public float moveSpeed;
    public Vector3 myVelocity;

    private Rigidbody myRB;

    public  Commands myCurrentCommand;
    [Header("Debug")]
    [SerializeField] private bool actor = false;
    // Start is called before the first frame update
    void Start()
    {
        myRB = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(RecieveCommand(myCurrentCommand));
    }

    // Update is called once per frame
    void Update()
    {    
        myRB.velocity =   new Vector3(myVelocity.x, -1f , myVelocity.z);
     
    }

  

    public IEnumerator RecieveCommand(Commands newCommand) 
    {
        if(connected == false) 
        {
            yield break;
        }

        if(delayed == true) 
        {
            yield return new WaitForSeconds(signalDelay);
        }
       
        switch (newCommand)
        {
            case Commands.Forward:
                myVelocity = new Vector3(0, 0, -moveSpeed);
                break;

            case Commands.Backward:
                myVelocity = new Vector3(0, 0, moveSpeed);
                break;

            case Commands.Left:
                myVelocity = new Vector3(moveSpeed, 0, 0);
                break;

            case Commands.Right:
                myVelocity = new Vector3(-moveSpeed, 0, 0);
                break;

            case Commands.Halt:
                myVelocity = new Vector3(0, 0, 0);
                break;

        }
        this.transform.rotation = Quaternion.LookRotation(myVelocity, Vector3.up);
        myCurrentCommand = newCommand;
    }

    public IEnumerator RecieveSpeed(float newSpeed)
    {
        if (connected == false)
        {
            yield break;
        }


        if (delayed == true)
        {
            yield return new WaitForSeconds(signalDelay);
        }

        moveSpeed = newSpeed;

        switch (myCurrentCommand)
        {
            case Commands.Forward:
                myVelocity = new Vector3(0, 0, -moveSpeed);
                break;

            case Commands.Backward:
                myVelocity = new Vector3(0, 0, moveSpeed);
                break;

            case Commands.Left:
                myVelocity = new Vector3(moveSpeed, 0, 0);
                break;

            case Commands.Right:
                myVelocity = new Vector3(-moveSpeed, 0, 0);
                break;

            case Commands.Halt:
                myVelocity = new Vector3(0, 0, 0);
                break;

        }
    }

    public IEnumerator RecieveDelaySpeed(float newSpeed)
    {
        if (connected == false)
        {
            yield break;
        }


        if (delayed == true)
        {
            yield return new WaitForSeconds(signalDelay);
        }

        signalDelay = newSpeed;
    }


    public void updateJamStatus(bool newStatus) 
    {
        connected = !newStatus;
    }

    public void updateDelayStatus(bool newStatus)
    {
        delayed = newStatus;
    }
}
