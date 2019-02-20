using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridManager : MonoBehaviour
{
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f; 
    RaycastHit hit;
    GridInfo gridInfo;
    public int[,] grid;
    public GameObject[] characters;
    public UnityEngine.UI.Image[] charimages;
    private int n,i;
    private bool isPlacing;
    void Start()
    {
        grid=new int[8,8];
        int i,j;
        for(i=0;i<8;i++)
            for(j=0;j<8;j++)
                grid[i,j]=0;
        grid[3,3]=grid[3,4]=grid[4,3]=grid[4,4]=1;
        floorMask = LayerMask.GetMask ("Room");
         
    }
    public int placecheck(int x,int y)
    {
        x+=1;
        y+=1;
        if(grid[x+1,y]==1||grid[x-1,y]==1||grid[x,y+1]==1||grid[x,y-1]==1)
        {
            grid[x,y]=1;
            return 1;
        }
        else 
            return 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")&&isPlacing==true)
        {
            Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
            if(Physics.Raycast (camRay, out hit, camRayLength, floorMask))
            {
                gridInfo=hit.transform.parent.GetComponent<GridInfo>();
                for(i=0;i<2;i++)
                {
                    if(gridInfo.members[i]==null)
                    {
                        gridInfo.members[i]=characters[n];
                        gridInfo.memimages[i]=charimages[n];
                        Instantiate(characters[n],gridInfo.target.position,characters[n].transform.rotation);
                        isPlacing=false;
                    }
                }
            }
        }
    }
    public void AddMember(int n)
    {
        this.n=n;
        isPlacing=true;
    }
}
