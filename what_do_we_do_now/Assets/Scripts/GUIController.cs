using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour
{
	public PlayerController playerC;

	public Transform playerTransform,mainCameraTransform;

	private void Awake()
	{
	}

	private void Update()
	{
		ButtonClickActions();

		mainCameraTransform.position = new Vector3(playerTransform.position.x,mainCameraTransform.position.y,playerTransform.position.z - 10);
	}


	private void ButtonClickActions()
	{

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
