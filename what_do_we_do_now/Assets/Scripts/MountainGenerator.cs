using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MountainGenerator : MonoBehaviour {
	private float WORLD_SIZE = 150;

	public GameObject Mountain;
	public GameObject Ground;
	public GameObject Player;

	private Vector2 GroundSize;
	private IList<GameObject> mountains = new List<GameObject>(12);

	private Vector2 startLocation;
	private int worldOffset = 0;

	// Use this for initialization
	void Start () {

		CreateTerrain();
	}

	private void CreateTerrain() {
		for (int t = 0; t < mountains.Count; ++t) {
			GameObject.Destroy(mountains[t]);
		}
		mountains.Clear();

		startLocation = new Vector2(Player.transform.position.x, Player.transform.position.z);
		for (int t = 0; t < WORLD_SIZE; ++t) {
			float i = (float)Random.Range(0, WORLD_SIZE);
			float j = (float)Random.Range(0, WORLD_SIZE);
			GameObject gameObjectCreated = (GameObject)GameObject.Instantiate(Mountain, new Vector3(i + startLocation.x - WORLD_SIZE / 2, Player.transform.position.y - 0.2f, j + startLocation.y - WORLD_SIZE / 2), Quaternion.identity);
			gameObjectCreated.transform.Rotate(-90, 0, 0);
			gameObjectCreated.transform.localScale = new Vector3(250, 250, 250);
			mountains.Add(gameObjectCreated);
		}
	}
	
	// Update is called once per frame
	void Update () {
		bool worldUpdate = false;

		if (Mathf.Abs(startLocation.x - Player.transform.position.x) > WORLD_SIZE / 2) {
			worldUpdate = true;
		}

		if (Mathf.Abs(startLocation.y - Player.transform.position.z) > WORLD_SIZE / 2) {
			worldUpdate = true;
		}

		if (worldUpdate) {
			Debug.Log("Updating world");
			WORLD_SIZE *= 2;
			CreateTerrain();

		}

	}


}
