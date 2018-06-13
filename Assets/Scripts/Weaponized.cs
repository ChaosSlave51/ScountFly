using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponized : MonoBehaviour {
    [Header("Components")]
    public ParticleSystem Guns;

    private float _defaultGunsRateOverTime;
    // Use this for initialization
    void Start () {
        _defaultGunsRateOverTime = Guns.emission.rateOverTime.constant; 
        
        var em = Guns.emission;
        em.rateOverTime = 0;
    }

    public void Shoot(bool on)
    {
        if (on)
        {
            var em = Guns.emission;
            em.rateOverTime = _defaultGunsRateOverTime;
        }
        else
        {
            var em = Guns.emission;
            em.rateOverTime = 0;
        }
    }
}
