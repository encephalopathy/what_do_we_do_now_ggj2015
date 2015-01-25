using UnityEngine;
using System.Collections;

public class Behavior_DimBrighten : EnemyBehavior
{
	private MainLight mainLight;

	public bool bDim;

	public float lightChangeSpeed = 0.1f;



	protected override void Awake ()
	{
		base.Awake();
		mainLight = GameObject.Find("MainLight").GetComponent<MainLight>();

		if(Random.Range(0,2) == 0)
			bDim = true;
	}

	protected override void Start()
	{
		base.Start();
	}

	private void Update()
	{
		if(Vector3.Distance(myTransform.position,playerTransform.position) < 5)
		{
			mainLight.ChangeLighting(bDim);
		}
	}
}
