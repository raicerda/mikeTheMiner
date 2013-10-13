using UnityEngine;
using System.Collections;

public class WalkController : MonoBehaviour {
	public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
	public bool isAlive = true;
	public bool onAir;
	private float direction;
	public bool isGrappable = false;
    private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;
	public int distance;
	int lastDir;
	
	void Start(){
		controller = GetComponent<CharacterController>();
		direction = 1;
		distance = 0;
		lastDir=0;
	}
	
    void Update() {
		
		float dirAux = getPosition((int)moveDirection.x);
		if (onAir){ distance++;}
        if (controller.isGrounded) {
			if (distance > 60) Debug.Log("DEAD BY FALL");
			onAir = false;
			distance = 0;
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump")){
				onAir = true;
                moveDirection.y = jumpSpeed;
				//TODO Correr animacion de saltar
				dirAux = 2;
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
			if(isGrappable){
				moveDirection.Set(moveDirection.x,0,0);
				onAir = false;
				distance = 0;
				if(Input.GetButton ("Jump")){
					onAir = true;
					moveDirection.y = jumpSpeed;
					moveDirection.x = jumpSpeed*direction;
					dirAux = 3;
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
	
}

