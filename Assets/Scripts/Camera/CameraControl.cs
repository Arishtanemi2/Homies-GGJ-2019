using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Camera cam;
    public int panspeed;
    public int speed;
    public Vector2 camRange;
    
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main;
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKey(KeyCode.E))
            if(camRange.x<=cam.orthographicSize)
                cam.orthographicSize-=panspeed*Time.deltaTime;
        if(Input.GetKey(KeyCode.Q))
            if(camRange.y>=cam.orthographicSize)
                cam.orthographicSize+=panspeed*Time.deltaTime;
        if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward*speed*Time.deltaTime,Space.World);
			//rb.AddForce(Vector3.forward*speed*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(-Vector3.forward*speed*Time.deltaTime,Space.World);
		}
		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right*speed*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(-Vector3.right*speed*Time.deltaTime);
		}  
    }
}
