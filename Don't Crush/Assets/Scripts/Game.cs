using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject _tutorialArrow;
    

    private void Start()
    {
        StartCoroutine(tutorial());
    }
    IEnumerator tutorial()
    {
        while (true)
        {
            _tutorialArrow.transform.DOLocalMoveX(162, 3, false);
            yield return new WaitForSeconds(2);
            _tutorialArrow.transform.DOLocalMoveX(-162, 3, false);
            yield return new WaitForSeconds(2);
        }
        

    }
}
