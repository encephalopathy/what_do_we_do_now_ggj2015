using UnityEngine;
using System.Collections;

public class Behavior_ExplodeIntoOtherTypes : EnemyBehavior {

	public int numberOfSplits = 3;

	void OnTriggerEnter(Collider other){

		if(other.tag == "Player"){

			ExplodeIntoOtherTypes(numberOfSplits);
		}
	}

	public void ExplodeIntoOtherTypes(int numOfTypes){

		for (int i = 0; i < numberOfSplits; i++) {

			GameController.c.CreateRandomEnemyAtPos(myTransform.position + new Vector3(Random.Range(0,5f), 0, Random.Range(0,5f)));


		}

		Destroy (this.gameObject);
	}
}
