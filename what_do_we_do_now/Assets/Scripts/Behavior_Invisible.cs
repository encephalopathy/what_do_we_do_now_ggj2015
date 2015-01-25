using UnityEngine;
using System.Collections;

public class Behavior_Invisible : EnemyBehavior
{
	

	protected override void Start()
	{
		base.Start();
	}

//	private void OnTriggerEnter(Collider collider)
//	{
//		if(collider.transform == playerTransform)
//		{
//			player.ToggleInvisible();
//		}
//	}
}
