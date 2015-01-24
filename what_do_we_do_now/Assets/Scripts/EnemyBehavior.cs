using UnityEngine;
using System.Collections;

public abstract class EnemyBehavior : MonoBehaviour
{
	public PlayerController player;

	public Transform myTransform;


	protected virtual void Awake(){

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	protected virtual void Start()
	{
		
	}
}
