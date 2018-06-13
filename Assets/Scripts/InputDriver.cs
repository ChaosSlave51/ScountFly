using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDriver : MonoBehaviour {
    private Ship _ship;
    // Use this for initialization
    void Start()
    {
        _ship = GetComponent<Ship>();
    }

    // Update is called once per frame
    private void Update()
    {

        _ship.StrafeHorizontal(Input.GetAxis("Horizontal"));        
        _ship.StafeVertical(Input.GetAxis("Vertical"));

        if (Input.GetAxis("LookH") != 0 || Input.GetAxis("LookV") != 0)
        {
            var newRotation = new Vector2(Input.GetAxis("LookH"),  Input.GetAxis("LookV"));
            _ship.RotateTo(newRotation);
        }

    }
}
