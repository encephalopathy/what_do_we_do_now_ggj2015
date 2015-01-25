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

	public void ChangeLighting(bool bDim)
	{
		if(bDim)
		{
			myLight.intensity -= 0.006f;
		}
		else
		{
			myLight.intensity += 0.006f;
		}
	}
}
