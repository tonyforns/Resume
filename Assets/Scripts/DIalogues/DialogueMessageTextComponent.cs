using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class DialogueMessageTextComponent : MonoBehaviour
{
    private const float SHOWING_TIME = 0.05f;

    [SerializeField] private TextMeshProUGUI _messageText;
    private string _message;

    private Coroutine _ShowCoroutine; 
    private float _timer;


    internal void Complete()
    {
        StopCoroutine(_ShowCoroutine);
        _messageText.text = _message;
    }

    internal bool IsShowingMessage()
    {
        return _message != _messageText.text;
    }

    internal void Show(string message)
    {
        _messageText.text = "";
        _message = message;
        _ShowCoroutine = StartCoroutine(ShowCoroutine());
    }

    private IEnumerator ShowCoroutine()
    {
        _timer = SHOWING_TIME;

        foreach (char c in _message)
        {
            while (_timer > 0)
            {
                yield return 0;
                _timer -= Time.deltaTime;
            }
            _messageText.text += c;
            _timer = SHOWING_TIME;
        }
    }
}
