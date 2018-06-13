using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulnerable : MonoBehaviour {

    public float DamageBlinkRate = 2;
    public float MaxHealth = 100;
    public float Health=0;

    public Flying _ship;

    private const string DamageBlinkRateShaderField = "Vector1_3BE87725";

    private Material _material;


    private float _lastHit;
	// Use this for initialization
	void Start () {
        _material = GetComponent<Renderer>().material;
        Health = MaxHealth;

        _ship = GetComponent<Flying>();
    }
	
	// Update is called once per frame
	void Update () {
        if(_lastHit+0.1<Time.time)
            _material.SetFloat(DamageBlinkRateShaderField, 0);
    }

    private void OnParticleCollision(GameObject other)
    {
        _lastHit = Time.time;
        _material.SetFloat(DamageBlinkRateShaderField, DamageBlinkRate);
        var bullet = other.GetComponent<Bullet>();
        Health -= bullet.Damage;

        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }

    }
}
