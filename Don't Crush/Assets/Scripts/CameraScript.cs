using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject _car;
    Vector3 _distance;
    Vector3 _distanceNow;
    public bool _check = false;
    void Start()
    {
        _distance = transform.position - _car.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_check == false)
        {
            cameraFollowing();
        }
        
    }
   private void cameraFollowing()
    {
        _distanceNow = transform.position - _car.transform.position;
        if (_distanceNow != _distance)
        {
            Vector3 _difference = _distance - _distanceNow;
            transform.position = Vector3.Lerp(transform.position, transform.position + _difference, 0.1f);
        }
    }
}
