using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleMove : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	private Transform oldtarget;
	public float speed;
	public Vector2 distanceoff;
	public Vector2 speechtimeoff;
	public Vector2 postertimeoff;
	public Vector2 speedRange;
	WaitForSeconds posterwait;
	WaitForSeconds speechwait;
	void Start()
	{
		offset.x=Random.Range(distanceoff.x,distanceoff.y);
		offset.z=Random.Range(distanceoff.x,distanceoff.y);
		speed = Random.Range (speedRange.x, speedRange.y);
		posterwait=new WaitForSeconds(Random.Range(postertimeoff.x,postertimeoff.y));
		speechwait=new WaitForSeconds(Random.Range(speechtimeoff.x,speechtimeoff.y));
	}
	void Update () 
	{
		transform.position=Vector3.MoveTowards (transform.position, target.transform.position+offset,speed);
		transform.LookAt(target);
	}
	void OnTriggerEnter(Collider col)
	{
		if(Random.value>0.3)
        {
            if (col.transform.tag == "Poster")
            {
                oldtarget = target;
                target = col.transform;
				StartCoroutine("ExaminePoster");
            }
		}
		if(Random.value>0.2)
		{
			if (col.transform.tag == "Speech")
            {
                oldtarget = target;
                target = col.transform;
				StartCoroutine("SpeechListen");
            }
		}

	}
	IEnumerator ExaminePoster()
	{
		yield return posterwait;
		target=oldtarget;
	}
	IEnumerator SpeechListen()
	{
		yield return speechwait;
		target=oldtarget;
	}




}
