using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public Transform Ground;
	public float directionModifer = 1f,speed = 6f;
	public bool isKnockedBack = false;
	//[System.NonSerialized] public bool bInvisible;

	private Vector3 _rotation = Vector3.zero;
	private Vector3 _lastDirection;

	public Portal portal1,portal2;

	private void Start()
	{

	}

	private void Update()
	{
		gameObject.transform.Rotate(_rotation * speed);

		Ground.position = new Vector3(transform.position.x,Ground.position.y,transform.position.z);
	}

	public void MoveToLocation(Vector3 _direction)
	{
		if(isKnockedBack == true) return;

		Vector3 _targetPos = _direction * directionModifer * speed * Time.deltaTime;
		
		if (_lastDirection != _direction) {
		Color randomColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
		//Debug.Log("Random Color: " + randomColor);
		gameObject.renderer.material.SetColor("_LineColor", randomColor);
		}
		_lastDirection = _direction;
		_rotation =_direction;
		transform.position +=  _targetPos;
	}

//	public void ToggleInvisible()
//	{
//		bInvisible = !bInvisible;
//
//		if(bInvisible)
//			renderer.material.color = Color.black;
//		else
//			renderer.material.color = Color.white;
//	}
}
