using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MountainGenerator : MonoBehaviour {
	private const float WORLD_SIZE = 150;

	public GameObject Mountain;
	public GameObject Ground;
	public GameObject Player;

	private Vector2 GroundSize;
	private IList<GameObject> mountains = new List<GameObject>(12);

	private Vector2 startLocation;

	// Use this for initialization
	void Start () {
		startLocation = new Vector2(-WORLD_SIZE / 2f, -WORLD_SIZE / 2f);
		CreateTerrain();
	}

	private void CreateTerrain() {
		for (int t = 0; t < mountains.Count; ++t) {
			GameObject.Destroy(mountains[t]);
		}
		mountains.Clear();

		for (int t = 0; t < WORLD_SIZE; ++t) {
			float i = (float)Random.Range(0,WORLD_SIZE);
			float j = (float)Random.Range(0, WORLD_SIZE);
			GameObject gameObjectCreated = (GameObject)GameObject.Instantiate(Mountain, new Vector3(startLocation.x + i, 0f, startLocation.y + j), Quaternion.identity);
			gameObjectCreated.transform.Rotate(-90, 0, 0);
			mountains.Add(gameObjectCreated);
		}
	}
	
	// Update is called once per frame
	void Update () {
		/*bool worldUpdate = false;
		if (Player.transform.position.x < 0) {
			startLocation.x -= WORLD_SIZE;
			worldUpdate = true;
		}

		if (Player.transform.position.x > WORLD_SIZE) {
			startLocation.x += WORLD_SIZE;
			worldUpdate = true;
		}

		if (Player.transform.position.z > WORLD_SIZE) {
			startLocation.y += WORLD_SIZE;
			worldUpdate = true;
		}

		if (Player.transform.position.z > WORLD_SIZE) {
			startLocation.y -= WORLD_SIZE;
			worldUpdate = true;
		}

		if (worldUpdate) {
			Debug.Log("Updating world");
			CreateTerrain();
		}*/

	}


}
