using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
	private List<Vector3> hardPoints = new List<Vector3>();

	public EnemyController enemyCon;

	private void Start()
	{
		float spreadAmount = 1.5f;

		hardPoints.Add(transform.position);
		hardPoints.Add(new Vector3(transform.position.x,transform.position.y + spreadAmount,transform.position.z));
		hardPoints.Add(new Vector3(transform.position.x,transform.position.y + spreadAmount * 2,transform.position.z));

		GenerateBodyParts();
	}

	private void Update()
	{

	}

	public void GenerateBodyParts()
	{
		int bodyPartAmount = 1;

		if(Random.Range(0,1f) < 0.5f)
			bodyPartAmount = 2;

		if(Random.Range(0,1f) < 0.3f)
			bodyPartAmount = 3;

		for(int i=0; i<bodyPartAmount; i++)
		{
			BodyPart chosenBodyPart = enemyCon.bodyParts[Random.Range(0,enemyCon.bodyParts.Count)],
			newBodyPart = Instantiate(chosenBodyPart,hardPoints[i],chosenBodyPart.transform.rotation) as BodyPart;

			newBodyPart.transform.parent = transform;

			newBodyPart.gameObject.SetActive(true);

			gameObject.AddComponent(newBodyPart.enemyBehaviorName);
		}
	}
}
