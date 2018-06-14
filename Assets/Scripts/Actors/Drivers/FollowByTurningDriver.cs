using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowByTurningDriver : MonoBehaviour {

    private IMoving _moving;
    public LevelController _levelController;
    public Transform TargetTransfom;



    // Use this for initialization
    void Start()
    {
        _moving = GetComponent<Flying>();
        

        if (TargetTransfom == null)
        {
            _levelController = FindObjectOfType<LevelController>();
            TargetTransfom = _levelController.Player.transform;
        }

    }

    // Update is called once per frame
    void Update () {
        Vector3 targetDir = (TargetTransfom.position - transform.position);
        //float angle = Vector3.Angle(targetDir, transform.forward);

        _moving.RotateTo(new Vector2(targetDir.x, -targetDir.z));
        _moving.Forward(1);

    }
}
