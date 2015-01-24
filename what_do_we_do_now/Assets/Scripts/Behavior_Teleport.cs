using UnityEngine;
using System.Collections;

public class Behavior_Teleport : EnemyBehavior
{


	protected override void Start()
	{
		base.Start();
	}

	private void OnTriggerEnter(Collider collider)
	{
		if(collider.transform == playerTransform)
		{
			float randomModifier = 20f,
			randomXPos = Random.Range(-randomModifier,randomModifier),randomZPos = Random.Range(-randomModifier,randomModifier);
			
			playerTransform.position = 
			new Vector3(playerTransform.position.x + randomXPos,playerTransform.position.y,playerTransform.position.z + randomZPos);
		}
	}
}
