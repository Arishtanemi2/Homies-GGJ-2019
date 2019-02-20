using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRoom : MonoBehaviour
{
    string strength;
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f; 
    RaycastHit hit;
    GridInfo gridInfo;
    GameObject previous;
    public GameObject roomUI;
    public UnityEngine.UI.Image img;
    private int i;
    void Start() {
         floorMask = LayerMask.GetMask ("Room");
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
            if(Physics.Raycast (camRay, out hit, camRayLength, floorMask))
            {
                if(previous==null){
                    if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                    {
                        gridInfo=hit.transform.parent.GetComponent<GridInfo>();
                        roomUI.transform.position=new Vector3(hit.point.x, roomUI.transform.position.y,hit.point.z);
                        if(gridInfo.members[0]!=null)
                        {
                            roomUI.GetComponent<RoomUIInfo>().memberImages[0].sprite=gridInfo.memimages[0].sprite;
                            roomUI.GetComponent<RoomUIInfo>().memberButton[0].SetActive(true);
                            if(gridInfo.members[1]!=null)
                            {
                                roomUI.GetComponent<RoomUIInfo>().memberImages[1].sprite=gridInfo.memimages[1].sprite;
                                roomUI.GetComponent<RoomUIInfo>().memberButton[1].SetActive(true);
                            }
                        }
                        roomUI.SetActive(true);
                        gridInfo.highlightedPlane.gameObject.SetActive(true);
                    }
                }
                else
                {
                    gridInfo.highlightedPlane.gameObject.SetActive(false);
                    gridInfo=hit.transform.parent.GetComponent<GridInfo>();
                    for(i=0;i<gridInfo.members.Length;i++)
                    {
                        if(gridInfo.members[i]==null)
                        {
                            gridInfo.members[i]=previous;
                            gridInfo.memimages[i]=img;
                            previous=null;
                            gridInfo.members[i].GetComponent<SwitchRoom>().changeTarget(gridInfo.target.position);
                            gridInfo.strengths[i]=strength;
                            break;
                        }
                    }
                }
            }
            else
            {
                if(gridInfo!=null)
                    gridInfo.highlightedPlane.gameObject.SetActive(false);
                roomUI.SetActive(false);
            }
        }
    }
    public void MemberSelected(int no)
    {
        if(gridInfo.members[no]!=null)
        {
            previous=gridInfo.members[no];
            img= roomUI.GetComponent<RoomUIInfo>().memberImages[no];
            strength=gridInfo.strengths[no];
            gridInfo.members[no]=null;
            gridInfo.strengths[no]=null;
        }
    }
}
