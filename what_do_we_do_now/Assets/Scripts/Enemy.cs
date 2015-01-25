using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
	private List<Vector3> hardPoints = new List<Vector3>();

	public EnemyController enemyCon;
	public PlayerController playerC;

	private Vector3 _targetPos;
	public float speed = 6f;

	void Awake(){

		playerC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	private void Start()
	{
		int spreadAmount = 5;

		hardPoints.Add(transform.position);
		hardPoints.Add(new Vector3(transform.position.x,transform.position.y + spreadAmount,transform.position.z));
		hardPoints.Add(new Vector3(transform.position.x,transform.position.y + spreadAmount * 2,transform.position.z));
	}

	private void Update()
	{
		MoveToPos();
		CheckIfEnemyIsFarFromPlayer();
	}

	public void GenerateBodyParts()
	{
		int bodyPartAmount = 2;

		if(Random.Range(0,1f) < 0.35f)
			bodyPartAmount = 3;

		for(int i=0; i<bodyPartAmount; i++)
		{
			GameObject newBodyPart = enemyCon.bodyParts[Random.Range(0,enemyCon.bodyParts.Count)];

			Instantiate(newBodyPart,hardPoints[bodyPartAmount],newBodyPart.transform.rotation);
		}
	}

	public void MoveToPos(){

		if(this.gameObject.GetComponent<Behavior_FollowChase>() != null) return;

		Vector3 _direction = _targetPos -  transform.position ;
		_direction = new Vector3 (_direction.x, 0f, _direction.z);

		if(_direction.magnitude >=2f){

			transform.Translate(_direction.normalized * speed *Time.deltaTime );

		}

		else{

			_targetPos = new Vector3(Random.Range (-50, 50), 0f, Random.Range(-50,50)); 
		}

	}

	public void CheckIfEnemyIsFarFromPlayer (){

		if(playerC == null) return;
		if(Vector3.Distance (transform.position, playerC.transform.position) > 25f){ 

			Destroy(this.gameObject);
		}

	}
}
