using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
	private List<Vector3> hardPoints = new List<Vector3>();

	public EnemyController enemyCon;

	private void Start()
	{
		int spreadAmount = 5;

		hardPoints.Add(transform.position);
		hardPoints.Add(new Vector3(transform.position.x,transform.position.y + spreadAmount,transform.position.z));
		hardPoints.Add(new Vector3(transform.position.x,transform.position.y + spreadAmount * 2,transform.position.z));
	}

	private void Update()
	{

	}

	public void GenerateBodyParts()
	{
		int bodyPartAmount = 2;

		if(Random.Range(0,1f) < 0.35f)
			bodyPartAmount = 3;

		for(int i=0; i<bodyPartAmount; i++)
		{
			GameObject newBodyPart = enemyCon.bodyParts[Random.Range(0,enemyCon.bodyParts.Count)];

			Instantiate(newBodyPart,hardPoints[bodyPartAmount],newBodyPart.transform.rotation);
		}
	}
}
