using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 0.1f;

	[System.NonSerialized] public bool bInvisible;

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

	public void ToggleInvisible()
	{
		bInvisible = !bInvisible;

		if(bInvisible)
			renderer.material.color = Color.black;
		else
			renderer.material.color = Color.white;
	}
}
