using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class JammerTowerLogic : MonoBehaviour
{
    [SerializeField] private SphereCollider jamCollider;
    [SerializeField] private GameObject jamMaterialSphere;
    [Header("things i can jam")]
    [SerializeField] private List<string> jamTagList;

    // Start is called before the first frame update
    void Start()
    {
        jamCollider = GetComponent<SphereCollider>();
        jamMaterialSphere.transform.localScale = new Vector3(jamCollider.radius * 2, jamCollider.radius * 2, jamCollider.radius * 2);
    }


    private void OnTriggerEnter(Collider other)
    {
       if(jamTagList.Contains(other.tag)) 
       {
            other.GetComponent<Robot>().updateJamStatus(true);
       } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (jamTagList.Contains(other.tag))
        {
            other.GetComponent<Robot>().updateJamStatus(false);
        }
    }
}
