using UnityEngine;
using System.Collections;

public abstract class EnemyBehavior : MonoBehaviour
{
	protected PlayerController player;

	protected Transform myTransform,playerTransform;

	protected virtual void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		myTransform = GetComponent<Transform>();
		playerTransform = player.transform;
	}

	protected virtual void Start()
	{
		
	}
}
