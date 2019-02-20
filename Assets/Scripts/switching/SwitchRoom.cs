using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRoom : MonoBehaviour
{
   
    UnityEngine.AI.NavMeshAgent nav;
    void Start()
    {
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeTarget(Vector3 pos)
    {
        nav.SetDestination (pos);
    }
}
