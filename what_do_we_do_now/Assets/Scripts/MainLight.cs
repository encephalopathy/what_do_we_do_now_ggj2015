using UnityEngine;
using System.Collections;

public class MainLight : MonoBehaviour
{
	public Light myLight;

	public GameObject Ground;
	public GameObject diffuseGround;

	private bool bDimLast = false;

	float originalIntensity;

	private void Start()
	{
		originalIntensity = myLight.intensity;

		ModifyDiffuseGroundTransparency();
	}

	public void ChangeLighting(bool bDim)
	{
		if(bDim)
		{
			myLight.intensity -= 0.005f;
		}
		else if(myLight.intensity < 1f)
		{
			myLight.intensity += 0.005f;
		}

		ModifyDiffuseGroundTransparency();
	}

	private void ModifyDiffuseGroundTransparency()
	{
		Color diffuseGroundColor = diffuseGround.renderer.material.color;
		float lightIntensityCompare = Mathf.Abs(myLight.intensity - originalIntensity);

		diffuseGround.renderer.material.color =
		new Color(diffuseGroundColor.r,diffuseGroundColor.g,diffuseGroundColor.b,lightIntensityCompare + Mathf.Lerp(0,0.5f,lightIntensityCompare/0.5f));
	}
}
