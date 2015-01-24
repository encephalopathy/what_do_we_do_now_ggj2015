using UnityEngine;
using System.Collections;

public abstract class EnemyBehavior : MonoBehaviour
{
	public PlayerController player;

	public Transform myTransform,playerTransform;

	protected virtual void Start()
	{
		
	}
}
