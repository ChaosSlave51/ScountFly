using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour, IMoving, IStandardBehavior
{



    [Header("Settings")]
    public float MoveSpeed = 1000;
    public float TurnSpeed = 0.1f;

    [Header("Observables")]
    public float StafeVerticalForce;
    public float StafeHorizontalForce;
    public float ForwardForce;
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
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;

        _rigidBody.MovePosition(_rigidBody.position+ new Vector3(StafeHorizontalForce, 0, StafeVerticalForce));

        _rigidBody.MovePosition(_rigidBody.position + transform.forward * ForwardForce);


        _rigidBody.rotation = Quaternion.Slerp(_rigidBody.rotation, DesiredAngle, TurnSpeed * Time.fixedDeltaTime);

        StafeHorizontalForce = 0;
        StafeVerticalForce = 0;
        ForwardForce = 0;

       

    }

 

    public void StrafeHorizontal(float power)
    {
        StafeHorizontalForce += MoveSpeed * Time.deltaTime*power;
    }
    public void StafeVertical(float power)
    {
        StafeVerticalForce += MoveSpeed * Time.deltaTime * power;
    }

    public void RotateTo(Vector2 newRotation)
    {

        var angle = Vector2.SignedAngle(Vector2.down, newRotation);

        DesiredAngle= Quaternion.Euler(0, angle, 0);
        // r =Mathf.InverseLerp(0,360, angle);
    }

    public void Forward(float power)
    {
        ForwardForce += MoveSpeed * Time.deltaTime * power;
    }
}
