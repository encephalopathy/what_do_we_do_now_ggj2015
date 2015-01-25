using UnityEngine;
using System.Collections;

public class Behavior_KnockBack : EnemyBehavior {

	public float knockBackForce = 0.5f;

	void OnTriggerEnter(Collider other){

		if(other.tag == "Player"){
			
			player.StartCoroutine (KnockBackSequence());
		}
	}

	public IEnumerator KnockBackSequence(){

		if(player.isKnockedBack) yield break;

		player.isKnockedBack = true;

		Vector3 _direction = (playerTransform.position - myTransform.position).normalized; 
		_direction = new Vector3(_direction.x, 0f, _direction.z);
		float _timerLength = 1.5f;
		float _curTimer = 0f;

		while(_curTimer <= _timerLength){
			_curTimer+= Time.deltaTime;
			//Debug.Log (_direction * knockBackForce * (_timerLength - _curTimer));
			playerTransform.position += _direction * knockBackForce * (_timerLength - _curTimer);
			
			yield return new WaitForFixedUpdate();
		}

		player.isKnockedBack= false;

	}

}
