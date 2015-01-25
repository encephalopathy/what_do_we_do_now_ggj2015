using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
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
	}


}
