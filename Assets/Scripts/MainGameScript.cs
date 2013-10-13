using UnityEngine;
using System.Collections;

public class MainGameScript : MonoBehaviour {
	
	
	public AudioClip Walk;
	public AudioClip Land;
	public AudioClip Climb;
	public AudioClip Die;
	public AudioClip Jump;
	
	public static bool isAlive;
	public static bool win;
	public static bool gameOver;
	

	// Use this for initialization
	void Start () {
		isAlive = true;
		win = false;
		gameOver = false;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void onButton(){
		Application.LoadLevel(Application.loadedLevel);
	}
		
}
