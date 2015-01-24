using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static GameController c;

	public List <GameObject> listOfEnemyPrefab = new List<GameObject>();


	public void Awake(){

		c= this;
	}

//	void OnGUI() {
//	
//		if (GUI.Button(new Rect(10, 10, 50, 50), "Create Random Enemy")){
//
//			Debug.Log("Clicked the button");
//			CreateRandomEnemyAtRandomLocation();
//		}
//			
//
//	}

	public void CreateRandomEnemyAtPos(Vector3 _pos){

		if(listOfEnemyPrefab == null || listOfEnemyPrefab.Count <=0) {

			Debug.Log("ERROR: Populate list of enemy prefab");
			return;
		}

		GameObject _obj = Instantiate(listOfEnemyPrefab[Random.Range(0, listOfEnemyPrefab.Count)]) as GameObject;
		_obj.transform.position = _pos;
		_obj.SetActive(true);

	}

	public void CreateRandomEnemyAtRandomLocation(){

		float _randomXWorldPos = (float)Random.Range(-150, 150);
		float _randomZWorldPos = (float)Random.Range(-150, 150);

		CreateRandomEnemyAtPos(new Vector3 (_randomXWorldPos, 0f, _randomZWorldPos));

	}


}
