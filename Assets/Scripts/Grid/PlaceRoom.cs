using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceRoom : MonoBehaviour
{
    public Transform room;
    public int[,] grid;
    public GridManager gridManager;
    public Vector2 gridspace;
    private bool placed=false;
    private Transform spawned;
    private GridInfo gridInfo;
    private int x,y;
    private void OnMouseDown() {
        if(placed==false)
                if((gridManager.placecheck((int)gridspace.x,(int)gridspace.y))==1)
                {
                    grid=gridManager.grid;
                    spawned=Instantiate(room,transform.position,transform.rotation);
                    gridInfo=spawned.GetComponent<GridInfo>();
                    x=(int)gridspace.x;
                    y=(int)gridspace.y;
                    gridInfo.roomID[0]=x;
                    gridInfo.roomID[1]=y;
                    spawned.name="room"+x+y;
                    gridInfo.Initialize();
                    transform.parent.gameObject.SetActive(false);
                    x+=1;
                    y+=1;
                    if(grid[x+1,y]==1)
                    {
                        gridInfo.doors[0].gameObject.SetActive(false);
                    }
                    if(grid[x-1,y]==1)
                    {
                        gridInfo.doors[1].gameObject.SetActive(false);
                    }
                    if(grid[x,y+1]==1)
                    {
                        gridInfo.doors[2].gameObject.SetActive(false);
                    }
                    if(grid[x,y-1]==1)
                    {
                        gridInfo.doors[3].gameObject.SetActive(false);
                    }
                    placed=true;
                }
                
    }
}
