using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] targetList;
    private int i;
    private bool stackdown;
    private float min;
    private GameObject target;
    public int targetcount=4;
    public int[,] grid;
	public GameObject gridGO;
    public GridManager gridManager;
    void Start()
    {
        this.grid=gridManager.grid;
    }

    public GameObject[] giveTargetList()
    {
        return targetList;
    }
    /*depreciated use targetlist
    public GameObject giveInnerTarget(int enemyType,Vector3 pos,GameObject tar)
    {
        Debug.Log("called");
        min=10000f;
        for(i=0;i<targetcount;i++)
        {
            if(targetList[i]==tar)
                continue;
            if((pos-targetList[i].transform.position).magnitude<min)
            {
                target=targetList[i];
                min=(pos-targetList[i].transform.position).magnitude;
            }
        }
        Debug.Log("returned "+target);
        return target;
    }*/
    public void AddTarget(GameObject tar)
    {
        targetList[targetcount++]=tar;
	}

	public void Pause(){
		Time.timeScale=0;
	}

	public void Resume(){
		Time.timeScale=1;
	}

	public void Quit(){
		//If we are running in a standalone build of the game
		#if UNITY_STANDALONE
		//Quit the application
		Application.Quit();
		#endif

		//If we are running in the editor
		#if UNITY_EDITOR
		//Stop playing the scene
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

	public void AddRoom(){
		if(gridGO.activeSelf)
			gridGO.SetActive(false);
		else
				gridGO.SetActive(true);
	}
    public void removeTarget(GameObject rem)
    {
        for(i=0;i<targetcount;i++)
        {
            if(stackdown==true)
            {
                if(i==targetcount-1)
                    break;
                targetList[i]=targetList[i+1];
            }
            else if(rem==targetList[i])
            {
                targetList[i]=null;
                stackdown=true;
            }
        }
        stackdown=false;
        targetcount--;
    }

    /* public GameObject giveInnerTarget(int enemyType,int[] roomID)
    {
        this.grid=gridManager.grid;
        if(grid[roomID[0]+1,roomID[1]]==1)
        {
            return getFloor(roomID[0]+1,roomID[1]);
        }
        else if(grid[roomID[0]-1,roomID[1]]==1)
        {
            return getFloor(roomID[0]+1,roomID[1]);
        }
        else if(grid[roomID[0],roomID[1]+1]==1)
        {
            return getFloor(roomID[0]+1,roomID[1]);
        }
        else if(grid[roomID[0],roomID[1]-1]==1)
        {
            return getFloor(roomID[0]+1,roomID[1]);
        }
        return target;
    }
    private GameObject getFloor(int x, int y)
    {
        return floorList[x,y];
    }*/
   
}
