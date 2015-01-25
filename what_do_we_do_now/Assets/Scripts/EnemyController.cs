using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
	public PlayerController player;
	public Enemy originalEnemy;

	public List<BodyPart> bodyParts = new List<BodyPart>();
	public List<string> enemyBehaviorNames = new List<string>();

	private void Awake()
	{
		for(int i=0; i<bodyParts.Count; i++)
		{
			int randomEnemyBehaviorNameIndex = Random.Range(0,enemyBehaviorNames.Count);
			string randomEnemyBehaviorName = enemyBehaviorNames[randomEnemyBehaviorNameIndex];

			bodyParts[i].enemyBehaviorName = randomEnemyBehaviorName;

			enemyBehaviorNames.Remove(enemyBehaviorNames[randomEnemyBehaviorNameIndex]);
		}

		for(int i=0; i<10; i++)
		{
			SpawnEnemy();
		}
	}

	public void SpawnEnemy()
	{
		Vector3 _targetPos = Quaternion.AngleAxis(Random.Range(0,360), Vector3.up) * Vector3.forward * 30f + player.transform.position;
		Enemy spawnedEnemy = GameObject.Instantiate(originalEnemy,
		                                            _targetPos,
		originalEnemy.transform.rotation) as Enemy;

		spawnedEnemy.gameObject.SetActive(true);
	}
}
