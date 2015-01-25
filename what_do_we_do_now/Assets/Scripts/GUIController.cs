using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour
{
	public PlayerController playerC;

	public Behavior_ChangesControlDirections changeDir;
	public Transform playerTransform,mainCameraTransform;

	private float startButtonSize_height = 60;
	private float startButtonSize_width = 150;

	private float instructionText_height = 50;
	private float instructionText_width = 250;

	public GameObject UIBeginningScene;
	public TweenPosition _tweenPos;
	public TweenScale UIStartButton;

	private void Awake()
	{
		Time.timeScale = 0f;

	}

	private void Update()
	{
		ButtonClickActions();


		mainCameraTransform.position = new Vector3(playerTransform.position.x,mainCameraTransform.position.y,playerTransform.position.z - 10);
		mainCameraTransform.LookAt(playerTransform.position);

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

	public void StartGame(){

		Time.timeScale = 1;


		//TweenPosition _tweenPos = GameObject.Find("Instructions").GetComponent<TweenPosition>();
		_tweenPos.from = new Vector3 (0,150,0);
		_tweenPos.to = new Vector3 (800, 120,0);
		_tweenPos.enabled =true;
		_tweenPos.ResetToBeginning();

		StartCoroutine(FadeOpeningScene());
		UIStartButton.enabled = true;


	}

	public IEnumerator FadeOpeningScene(){

		yield return new WaitForSeconds(1f);
		UIBeginningScene.SetActive(false);
	}


	//bool _showStartButton = true;



//	void OnGUI() {
//
//
//
//		 
//		if(_showStartButton){
//
//			GUIStyle customButton = new GUIStyle("button");
//			customButton.fontSize = 18;
//			
//
//			bool _text = GUI.Button(new Rect (Screen.width/2 - instructionText_width/2, 70f, 
//			                                              instructionText_width, instructionText_height),  "Follow the bread crumb....", customButton);
//
//
//
//			if(GUI.Button(new Rect(Screen.width/2 - startButtonSize_width/2, Screen.height/2 - startButtonSize_height/2, 
//			                       startButtonSize_width, startButtonSize_height), "Start"))
//			{
//
//				Time.timeScale = 1f;
//				_showStartButton = false;
//				
//			}
//
//		}
//
//
//		
//	}

}
