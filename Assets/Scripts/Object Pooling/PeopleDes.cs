using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleDes : MonoBehaviour {

	public LevelPool ppool;
	void OnTriggerEnter(Collider col)
	{
		if(col.transform.tag=="People")
		{
			ppool.AddPool (col.transform);
			col.gameObject.SetActive(false);
		}
	}
}
