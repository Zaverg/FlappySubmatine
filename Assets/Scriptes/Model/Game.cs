using System;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private PlayerSubmarine _player;
    [SerializeField] private GameOverMenu _overMenu;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameMenu _gameMenu;
    [SerializeField] private ObjectPullEnemy _enemyPull;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private ObjectPullTorpedos _torpedosPull;
    [SerializeField] private HealView _healView;
    [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private List<EndlessMover> _backGrounds;
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private SecondsLive _secondsLive;

    private Health _playerHealth;
    private PlayerMover _playerMover;

    public void Reset()
    {
        _enemyPull.Reset();
        _torpedosPull.Reset();
        _playerHealth.Reset();
        _healView.Reset();
        _playerMover.Reset();
        _score.Reset();
        _secondsLive.Reset();

        foreach (EndlessMover background in _backGrounds)
        {
            background.Reset();
        }

        Time.timeScale = 1.0f;
    }

    private void Awake()
    {
        _playerHealth = _player.GetComponent<Health>();
        _playerMover = _player.GetComponent<PlayerMover>();
    }

    private void Start()
    {
        _playerMover.OnMove(false);
        _secondsLive.StartSeconds(false);
    }

    private void OnEnable()
    {
        _gameOverMenu.Restarted += Reset;
        _mainMenu.StartGame += StartGame;
        _playerHealth.GameOver += LoseGame;
    }

    private void OnDisable()
    {
        _gameOverMenu.Restarted -= Reset;
        _mainMenu.StartGame -= StartGame;
        _playerHealth.GameOver -= LoseGame;
    }

    private void LoseGame()
    {
        _overMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void StartGame()
    {
        _playerMover.OnMove(true);
        _enemySpawner.StartSpawn();
        _mainMenu.gameObject.SetActive(false);
        _gameMenu.gameObject.SetActive(true);
        _secondsLive.StartSeconds(true);
    }
}
