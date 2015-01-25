using UnityEngine;
using System.Collections;

public enum SizeType {normal, small, big}

public class Behavior_ChangeSize : EnemyBehavior {



	public SizeType sizeType;

	void Update(){

		CheckProximityAndAdjustSize();
	}

	void OnEnable(){

		RandomizePlayerSize();
	}

//	void OnTriggerEnter(Collider other){
//		
//		if(other.tag == "Player"){
//			
//			ChangePlayerSize();
//		}
//	}

	public void CheckProximityAndAdjustSize(){

		if((myTransform.position - playerTransform.position).magnitude < 8f){

			ChangePlayerSize();
		}
	}

	public void RandomizePlayerSize(){
		
		sizeType = (SizeType) Random.Range(0, System.Enum.GetValues(typeof(SizeType)).Length);
		
		
	}

	public void ChangePlayerSize(){

		if(sizeType == SizeType.big){
			if(playerTransform.localScale.x <=3f)
				playerTransform.localScale = Vector3.Lerp(playerTransform.localScale, new Vector3 (3f,3f,3f), Time.deltaTime);
		}

		else if(sizeType == SizeType.normal){

			if(playerTransform.localScale.x != 1f)
				playerTransform.localScale = Vector3.Lerp(playerTransform.localScale, new Vector3 (1f,1f,1f), Time.deltaTime);
		}

		else if(sizeType == SizeType.small){
			if(playerTransform.localScale.x >=0.5f)
				playerTransform.localScale = Vector3.Lerp(playerTransform.localScale, new Vector3 (0.5f,0.5f,0.5f), Time.deltaTime);
		}
	}

}
