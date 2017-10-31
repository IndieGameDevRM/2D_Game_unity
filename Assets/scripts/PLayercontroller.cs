using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PLayercontroller : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;
	public Button btn1;
	bool collider_bool;
	public GameObject cannon;
	GameObject clone;
	public GameObject spike;
	float timer;

	void Start (){
		timer = 0;
		rb = GetComponent<Rigidbody2D> ();
		Button btn = btn1.GetComponent<Button> ();
		btn.onClick.AddListener (jump);
		collider_bool = false;
	}
	

	public void moveforward(){
		Vector2 movefor = new Vector2 (speed, 0);
		rb.velocity=movefor;
	}
	public void moveback(){
		Vector2 movbak = new Vector2 (-speed, 0);
		rb.velocity = movbak;
	}
	public void setvelzero(){
		Vector2 setVel = new Vector2 (0, 0);
		rb.velocity = setVel;
	}
	public void jump(){
		if (collider_bool == true) {
			Vector2 jmp = new Vector2 (0, 15);
			rb.velocity = jmp;
			collider_bool = false;
		}
	}
	public void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "ground") {
			collider_bool = true;

		} else if (col.gameObject.tag == "specialcoll") {
			collider_bool = true;
		}
		if (col.gameObject.tag == "levelup") {
			SceneManager.LoadScene ("level2");		
		}
	}
	void OnCollisionStay2D(Collision2D col){
		
		if (col.collider.gameObject.tag == "specialcoll") {
			if (timer > 0.3) {
				clone = Instantiate (cannon, cannon.transform.position, transform.rotation) as GameObject;
				clone.GetComponent<Rigidbody2D>().velocity = new Vector2 (-8, 0);
				timer = 0;
			}
			timer += 0.01f;
		
		}
		Destroy (clone, 5);
		float downforce=2.2f;
		if (col.collider.gameObject.tag == "specialcoll2") {
			if (spike.transform.position.y < 19 && spike.transform.position.y > 7) {
				spike.transform.Translate (0, downforce * Time.deltaTime, 0);
			} else if (spike.transform.position.y < 9.3f) {
				spike.transform.position = new Vector2 (spike.transform.position.x, 16.72f);
			}
		}	
	}
}
