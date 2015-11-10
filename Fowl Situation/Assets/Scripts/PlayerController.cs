using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


	public GameObject player, target;
	public float moveSpeed = 10f;
	public Animator anim;
	//public int playerHealth = 100;
	public float playerHealth = 100f;
	public Slider healthBar;
	public Text healthLabel;

	private Vector3 targetPosition;
	private Vector3 movement;
	private Vector3 headingToTarget;
	private Vector3 attackVector;

	private bool attacking = false;
	private bool alive = true;

	private double attackStartTime;

	void Awake()
	{
		targetPosition = transform.position;
		//meleeWeaponBody = meleeWeapon.GetComponentInChildren<Rigidbody> ();
	}

	// Update is called once per frame
	void Update()
	{
		UpdateHealth ();
	}

	// FixedUpdate is called once per physics time step
	void FixedUpdate () {
		if (alive) {
			if (attacking)
				attack ();
			Move ();
		}
	}

	void Move()
	{
		float error = Vector3.Distance (targetPosition, transform.position);

		if (error > .2) {
			movement = (targetPosition - transform.position);
			//headingToTarget = movement.normalized;
			movement = movement.normalized * moveSpeed * Time.fixedDeltaTime;
			transform.position = (transform.position + movement);
		} else {
			movement = (targetPosition - transform.position);
			//headingToTarget = movement.normalized;
			movement = movement.normalized * moveSpeed * error * Time.fixedDeltaTime;
			transform.position = (transform.position + movement);
		}

		//update heading of character
		headingToTarget.y = 0f;
		Quaternion newHeading = Quaternion.LookRotation (headingToTarget);
		Rigidbody playerBody = player.GetComponent<Rigidbody>();
		playerBody.MoveRotation (newHeading);



		if (error > 1) {
			anim.SetBool ("Walking", true);
		
		} else {
			anim.SetBool ("Walking", false);
		
		}

	}

	public void UpdateTargetPosition(Vector3 i_targetPosition)
	{
		targetPosition = i_targetPosition;
		target.transform.position = i_targetPosition + new Vector3(0,.2f,0);

		headingToTarget = target.transform.position - transform.position;
	}

	public void StartAttack(Vector3 swipe)
	{
		headingToTarget = swipe;
		anim.SetTrigger ("Punch");


	}

	public void StartAreaAttack(){
		anim.SetTrigger ("Spin");
	}

	public void attack()
	{

	}

	public void takeDamage(float damage)
	{
		if (alive) {
			playerHealth -= damage;
			if (playerHealth == 0) {
				Die ();
			}
		}
	}

	public void UpdateHealth()
	{
		healthBar.value = playerHealth;
		healthLabel.text = playerHealth.ToString();
	}

	public void Die()
	{
		alive = false;
		anim.SetTrigger ("Die");
	}

}
