using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveToLocation(Vector3 _direction){

		transform.Translate(_direction);

	}
}
