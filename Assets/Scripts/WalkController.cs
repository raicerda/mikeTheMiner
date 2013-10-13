using UnityEngine;
using System.Collections;

public class WalkController : MonoBehaviour {
	public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
	public bool isAlive = true;
	public bool onAir;
	public bool isGrapping = false;
	private float direction;
	public bool isGrappable = false;
    private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;
	public int distance;
	public float dirAux;
//	int lastDir;
	
	void Start(){
		controller = GetComponent<CharacterController>();
		direction = 1;
		distance = 0;
//		lastDir=0;
	}
	
    void Update() {
		
		if (onAir){
			distance++;
		}
        if (controller.isGrounded) {
			if (distance > 90){
				// ACA MUERE POR LA CAIDA
				death();
			}
			onAir = false;
			distance = 0;
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
			dirAux = getPosition((int)moveDirection.x);
            if (Input.GetButton("Jump")){
				onAir = true;
				if (getPosition((int)moveDirection.x) >0){
					dirAux = 2;
				} else {
					//Debug.Log("SALTA MIRANDO A LA IZQUIERDA");
					//CHANTAR SPRITE MIRANDO A LA IZQUIERDA
					dirAux = -2;
				}
                moveDirection.y = jumpSpeed;
				//TODO Correr anim zacion de saltar
			}
        }else{
			if(Input.GetAxis("Horizontal")==0){
				
			}else{
				moveDirection = new Vector3(Input.GetAxis("Horizontal"),moveDirection.y,0);
				moveDirection = transform.TransformDirection(moveDirection);
            	moveDirection.x *= speed;
			}
		}
		if(Input.GetKey(KeyCode.Z)){
			// ACA PARAR ANIMACION (PARA QUE NO SE TOPEN)
			// Anim.play("grapple");
			if(isGrappable){
				dirAux = 5;
				isGrapping = true;
				moveDirection.Set(moveDirection.x,0,0);
				onAir = false;
				distance = 0;
				if(Input.GetButton ("Jump")){
					onAir = true;
					isGrapping = false;
					if (getPosition((int)moveDirection.x) >= 0){
						dirAux = 3;
					} else {
					//Debug.Log("SALTA MIRANDO A LA IZQUIERDA (DESDE LA PARED)");
					//CHANTAR SPRITE MIRANDO A LA IZQUIERDA
						dirAux = -3;
					}
					
					moveDirection.y = jumpSpeed;
					moveDirection.x = jumpSpeed*direction;
					//TODO correr animacion de salta pegado.
				}
			}
		}
		WalkAnim.setDir((int)dirAux);
		moveDirection.Set(moveDirection.x,moveDirection.y,0);
        if(isGrappable && Input.GetKey(KeyCode.Z)){}else{ moveDirection.y -= gravity * Time.deltaTime;}
        controller.Move(moveDirection * Time.deltaTime);
		//whereIsFacing(dirAux);
    }
	
	int getPosition(int num){
		if(num ==0) return 0;
		else return (int)Mathf.Sign (num);
	}
	
	
	// Check if the character can grapple onto a dirtWall
	
	void OnTriggerEnter(Collider target){
		if (target.transform.tag.Equals("dirtWall")) {
			isGrappable = true;
			direction = Mathf.Sign (moveDirection.x)*-1;
		}
		if (target.transform.tag.Equals("spikes")){
			Debug.Log("DEAD");
			isAlive = false;
		}
		if (target.transform.tag.Equals("killerObject")){
			target.transform.parent.rigidbody.velocity = new Vector3(0,-10,0);
			Debug.Log("Caigo");
		}
		
	}
	
	void OnTriggerExit(Collider target){
		if (target.transform.tag.Equals("dirtWall")) {
			isGrappable = false;
		}
	}
	
	void death(){
		//Anim.play("death");
		Debug.Log("MURIO");
	}
}

