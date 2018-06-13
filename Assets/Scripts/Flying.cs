using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour {



    [Header("Settings")]
    public float StrafePower = 1000;
    public float TurnSpeed = 0.1f;

    [Header("Observables")]
    public float StafeVerticalForce;
    public float StafeHorizontalForce;
    public Quaternion DesiredAngle;
    
    Rigidbody _rigidBody;

    public ParticleSystem _guns;

    // Use this for initialization
    void Start () {
        _rigidBody = this.GetComponent<Rigidbody>();
     
      
        DesiredAngle = new Quaternion(0, 0, 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position+ new Vector3(StafeHorizontalForce, 0, StafeVerticalForce));
        StafeHorizontalForce = 0;
        StafeVerticalForce = 0;
        //if ( DesiredAngle.eulerAngles != Quaternion.identity.eulerAngles)
        //{
            _rigidBody.rotation = Quaternion.Slerp(_rigidBody.rotation, DesiredAngle, TurnSpeed * Time.fixedDeltaTime);
        //}
    }

 

    public void StrafeHorizontal(float power)
    {
        StafeHorizontalForce += StrafePower * Time.deltaTime*power;
    }
    public void StafeVertical(float power)
    {
        StafeVerticalForce += StrafePower * Time.deltaTime * power;
    }

    public void RotateTo(Vector2 newRotation)
    {
        float speed = 0.1F;
        var r = _rigidBody.rotation;
        var angle = Vector2.SignedAngle(Vector2.down, newRotation);

        DesiredAngle= Quaternion.Euler(0, angle, 0);
        // r =Mathf.InverseLerp(0,360, angle);
    }

}
