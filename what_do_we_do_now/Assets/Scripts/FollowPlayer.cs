using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public bool isFollowTarget = false;
	public Transform targetTrans;
	public float speed;

	void Awake(){



	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
