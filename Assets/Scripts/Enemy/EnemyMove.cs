using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyType;
    private int i;
    private float min;
    private Vector3 pos;
    public string[] strengths;
    public string weakness;
    public float speed;
    public GameObject target;
    public GameObject[] targetList;
    public GameManager gameManager;
    public int[] roomid;
    UnityEngine.AI.NavMeshAgent nav;
    GridInfo gridInfo;
    void Awake()
    {
        targetList=gameManager.giveTargetList();
        CalculateTarget();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        roomid=new int[2];
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination (target.transform.position);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag=="Door")
            other.transform.GetComponent<Animator>().SetBool("isOpened",true);
        if(other.transform.tag=="Floor")
        {
            roomid=other.transform.parent.GetComponent<GridInfo>().roomID;
            targetList=gameManager.giveTargetList();
            CalculateTarget();
        }
        if(other.transform.tag=="Room")
        {
            gridInfo= other.transform.GetComponent<GridInfo>();
            for(i=0;i<2;i++)
            {
                if(weakness==gridInfo.strengths[i])
                {
                    Destroy(transform.gameObject);
                    return;
                }
            }
            gridInfo.killall();
        }
    }
    void CalculateTarget()
    {
        pos=transform.position;
        i=0;
        min=10000f;
        while(targetList[i]!=null)
        {     
            if(targetList[i]==target)
                continue;
            if((pos-targetList[i].transform.position).magnitude<min)
            {
                target=targetList[i];
                min=(pos-targetList[i].transform.position).magnitude;
            }
            i++;
        }
    }
    /* private void OnCollisionEnter(Collision other) {
        if(other.transform.tag==weakness)
            Destroy(transform.gameObject);
        else
        {
            for(int i=0;i<strengths.Length;i++)
            {
                if(other.transform.tag==strengths[i])
                    Destroy(other.transform.gameObject);
            }
        }
       
    }*/
}
