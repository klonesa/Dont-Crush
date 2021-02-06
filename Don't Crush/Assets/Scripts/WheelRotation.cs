using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    [SerializeField] GameObject _wheel1, _wheel2, _wheel3, _wheel4;

    void Update()
    {
        _wheel1.transform.Rotate(new Vector3(1000 * Time.deltaTime, 0, 0));
        _wheel2.transform.Rotate(new Vector3(1000 * Time.deltaTime, 0, 0));
        _wheel3.transform.Rotate(new Vector3(1000 * Time.deltaTime, 0, 0));
        _wheel4.transform.Rotate(new Vector3(1000 * Time.deltaTime, 0, 0));
    }
}
