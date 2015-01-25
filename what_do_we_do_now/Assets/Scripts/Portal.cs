using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public PlayerController player;

	public float scrollSpeed;
	private Vector2 savedOffset;
	
	void Start () {
		savedOffset = renderer.sharedMaterial.GetTextureOffset ("_MainTex");

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	void Update () {
		float y = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 offset = new Vector2 (savedOffset.x, y);
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
	
	void OnDisable () {
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}

	private void OnTriggerEnter(Collider collider)
	{
		if(collider.transform == player.transform)
		{
			if(this == player.portal1)
				player.transform.position = new Vector3(player.portal2.transform.position.x - 3,player.transform.position.y,player.portal2.transform.position.z);
			else
				player.transform.position = new Vector3(player.portal1.transform.position.x - 3,player.transform.position.y,player.portal1.transform.position.z);
		}
	}
}
