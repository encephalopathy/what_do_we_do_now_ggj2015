using UnityEngine;
using System.Collections;

public class MainLight : MonoBehaviour
{
	public Light myLight;

	private Shader diffuseShader;
	private Shader refractionShader;

	public GameObject Ground;

	private bool bDimLast = false;

	float originalIntensity;

	private void Start()
	{
		originalIntensity = myLight.intensity;
		diffuseShader = Shader.Find("Diffuse");
		refractionShader = Shader.Find("FX/Glass/Stained BumpDistort");
	}

	void Update() {
	}

	public void ChangeLighting(bool bDim)
	{
		Ground.renderer.material.shader = diffuseShader;
		if(bDim)
		{
			myLight.intensity -= 0.003f;
		}
		else
		{
			myLight.intensity += 0.05f;
		}
	}
}
