using UnityEngine;
using System.Collections;

public class CameraController  {

	public float CameraRotateSpeedRight = 3.0f;
	public float CameraRotateSpeedLeft = 1.0f;
	public float CameraZoomSpeed = 3.0f;
	public float CameraRadius = 6.0f;
	public float CameraTheta;
	public float CameraPhi;

	public bool IsPlayerStill;

	float PIOneTwo = 1.5707963f;
	float PIOneFour = 0.7853981f;
	float PIFiveSix = 2.6179938f;
	float PIThreeTwo = 4.7123890f;
	float PINineteenTwenty = 2.98451302f;

	public void Initialize(){
		CameraTheta = PIThreeTwo;
		CameraPhi = PIFiveSix;
	}

	public Vector3 UpdateCameraPosition(float horizontal, float vertical, float cameraRotation, float cameraZoom, Vector3 Target){
		Vector3 CameraPosition = new Vector3();

		//Check input to determine if player or camera is moving
		if (horizontal != 0 || vertical != 0) {
			IsPlayerStill = false;		//If input is found, player is moving
		} 
		else {
			IsPlayerStill = true;
		}

		CameraTheta += cameraRotation * CameraRotateSpeedRight * Time.deltaTime;
		CameraPhi += cameraZoom * CameraZoomSpeed * Time.deltaTime; 

		//Set Theta						
		CameraTheta -= horizontal * CameraRotateSpeedLeft * Time.deltaTime;

		if(CameraTheta > 2*Mathf.PI){
			CameraTheta = 0.0f;
		}
		if(CameraTheta < 0.0f){
			CameraTheta = 2*Mathf.PI;
		}
		if(CameraPhi > PINineteenTwenty){
			CameraPhi = PINineteenTwenty;		//Bottom
		}
		if(CameraPhi < PIOneTwo){	
			CameraPhi = PIOneTwo;				//Top
		}

		//Move Camera
		CameraPosition.x = Target.x + CameraRadius * Mathf.Sin(CameraPhi) * Mathf.Cos(CameraTheta);
		CameraPosition.y = Target.y + CameraRadius * Mathf.Cos (CameraPhi) + CameraRadius;
		CameraPosition.z = Target.z + CameraRadius * Mathf.Sin(CameraPhi) * Mathf.Sin(CameraTheta);

		return CameraPosition;
	}

	public Vector3 UpdateTargetPosition(Transform Camera, Vector3 TargetForward, float horizontal, float vertical){
		Vector3 NewForward = new Vector3 ();

		Vector3 CForward = Camera.transform.forward.normalized;
		CForward.y = 0.0f;
		Vector3 CRight = Camera.transform.right.normalized;
		CRight.y = 0.0f;

		NewForward = TargetForward.normalized + (CForward * vertical) + (CRight * horizontal);

		return NewForward;
	}
}
