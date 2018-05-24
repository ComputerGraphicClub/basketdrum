using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{

	private float InitialTouchTime;
	private float FinalTouchTime;
	private Vector2 InitialTouchPosition;
	private Vector2 FinalTouchPosition;

	private float XaxisForce;
	private float YaxisForce;
	private float ZaxisForce;

	private Vector3 RequireForce;
	public Rigidbody ball;

	Vector3 initialBallPosition;

	void Start ()
	{
		initialBallPosition = ball.transform.localPosition;


	}


	// Use this for initialization
	public void onTouchDown ()
	{

		Debug.Log ("TouchDown");

		InitialTouchTime = Time.time;
		InitialTouchPosition = Input.mousePosition;

		// ramène et bloque la balle devant le joueur
		ball.isKinematic = true;
		ball.transform.localPosition = initialBallPosition;

	}

	public void onTouchUp ()
	{
		Debug.Log ("TouchUp");
		FinalTouchTime = Time.time;
		FinalTouchPosition = Input.mousePosition;
		ballThrow ();

	}

	private void ballThrow ()
	{
		ball.isKinematic = false;
		XaxisForce = FinalTouchPosition.x - InitialTouchPosition.x;
		YaxisForce = FinalTouchPosition.y - InitialTouchPosition.y;
		//ZaxisForce = FinalTouchTime - InitialTouchTime;
		ZaxisForce = 1;
		RequireForce = new Vector3 (XaxisForce * 0.1f, YaxisForce * 0.1f, ZaxisForce * 5); 
		ball.useGravity = true;
		ball.velocity = RequireForce;
	}


}
