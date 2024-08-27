using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{   
	// Animation chem
	private PlayerControls plc;
	private Animator anm;
	private PlayerController pc;
	private ActiveWeapon aw;

	// Animation hieu ung chem
	private GameObject SlashAnim;
	public Transform SlashAnimSpawnPoint;
	public GameObject SlashAnimPrefab;
	
	// Pham vi tan cong
	public Transform weaponCollider;
	
	// Toc danh
	public float swordAttackCD = .5f;
	private bool attackButtonDown, isAttacking = false;
	private void Awake(){
		anm = GetComponent<Animator>();
		plc = new PlayerControls();

		pc = GetComponentInParent<PlayerController>();
		aw = GetComponentInParent<ActiveWeapon>();
	}

	private void OnEnable() {
		plc.Enable();
	}

	void Start(){
		plc.Combat.Attack.started += _ => StartAttacking();
		plc.Combat.Attack.canceled += _ => StopAttacking();

	}

	private void Update() {
		MouseFollowWithOffSet();
		Attack();
	}

	private void StartAttacking(){
		attackButtonDown = true;
	}

	private void StopAttacking(){
		attackButtonDown = false;
	}


	private void Attack(){
		if (attackButtonDown && !isAttacking){
			isAttacking = true;
			anm.SetTrigger("Attack");
			weaponCollider.gameObject.SetActive(true);
			SlashAnim = Instantiate(SlashAnimPrefab, SlashAnimSpawnPoint.position, Quaternion.identity);
			SlashAnim.transform.parent = this.transform.parent;
			StartCoroutine(AttackCDRoutine());			
		}
		
	}

	private IEnumerator AttackCDRoutine(){
		yield return new WaitForSeconds(swordAttackCD);
		isAttacking = false;
	}

	public void DoneaAttackAnimEvent(){
		weaponCollider.gameObject.SetActive(false);
	}

	public void SwingUpFlipAnimEvent() {
		SlashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0 ,0);

	if (pc.FacingLeft){
		SlashAnim.GetComponent<SpriteRenderer>().flipX = true;
	}
	}

	public void SwingDownFlipAnimEvent() {
		SlashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0 ,0);

	if (pc.FacingLeft){
		SlashAnim.GetComponent<SpriteRenderer>().flipX = true;
	}
	}



	private void MouseFollowWithOffSet() {
		Vector3 mPos = Input.mousePosition;
		Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(pc.transform.position);

		float angle = Mathf.Atan2(mPos.y, mPos.x) * Mathf.Rad2Deg;

		if(mPos.x < playerScreenPoint.x){
			aw.transform.rotation = Quaternion.Euler(0, -180, angle);
			weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);

		}
		else{
			aw.transform.rotation = Quaternion.Euler(0, 0, angle);
			weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);



		}
	}
}
