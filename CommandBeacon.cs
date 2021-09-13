using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandBeacon : MonoBehaviour
{
    static string ROBOTTAG = "Player Robot";

    const int FORWARDSKEY = 1;
    const int BACKWARDSKEY = 2;
    const int LEFTKEY = 3;
    const int RIGHTKEY = 4;
    const int HALTKEY = 5;

    [Header("UI References")]
    [SerializeField] private Slider speedSlider;
    [SerializeField] private Slider delaySlider;

    [SerializeField]public Robot.Commands commandToSend;

    public List<Robot> robotList;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag(ROBOTTAG)) 
        {
            robotList.Add(g.GetComponent<Robot>());
        }

    }

    public void SendNewSpeed() 
    {
        foreach (Robot r in robotList)
        {
            r.StartCoroutine(r.RecieveSpeed(speedSlider.value));
        }
    }

    public void SendNewDelay()
    {
        foreach (Robot r in robotList)
        {
            r.StartCoroutine(r.RecieveDelaySpeed(delaySlider.value));
        }
    }

    #region send Commands
    public void SendUserInput(int commandNum) 
    {
        
        switch (commandNum) 
        {
            case FORWARDSKEY:
                commandToSend = Robot.Commands.Forward;
                break;

            case BACKWARDSKEY:
                commandToSend = Robot.Commands.Backward;
                break;

            case LEFTKEY:
                commandToSend = Robot.Commands.Left;
                break;

            case RIGHTKEY:
                commandToSend = Robot.Commands.Right;
                break;

            case HALTKEY:
                commandToSend = Robot.Commands.Halt;
                break;

        }
        foreach (Robot r in robotList)
        {
            r.StartCoroutine( r.RecieveCommand(commandToSend) );
        }

    }
    #endregion
}
