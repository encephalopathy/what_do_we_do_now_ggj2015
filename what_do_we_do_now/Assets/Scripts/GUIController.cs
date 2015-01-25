using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour
{
	public PlayerController playerC;

	public Behavior_ChangesControlDirections changeDir;
	public Transform playerTransform,mainCameraTransform;

	private float startButtonSize_height = 60;
	private float startButtonSize_width = 150;

	private float instructionText_height = 30;
	private float instructionText_width = 150;

	private void Awake()
	{
		Time.timeScale = 0f;

	}

	private void Update()
	{
		ButtonClickActions();


		mainCameraTransform.position = new Vector3(playerTransform.position.x,mainCameraTransform.position.y,playerTransform.position.z - 10);
		if(Input.GetKeyDown(KeyCode.R)){

			Debug.Log("pressed R");
			changeDir.ChangeRandomCameraAngle();

		}

		if(Input.GetKeyDown(KeyCode.E)){
			
			Debug.Log("pressed E");
			//playerC.gameObject.AddComponent<Behavior_Teleport>();
		}


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

	bool _showStartButton = true;

	void OnGUI() {



		 
		if(_showStartButton){


			string _stringToEdit = GUI.TextArea(new Rect (Screen.width/2 - instructionText_width/2, 30f, 
			                                              instructionText_width, instructionText_height),  "The WTF Game", 200);



			if(GUI.Button(new Rect(Screen.width/2 - startButtonSize_width/2, Screen.height/2 - startButtonSize_height/2, 
			                       startButtonSize_width, startButtonSize_height), "Start"))
			{

				Time.timeScale = 1f;
				_showStartButton = false;
				
			}

		}


		
	}

}
