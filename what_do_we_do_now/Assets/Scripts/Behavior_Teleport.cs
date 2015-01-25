using UnityEngine;
using System.Collections;

public enum TeleportType {toOrigin, random}

public class Behavior_Teleport : EnemyBehavior
{
	public TeleportType teleportType;
	public Vector3 defaultPosition;

	protected override void Start()
	{
		base.Start();
		defaultPosition = playerTransform.position;
		RandomizeTeleportType();
	}

	private void OnTriggerEnter(Collider collider)
	{
		if(collider.transform == playerTransform)
		{

			if(teleportType == TeleportType.random){
				float randomModifier = 20f,
				randomXPos = Random.Range(-randomModifier,randomModifier),randomZPos = Random.Range(-randomModifier,randomModifier);
				
				playerTransform.position = 
					new Vector3(playerTransform.position.x + randomXPos,playerTransform.position.y,playerTransform.position.z + randomZPos);

			}

			else if(teleportType == TeleportType.toOrigin){

				if(defaultPosition != null)
				playerTransform.position  = defaultPosition;
			}
		}
	}

	private void RandomizeTeleportType(){

		teleportType = (TeleportType) Random.Range (0, System.Enum.GetValues(typeof(TeleportType)).Length);
	}
}
