using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Dancer 
{
	public bool godMode;
	public float movementForce;
	public float maxSpeed;

	public int healthValue;
	public Text healthLabel;

	private bool isRotatingVertical;
	private bool isRotatingHorizontal;

	void Start () 
	{
		healthLabel.text = healthValue.ToString();

		// DANCER
		init();
	}
	
	void Update () 
	{
		handleMovement();
	}

	void handleMovement()
	{
		// TODO: Use iTween to change head of ship for movement

		if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
		{
			if (Input.GetAxisRaw("Horizontal") > 0)
			{
				GetComponent<Rigidbody>().AddForce(Vector3.right * movementForce);
			}

			if (Input.GetAxisRaw("Horizontal") < 0)
			{
				GetComponent<Rigidbody>().AddForce(-Vector3.right * movementForce);
			}

			if (Input.GetAxisRaw("Vertical") > 0)
			{
				GetComponent<Rigidbody>().AddForce(Vector3.up * movementForce);
			}

			if (Input.GetAxisRaw("Vertical") < 0)
			{
				GetComponent<Rigidbody>().AddForce(-Vector3.up * movementForce);
			}
		}
	}

	public void setColor(Color inputColor)
	{
		GetComponent<OtherWireframe>().lineColor = inputColor;
	}


	// DANCE
	public override void dance (bool results)
	{


		if (results)
		{
			GetComponent<OtherWireframe>().lineWidth = 15;
			GetComponent<BlendColors>().enabled = false;
			GetComponent<OtherWireframe>().lineColor = Color.green;
		}
		else
		{
			GetComponent<OtherWireframe>().lineWidth = 1;
			GetComponent<BlendColors>().enabled = true;
		}
	} 


	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Blockade") || other.CompareTag("Enemy"))
		{
			healthValue--;
			healthLabel.text = healthValue.ToString();

			if (healthValue <= 0 && !godMode)
			{
				// Restart level when health reaches 0
				Application.LoadLevel(Application.loadedLevelName);
			}
		}
	}
}
