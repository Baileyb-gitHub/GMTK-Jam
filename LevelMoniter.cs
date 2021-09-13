using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMoniter : MonoBehaviour
{
    const string SWITCHTAG = "Switch";
    [SerializeField] List<FloorSwitchLogic> switchList;
    [SerializeField] GameObject victoryUI;

    private void Start()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag(SWITCHTAG))
        {
            switchList.Add(g.GetComponent<FloorSwitchLogic>());
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckForVictory() 
    {
   
        foreach (FloorSwitchLogic s in switchList)
        {
            if(s.switchPressed == false) 
            {
                return;
            }
        }

        Victory();
    }

    public void Victory() 
    {
        Time.timeScale = 0;
        victoryUI.SetActive(true);
    }
}
