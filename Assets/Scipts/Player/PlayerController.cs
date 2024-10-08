using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : SingleTon<PlayerController>
{
   [SerializeField] private float moveSpeed = 1f;
   [SerializeField] private float dashSpeed = 4f;
   [SerializeField] private TrailRenderer myTrailRenderer;

   private PlayerControls playerControls;
   private Vector2 movement;
   private Rigidbody2D rb;
   private Animator myAnimator;
   private SpriteRenderer mySpriteRender;
   private float startingMoveSpeed;

   private AudioManager adm;

   public bool FacingLeft {get {return facingLeft; } }
   private bool facingLeft = false;

   private bool isDashing = false;

   protected override void Awake(){
	base.Awake();

	playerControls = new PlayerControls();
	rb = GetComponent<Rigidbody2D>();

	myAnimator = GetComponent<Animator>();
	mySpriteRender = GetComponent<SpriteRenderer>();
    adm = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

   private void Start() {
   	playerControls.Combat.Dash.performed +=_=> Dash();
	startingMoveSpeed = moveSpeed;
   }

   private void OnEnable(){
        playerControls.Enable();
   }

   private void Update(){
		PlayerInput();
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
		{
			adm.PlayerSFX(adm.grassWalk);
		}
    }

   private void FixedUpdate(){
	AdjustPlayerFacingDirection();
        Move();
   }

   private void PlayerInput(){
	movement = playerControls.Movement.Move.ReadValue<Vector2>();

	myAnimator.SetFloat("MoveX", movement.x);
	myAnimator.SetFloat("MoveY", movement.y);
    }

   private void Move(){
   	rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

   private void AdjustPlayerFacingDirection(){
   	Vector3 mousePos = Input.mousePosition;
	Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
	
	if (mousePos.x < playerScreenPoint.x) {
		mySpriteRender.flipX = true;
		facingLeft = true;
	}
	else {
		mySpriteRender.flipX = false;
		facingLeft = false;
	}
   }
   private void Dash(){
	if(!isDashing){
		isDashing = true;
		moveSpeed += dashSpeed;
		myTrailRenderer.emitting = true;
		StartCoroutine(EndDashRoutine());
	}
   }

   private IEnumerator EndDashRoutine(){
	float dashTime = .2f;
	float dashCD = .25f;
	yield return new WaitForSeconds(dashTime);
	moveSpeed = startingMoveSpeed;
	myTrailRenderer.emitting = false;
	yield return new WaitForSeconds(dashCD);
	isDashing = false;
   }
}
