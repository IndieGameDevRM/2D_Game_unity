using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour {

	public void LoadScene(){
		SceneManager.LoadScene ("scene1");
	}
	public void loadmenu(){
		SceneManager.LoadScene ("menu"); 
	}
}
