using UnityEngine;
using System.Collections;

public class MainLight : MonoBehaviour
{
	public Light myLight;

	float originalIntensity;

	private void Start()
	{
		originalIntensity = myLight.intensity;
	}

	public void ChangeLighting(Behavior_DimBrighten.lightChangeTypes lightingChange)
	{
		if(lightingChange == Behavior_DimBrighten.lightChangeTypes.dim)
		{
			myLight.intensity -= 0.003f;
		}
		else
		{
			myLight.intensity += 0.003f;
		}
	}
}
