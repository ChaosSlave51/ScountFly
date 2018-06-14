using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulnerable : MonoBehaviour, IStandardBehavior
{

    public float DamageBlinkRate = 2;
    public float MaxHealth = 100;
    public float Health=0;

    private Flying _ship;

    private const string DamageBlinkRateShaderField = "Vector1_3BE87725";

    private Material _material;


    private float _lastHit;
    // Use this for initialization

    private float _lastHitCooldown = .5f;

	void Start () {
        _material = GetComponent<Renderer>().material;
        Health = MaxHealth;

        _ship = GetComponent<Flying>();
    }
	
	// Update is called once per frame
	void Update () {
        if(_lastHit+ _lastHitCooldown < Time.time)
            _material.SetFloat(DamageBlinkRateShaderField, 0);
    }

    private void OnParticleCollision(GameObject other)
    {
        _lastHit = Time.time;
        _material.SetFloat(DamageBlinkRateShaderField, DamageBlinkRate);
        var bullet = other.GetComponent<Damaging>();
        Health -= bullet.Damage;

        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }

    }


    private void OnCollisionStay(Collision collision)
    {
        if (_lastHit + _lastHitCooldown < Time.time)
        {
            var damaging = collision.collider.GetComponent<Damaging>();
            if (damaging != null)
            {
                if (tag == "untagged" || tag != damaging.tag)
                {
                    _lastHit = Time.time;
                    _material.SetFloat(DamageBlinkRateShaderField, DamageBlinkRate);
                   
                    Health -= damaging.Damage;

                    if (Health <= 0)
                    {
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
