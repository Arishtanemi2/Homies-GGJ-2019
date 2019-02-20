using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPool : MonoBehaviour {

	public Transform activePool;
	public Transform inactivePool;
	public Transform obj;
	public int inPool;
	void Awake()
	{
		inPool = activePool.childCount-1;
	}

	public Transform RemovePool()
	{
		inPool = activePool.childCount-1;
		if(inPool!=-1)
			{
			obj = activePool.GetChild (Random.Range (0, inPool--));
			obj.parent = inactivePool;
			return obj;
			}
		else 
		{
			
			return null;
		}
	}
	public Transform PeopleRemovePool(string name)
	{
		inPool = activePool.childCount-1;
		if(inPool!=-1)
			{
			obj = activePool.Find(name);
			obj.parent = inactivePool;
			return obj;
			}
		else 
		{
			
			return null;
		}
	}
	public void AddPool(Transform trans)
	{
		
		trans.parent = activePool;
		trans.gameObject.SetActive(false);
		inPool++;
	}

}