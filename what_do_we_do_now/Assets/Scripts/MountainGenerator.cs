using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MountainGenerator : MonoBehaviour {
	public GameObject Mountain;
	public GameObject plane;

	private Vector2 planeSize;
	private IList<GameObject> mountains = new List<GameObject>(12);
	// Use this for initialization
	void Start () {
		Vector3 fullSize = plane.transform.renderer.bounds.size;
		planeSize = new Vector2(fullSize.z, fullSize.x);
		Debug.Log("Game world size: " + fullSize);
		int delta = 10;
		float stepSizeX = fullSize.x / delta;
		float stepSizeY = fullSize.y / delta;
		float interpolationFactor = 1f / delta;
		for (float i = 0; i < 1; i += interpolationFactor) {
			for (float j = 0; j < 1; j += interpolationFactor) {
				float scaleFactor = Mathf.PerlinNoise(i, j);
				//Debug.Log("Perlin Noise value: " + scaleFactor);
				if (scaleFactor > 0.25f) {
					GameObject gameObjectCreated = (GameObject)GameObject.Instantiate(Mountain, new Vector3((float)(stepSizeX * i * delta), 0f, (float)(stepSizeY * j * delta)), Quaternion.identity);
					mountains.Add(gameObject);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}


}
