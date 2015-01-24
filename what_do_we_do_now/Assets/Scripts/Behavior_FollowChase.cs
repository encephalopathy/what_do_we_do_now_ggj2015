using UnityEngine;
using System.Collections;

public class Behavior_FollowChase : EnemyBehavior
{

	public bool bChase;

	public float speed;

	protected override void Start()
	{
		base.Start();
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

	public void MoveToTarget(Vector3 _direction)
	{
		myTransform.Translate(_direction);
	}

	public void FollowTarget(Transform target)
	{
		if(Vector3.Distance(target.position,myTransform.position) >= 5f)
		{
			Vector3 moveToPos = new Vector3(target.position.x - myTransform.position.x,myTransform.position.y,target.position.z - myTransform.position.z);

			MoveToTarget(moveToPos * speed);
		}
	}

	public void ChaseTarget(Transform target)
	{
		Vector3 moveToPos = (target.position - myTransform.position);
		
		MoveToTarget(moveToPos * speed);
	}
}
