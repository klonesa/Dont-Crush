using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class People : MonoBehaviour
{
    [SerializeField] ParticleSystem _collectParticle;
    Rigidbody _peopleRigid;
    [SerializeField] int _speedPeople;
    public Car _car;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _peopleRigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_car._isTouched)
        {
            peopleRun();
        }
            
        
    }

    void peopleRun()
    {
        _peopleRigid.velocity = new Vector3(0, 0, _speedPeople * Time.deltaTime);

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pointcollider")
        {

            if(gameObject.tag == "Red Person")
            {
                _collectParticle.startColor = Color.red;
                
                

                _car._redNum++;
            }
            else if (gameObject.tag == "Blue Person")
            {
                _collectParticle.startColor = Color.blue;
                _car._blueNum++;
            }
            else if (gameObject.tag == "Green Person")
            {
                _collectParticle.startColor = Color.green;
            }
            else if (gameObject.tag == "Yellow Person")
            {
                _collectParticle.startColor = Color.yellow;
            }
            _collectParticle.Play();
            Destroy(gameObject);
            
            
            Debug.Log("Rewarded!!!");
        }
    }
}
