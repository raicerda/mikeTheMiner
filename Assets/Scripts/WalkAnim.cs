using UnityEngine;
using System.Collections;

public class WalkAnim : MonoBehaviour {
	
	public static bool facingRight;
	public static bool isMovingRight;
	public static bool facingLeft;
	public static bool isMovingLeft;
	public static bool jumping;
	public static bool grappling;
	public static bool stand;
	public static int lastDir;
	public static int dir;
	public tk2dSpriteAnimator anim;
	public tk2dSprite sprite;
	public static bool isAlive;
	public static bool gameOver;
	public static bool win;
	
	
	
	// Use this for initialization
	void Start () {
		lastDir = 0;
		dir = 0;
		facingLeft=false;
		isMovingRight = false;
		facingRight=false;
		isMovingLeft = false;
		jumping = false;
		grappling = false;
		stand = true;
		isAlive = true;
		gameOver = false;
		win = false;
		positioning(dir);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isAlive) positioning(dir);	
	}
	
	void Anim () {
			
		if(facingRight && !isMovingRight){
			isMovingRight = true;
			isMovingLeft = false;
			//TODO anim to right;
		}
		if(facingLeft && !isMovingLeft){
			isMovingLeft = false;
			isMovingLeft = true;
		}
		
	}
	
	void positioning(int dirParam){
		if(lastDir == dirParam){
			//Debug.Log ("MISMA DIRECCION");
		}else{
			switch (dirParam){
				case -1:
				anim.Play("Walk");
				sprite.scale = new Vector3(-1,1,1);
			Debug.Log ("CAMBIO -1");
				lastDir = dirParam;
				break;
				
				case 1:
				anim.Play("Walk");
				sprite.scale = new Vector3(1,1,1);
			Debug.Log ("CAMBIO 1");
				lastDir = dirParam;
				break;
				
				case 0:
				anim.Stop();
			Debug.Log ("CAMBIO 0");
				lastDir = dirParam;
				break;
				
				case 2:
				//TODO correr animacion salto
				anim.Play("Jump");
			Debug.Log ("CAMBIO 2");
				lastDir = dirParam;
				sprite.scale = new Vector3(1,1,1);
				break;
				
				case -2:
				//TODO correr animacion salto izq
				anim.Play("Jump");
			Debug.Log ("CAMBIO 2");
				lastDir = dirParam;
				sprite.scale = new Vector3(-1,1,1);
				break;
				
				case 3:
				//TODO correr animacion de salto pegado
			Debug.Log ("CAMBIO 3");
				anim.Play("Grapple");
				lastDir = dirParam;
				break;
				
				case -3:
				//TODO correr animacion salto pegado izq
			Debug.Log ("CAMBIO -3");
				lastDir = dirParam;
				break;
				
				case 5:
				Debug.Log("CAMBIO 5");
				anim.Play ("Grapple");
				lastDir = dirParam;
				break;
				
				case 6:
				Debug.Log("CAMBIO 6");
				anim.Play ("Death");
				lastDir = dirParam;
				break;
			}
		}
	}
	
	public static void setDir(int dirPara){
		dir = dirPara;
	}
}
