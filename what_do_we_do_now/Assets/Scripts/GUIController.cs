using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public PlayerController playerC;

	void Awake(){

		playerC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void Update(){

		ButtonClickActions();
	}


	private void ButtonClickActions(){

		Vector3 _direction = Vector3.zero;
		
		if (Input.GetKey (KeyCode.DownArrow)){
			_direction += Vector3.back;
		}
		
		if (Input.GetKey (KeyCode.UpArrow)){
			_direction += Vector3.forward;
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)){
			_direction += Vector3.left;
		}
		
		if (Input.GetKey (KeyCode.RightArrow)){
			_direction += Vector3.right;
		}

		playerC.MoveToLocation(_direction);
	}

}
