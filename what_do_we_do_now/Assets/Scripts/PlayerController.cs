using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float directionModifer = 1f;

	private void Start()
	{
		
	}

	private void Update()
	{
		
	}

	public void MoveToLocation(Vector3 _direction)
	{
		Vector3 _targetPos = _direction * directionModifer;
		transform.Translate(_targetPos);

	}
}
