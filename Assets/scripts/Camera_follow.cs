using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour {
	public Transform player;
	void Start () {
		
	}
	

	void Update() {
		transform.position = new Vector3 (player.position.x , player.position.y-0.11f, -10f);
	}
}
