using UnityEngine;
using System.Collections;

public enum DirectionalType { normal, reverseAll, changeCameraAngle }

public class Behavior_ChangesControlDirections : EnemyBehavior {

	public DirectionalType directionType;


	//private variables
	private float original_playerDistanceFromCamera_Length;
	private float original_playerDistanceFromCamera_Height;

	private Vector3 original_playerVectorAngleFromCamera;
	 
	void OnEnable(){
		RandomizeDirectionType();
	}

	protected override void Awake(){

		base.Awake();
		original_playerDistanceFromCamera_Length = Vector3.Distance(player.transform.position, 
		                                                     new Vector3 (Camera.main.transform.position.x, 0, Camera.main.transform.position.z));

		original_playerDistanceFromCamera_Height = Camera.main.transform.position.y - player.transform.position.y;
		original_playerVectorAngleFromCamera = (Camera.main.transform.position - player.transform.position).normalized;
	}

	public void ChangeControlDirection(){

		if(player == null) return;


		if(player.directionModifer == -1f)
			player.directionModifer = 1f;
		else if(player.directionModifer == 1f)
			player.directionModifer = -1f;
	}

	public void RandomizeDirectionType(){

		directionType = (DirectionalType) Random.Range(0, System.Enum.GetValues(typeof(DirectionalType)).Length);


	}

	public void ChangeRandomCameraAngle(){

		float _randomAngle = Random.Range(90,225);

		Vector3 _targetPos = Quaternion.AngleAxis(_randomAngle, Vector3.up) * Vector3.forward * original_playerDistanceFromCamera_Length 
			+ player.transform.position + new Vector3 (0, original_playerDistanceFromCamera_Height, 0);

		Camera.main.transform.position = _targetPos;
		Camera.main.transform.LookAt(playerTransform.position);

	}

	public void RevertBackToNormalCameraAngle(){

		Vector3 _targetPos = original_playerVectorAngleFromCamera * original_playerDistanceFromCamera_Length 
			+ player.transform.position + new Vector3 (0, original_playerDistanceFromCamera_Height, 0);
		
		Camera.main.transform.position = _targetPos;
		Camera.main.transform.LookAt(playerTransform.position);

	}

	void OnTriggerEnter (Collider other){

		if(other.tag == "Player"){

			if(directionType == DirectionalType.normal){
				RevertBackToNormalCameraAngle();
				ChangeControlDirection();
			}

			else if(directionType == DirectionalType.reverseAll) {
				ChangeControlDirection();
			}

			else if(directionType == DirectionalType.changeCameraAngle) {

				ChangeRandomCameraAngle();
			}



		}
	}


}
