using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    /// <summary>
    /// HealthBar <b>alpha-chanel / transparency</b> when player enters UI zone   
    /// </summary>
    private float _minAlphaValue = 0.2f;

    /// <summary>
    /// HealthBar <b>alpha-chanel / transparency</b> when player exits UI zone   
    /// </summary>
    private float _maxAlphaValue = 1f;

    private CanvasGroup _scoreBoardCanvasGroup;

    private void Awake()
    {
         _scoreBoardCanvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }
        _scoreBoardCanvasGroup.alpha = _minAlphaValue;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }
        _scoreBoardCanvasGroup.alpha = _maxAlphaValue;
    }
}
