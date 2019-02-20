using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   
    public int radius;
    public Vector2 timePeriod;
    WaitForSeconds randomtime;
    private  Vector3 spawnpos;
    public Transform enemy;
    public LevelPool epool;
    void Start()
    {
        StartCoroutine("startspawning");
    }
    IEnumerator startspawning()
    {
        spawnpos=RandomPointOnUnitCircle(radius);   
        //Instantiate(enemy,spawnpos+transform.position,enemy.transform.rotation);
        enemy= epool.RemovePool ();
        if(enemy!=null)
		{
			enemy.SetPositionAndRotation (transform.position+spawnpos,enemy.transform.rotation);
            enemy.gameObject.SetActive(true);
		}
        yield return new WaitForSeconds(Random.Range(timePeriod.x,timePeriod.y));
        StartCoroutine("startspawning");
    }
     public static Vector3 RandomPointOnUnitCircle(float radius)
    {
        float angle = Random.Range (0f, Mathf.PI * 2);
        float x = Mathf.Sin (angle) * radius;
        float z = Mathf.Cos (angle) * radius;
        return new Vector3 (x,0,z);
    }
}
