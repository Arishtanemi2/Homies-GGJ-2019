using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInfo : MonoBehaviour
{
    
    public int[] roomID;
    public Transform[] doors;
    public GameObject[] members;
    public UnityEngine.UI.Image[] memimages;
    public Transform highlightedPlane;
    public Transform target;
    private GameManager gameManager;
    public string[] strengths;
    private int i;
    void Awake()
    {
        gameManager=GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameManager.AddTarget(target.gameObject);
    }
    public void Initialize()
    {
        strengths=new string[2];

    }
    public void killall()
    {
        for(i=0;i<2;i++)
        {
            Destroy(members[i]);
            members[i]=null;
            memimages[i]=null;
            strengths[i]=null;
        }
        gameManager.removeTarget(target.gameObject);
    }
   
}
