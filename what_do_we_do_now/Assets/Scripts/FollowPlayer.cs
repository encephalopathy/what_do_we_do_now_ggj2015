using UnityEngine;
using System.Collections;

public class Behavior_Follow : EnemyBehavior
{

	public bool bChase;

	public float speed;

	protected override void Start()
	{
		base.Start();
	}

	void Update () {
	
		if(isFollowTarget && targetTrans !=null ) FollowTarget (targetTrans);
	}

	public void MoveToTarget(Vector2 _direction){

		transform.Translate(_direction);

	}

	public void FollowTarget(Transform target){

		if(Vector2.Distance(target.position, transform.position) >= 5f){

			Vector2 moveToPos = (target.position - transform.position ).normalized;
			MoveToTarget(moveToPos * speed);

		}

	}


}
