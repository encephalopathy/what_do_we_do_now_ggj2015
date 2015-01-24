using UnityEngine;
using System.Collections;

public enum SizeType {normal, small, big}

public class Behavior_ChangeSize : EnemyBehavior {



	public SizeType sizeType;

	void OnEnable(){

		RandomizeDirectionType();
	}

	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player"){
			
			ChangePlayerSize();
		}
	}

	public void RandomizeDirectionType(){
		
		sizeType = (SizeType) Random.Range(0, System.Enum.GetValues(typeof(SizeType)).Length);
		
		
	}

	public void ChangePlayerSize(){

		if(sizeType == SizeType.big){

			playerTransform.localScale = new Vector3(2f,2f,2f);
		}

		else if(sizeType == SizeType.normal){
			
			playerTransform.localScale = new Vector3 (1f,1f,1f);
		}

		else if(sizeType == SizeType.small){
			
			playerTransform.localScale = new Vector3 (0.5f,0.5f,0.5f);
		}
	}

}
