using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 0.1f;

	private void Start()
	{
		
	}

	private void Update()
	{
		
	}

	public void MoveToLocation(Vector3 _direction)
	{
		transform.Translate(_direction * speed);
	}
}
