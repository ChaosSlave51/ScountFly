using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDriver : MonoBehaviour, IStandardBehavior
{
    private Flying _flying;
    private Weaponized _weaponized;
    // Use this for initialization
    void Start()
    {
        _flying = GetComponent<Flying>();
        _weaponized = GetComponent<Weaponized>();
    }

    // Update is called once per frame
    private void Update()
    {

        _flying.StrafeHorizontal(Input.GetAxis("Horizontal"));        
        _flying.StafeVertical(Input.GetAxis("Vertical"));

        if (Input.GetAxis("LookH") != 0 || Input.GetAxis("LookV") != 0)
        {
            var newRotation = new Vector2(Input.GetAxis("LookH"), Input.GetAxis("LookV"));
            _flying.RotateTo(newRotation);
            _weaponized.Shoot(true);
        }
        else
        {
            _weaponized.Shoot(false);
        }

    }
}
