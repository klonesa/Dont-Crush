using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UISystems;

public class Car : MonoBehaviour
{ private Touch _touch;
    #region TextMeshPros
    public TMP_Text _redNumTextMesh;
    public TMP_Text _redNumMustText;//198,121,121,255
    public TMP_Text _blueNumTextMesh;
    public TMP_Text _blueNumMustText;
    [SerializeField] TMP_Text _diamondText;//136,30,157,255
    #endregion
    #region ints
    public int _redNum = 0;
    public int _redNumMust;
    public int _blueNum = 0;
    public int _blueNumMust;
    public int _diamondNum;
    #endregion
    #region Rigidbody
    Rigidbody _carRigid;
    #endregion
    #region floats
    [SerializeField] float _timeRotation;
    public float _speedModifier;
    [SerializeField] float _cameraMovementDistance;
    #endregion  
    #region bools
    public bool _isTouched = false;
    #endregion
    #region GameObjects
    [SerializeField] GameObject _startTutorial;
    [SerializeField] GameObject _redNumObject;
    [SerializeField] GameObject _blueNumObject;
    [SerializeField] GameObject _camera;
    [SerializeField] GameObject _checkMark;
    [SerializeField] GameObject _checkMark1;
    [SerializeField] GameObject _congratsScreen;
    [SerializeField] GameObject _loseScreen;
    [SerializeField] GameObject _redNumMustObject;  
    [SerializeField] GameObject _tapToStart;
    #endregion
    #region ParticleSystems
    [SerializeField] ParticleSystem _finishingParticleWin;
    [SerializeField] ParticleSystem _diamondCollectParticle;
    #endregion
    public CameraScript _cameraScript;
    public MainMenuPanelController _main;
    void Start()
    {
        Time.timeScale = 1;
        _diamondText.color = Color.black;//new Color32(136, 40, 157, 255);
        _carRigid = GetComponent<Rigidbody>();
        _redNumTextMesh.faceColor = Color.red;
        _redNumMustText.faceColor = new Color32(198, 121, 121, 255);
        _redNumMustText.text = " = " + _redNumMust.ToString();
        _blueNumMustText.text = " = " + _blueNumMust.ToString();
        _blueNumTextMesh.faceColor = Color.blue;
        _blueNumMustText.faceColor = new Color32(100,129,217,255);
    }
    void FixedUpdate()
    {
        if (_main.startButton)
        {
            _diamondText.text = _diamondNum.ToString();
            carMovement();
            isTouched();
            _redNumTextMesh.text = _redNum.ToString();
            _blueNumTextMesh.text = _blueNum.ToString();
        }
       
    }

    private void carMovement()
    {       
        if(Input.touchCount > 0)
        {
            _carRigid.velocity = new Vector3(0, 0, _speedModifier*2.2f * Time.deltaTime * 1000);
            //bu ilk seviyelerden sonra işleyecek
            _isTouched = true;
            _startTutorial.SetActive(false);
            _tapToStart.SetActive(false);
            _touch = Input.GetTouch(0);

            if(_touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + _touch.deltaPosition.x * _speedModifier*Time.deltaTime,
                    transform.position.y,
                    transform.position.z);
                StartCoroutine(carRotation());
            }
        }
        else
        {
            _carRigid.velocity = new Vector3(0, 0, 0);
        }

    } 
    IEnumerator carRotation()
    {
        if (_touch.deltaPosition.x < 0)
        {
            _carRigid.DORotate(new Vector3(0, -110, 0), _timeRotation, RotateMode.Fast);
            _carRigid.DORotate(new Vector3(0, -90, 0), _timeRotation, RotateMode.Fast);
        }
        else if (_touch.deltaPosition.x > 0)
        {
            _carRigid.DORotate(new Vector3(0, -70, 0), _timeRotation, RotateMode.Fast);
            _carRigid.DORotate(new Vector3(0, -90, 0), _timeRotation, RotateMode.Fast);
        }
        yield return null;
    }

    IEnumerator finishing()
    {
        Time.timeScale = 0.3f;
        Debug.Log("Sorry :(");
        yield return new WaitForSeconds(1);
        _speedModifier = 0;
        yield return null;
        
    }
    IEnumerator checkFinishing()
    {
        Debug.Log("çalıştı");
        _finishingParticleWin.Play();
        yield return new WaitForSeconds(0.2f);
        _congratsScreen.SetActive(true);
        _checkMark.SetActive(true);
        _checkMark1.SetActive(true);
        _checkMark.transform.DOShakeScale(1, 1, 10, 90, true);
        _checkMark1.transform.DOShakeScale(1, 1, 10, 90, true);
        _checkMark.transform.localScale= new Vector3(1, 1, 1);
        _checkMark1.transform.localScale= new Vector3(1, 1, 1);
        //yield return new WaitForSeconds(0.1f);
        
        yield return null;
    }
    IEnumerator loseFinishing()
    {
        _camera.transform.DOMove(new Vector3(10, 8, _cameraMovementDistance), 0.5f, false);
        _camera.transform.DORotate(new Vector3(8.5f, -143.02f, 0), 0.5f);
        yield return new WaitForSeconds(0.2f);
        _loseScreen.SetActive(true);
        _redNumMustObject.transform.DOScale(new Vector3(3, 3, 3), 0.1f);
        yield return new WaitForSeconds(0.1f);
        _redNumMustObject.transform.DOScale(new Vector3(1, 1, 1), 0.1f);
        yield return null;
    }
    void  isTouched()
    {
        if (_isTouched)
        {
             _carRigid.velocity = new Vector3(0, 0, 2 * Time.deltaTime * 1000);  
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Red Wall")
        {
            Debug.Log("Red Gone!!!");
            _redNum--;
            _redNumObject.transform.DOShakeScale(1, 0.5f, 10, 90, true);
        }
        if(other.gameObject.tag == "Blue Wall")
        {
            Debug.Log("Blue Gone!!");
            _blueNum--;
            _blueNumObject.transform.DOShakeScale(1, 0.5f, 10, 90, true);            
        }
        //FINISH LINE
        //!!!!!!!!!!!!!!!!!!EKLENECEKLER VAR!!!!!!!!!!!!!!!!!!!!!!
        if(other.gameObject.tag == "Finish Line")
        {
            if((_redNum == _redNumMust)&&(_blueNum == _blueNumMust))
            {
                _cameraScript._check = true;
                //Burada timescale önce 0.3 olsun sonra 0 olsun!!!!!!
                StartCoroutine(finishing());
                _camera.transform.DOMove(new Vector3(10, 8, _cameraMovementDistance), 0.5f, false);
                _camera.transform.DORotate(new Vector3(8.5f, -143.02f, 0), 0.5f);
                StartCoroutine(checkFinishing());
                Debug.Log("Congratulations!!!");
            }
            else
            {
                _cameraScript._check = true;
                StartCoroutine(finishing());
                StartCoroutine(loseFinishing());
            }
            
        }
        //DIAMOND
        if(other.gameObject.tag == "Diamond")
        {
            
            _diamondCollectParticle.Play();
            _diamondNum++;
            _diamondText.text = _diamondNum.ToString();
            Destroy(other.gameObject);
            
        }
    }


}
