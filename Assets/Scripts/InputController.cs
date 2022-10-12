using System;
using System.Collections;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Touch _touch;
    [SerializeField]private float moveSpeed = 0.007f;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject ball;
    private float _throwForce;
    private float _touchRadius = 2.5f;
    private Vector3 _playerStartPosition;
    [SerializeField] private Rigidbody ballRb;

    private void Start()
    {
        _playerStartPosition = transform.position;
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;
        if (Input.touchCount >= 1)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Moved)
            {
                StartCoroutine(nameof(DrawArrow));
                if (Vector3.Distance(_playerStartPosition, transform.position) > _touchRadius)
                {
                    transform.position = _playerStartPosition + (transform.position - _playerStartPosition).normalized * _touchRadius;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x + _touch.deltaPosition.x * moveSpeed,
                        transform.position.y, transform.position.z + _touch.deltaPosition.y * moveSpeed);
                }
                transform.LookAt(_playerStartPosition);
            }

            if (_touch.phase is TouchPhase.Ended or TouchPhase.Canceled)
            {
                ThrowBall();
                transform.position = _playerStartPosition;
                transform.rotation = Quaternion.identity;
                arrow.SetActive(false);
            }
        }
    }
    
    private void ThrowBall()
    {
        var direction = transform.position - ball.transform.position;
        direction = direction.normalized;
        ballRb.AddForce(direction*_throwForce, ForceMode.Impulse);
    }
    private IEnumerator DrawArrow()
    {
        arrow.SetActive(true);
        var localScale = arrow.transform.localScale;
        while (_touch.phase == TouchPhase.Moved)
        {
            yield return new WaitForSeconds(0.1f);
            var distance = Vector3.Distance(transform.position, _playerStartPosition);
            localScale.x = distance * 0.25f;
            localScale.y = distance * 0.25f;
            _throwForce = distance * 6f;
            arrow.transform.localScale = localScale;
        }
    }
}