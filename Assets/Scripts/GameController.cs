using System;
using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject targetParent;
    [SerializeField] private GameObject target;
    private EnemyController _enemyController;
    private int _targetsCount;
    public int currentLevel = 1;
    private Vector3[] _targetPositions = new Vector3[3];
    private bool _gameIsActive = true;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void Start()
    {
        _enemyController = FindObjectOfType<EnemyController>();
        for (var i = 0; i < 3; i++)
        {
            _targetPositions[i] = targetParent.transform.GetChild(i).transform.position;
        }
    }

    private void Update()
    {
        _targetsCount = targetParent.transform.hierarchyCount;
        if (_targetsCount == 1 && _gameIsActive)
        {
            _gameIsActive = false;
            StartCoroutine("NextLevel");
        }
    }
    
    private IEnumerator NextLevel()
    {
        currentLevel++;
        yield return new WaitForSeconds(0.25f);
        _enemyController.Speed += 0.5f;
        for (var i = 0; i < 3; i++)
        {
            Instantiate(target, _targetPositions[i], Quaternion.identity, targetParent.transform);
        }
        _gameIsActive = true;
    }
}
