using UnityEngine;
using System.Collections;

public class Behavior_FollowChase : EnemyBehavior
{

	public bool bChase;

	public float speed = 5;

	protected override void Start()
	{
		base.Start();

		if(Random.Range(0,2) == 0)
		{
			bChase = true;
		}
	}

	private void Update()
	{
		if(Vector3.Distance(myTransform.position,playerTransform.position) < 10f)
		{
			if(!bChase)
				FollowTarget(playerTransform);
			else
				ChaseTarget(playerTransform);
		}
	}

	public void FollowTarget(Transform target)
	{
		Debug.Log ("I am following");

		if(Vector3.Distance(target.position,myTransform.position) >= 5f)
		{
			Vector3 followPosition = Vector3.MoveTowards(myTransform.position,target.position,Time.deltaTime * speed);

			myTransform.position = new Vector3(followPosition.x,myTransform.position.y,followPosition.z);
		}
	}

	public void ChaseTarget(Transform target)
	{

		Debug.Log ("I am chasing");
		Vector3 followPosition = Vector3.MoveTowards(myTransform.position,target.position,Time.deltaTime * speed);
		
		myTransform.position = new Vector3(followPosition.x,myTransform.position.y,followPosition.z);
	}
}
