using UnityEngine;
using System.Collections;

public class Behavior_DimBrighten : EnemyBehavior
{
	public MainLight mainLight;

	public enum lightChangeTypes {dim,brighten};
	public lightChangeTypes lightChangeType;

	public float lightChangeSpeed = 0.1f;

	protected override void Start()
	{
		base.Start();


	}

	private void Update()
	{
		if(Vector3.Distance(myTransform.position,playerTransform.position) < 5)
		{
			mainLight.ChangeLighting(lightChangeType);
		}
	}
}
