using UnityEngine;
using System.Collections;

public enum SpeedType {normal, slow, fast}

public class Behavior_ChangeSpeed : EnemyBehavior {

	public SpeedType speedType;
	public float playerDefaultSpeed;

	protected override void Start(){
		base.Start();
		playerDefaultSpeed = player.speed;
	}

	void OnEnable(){
		
		RandomizeSpeedType();
	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.tag == "Player"){
			
			ChangePlayerSpeed();
		}
	}
	
	public void RandomizeSpeedType(){
		
		speedType = (SpeedType) Random.Range(0, System.Enum.GetValues(typeof(SpeedType)).Length);
		
		
	}
	
	public void ChangePlayerSpeed(){
		
		if(speedType == SpeedType.fast){
			
			player.speed = playerDefaultSpeed *2f;
		}
		
		else if(speedType == SpeedType.normal){
			
			player.speed = playerDefaultSpeed *1f;
		}
		
		else if(speedType ==  SpeedType.slow){
			
			player.speed = playerDefaultSpeed *0.5f;
		}
	}


}
