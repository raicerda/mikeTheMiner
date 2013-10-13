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
		positioning(dir);
	
	}
	
	// Update is called once per frame
	void Update () {
		positioning(dir);	
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
			
		}else{
			switch (dirParam){
				case -1:
				anim.Play("Walk");
				sprite.scale = new Vector3(-1,1,1);
				lastDir = dirParam;
				break;
				
				case 1:
				anim.Play("Walk");
				sprite.scale = new Vector3(1,1,1);
				lastDir = dirParam;
				break;
				
				case 0:
				anim.Stop();
				lastDir = dirParam;
				break;
			}
		}
	}
	
	public static void setDir(int dirPara){
		dir = dirPara;
	}
}
