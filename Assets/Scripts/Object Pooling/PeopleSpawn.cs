using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawn : MonoBehaviour {

	public LevelPool ppool;
	public Transform ppl;
	public void SpawnPeople(string people,Vector3 location)
	{
		
		ppl = ppool.PeopleRemovePool (people);
		if(ppl!=null)
		{
			ppl.SetPositionAndRotation (location,ppl.transform.rotation);
			ppl.gameObject.SetActive(true);
		}
	}
}
