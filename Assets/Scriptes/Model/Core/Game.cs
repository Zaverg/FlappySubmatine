using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private PlayerSubmarine _player;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameMenu _gameMenu;
    [SerializeField] private ObjectPullEnemy _enemyPull;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private ObjectPullTorpedoes _torpedoesPull;
    [SerializeField] private HealthView _healView;
    [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private List<EndlessMover> _backGrounds;
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private SurvivalTime _secondsLive;

    private Health _playerHealth;
    private PlayerMover _playerMover;
    private PlayerAttacker _playerAttacker;

    public void Reset()
    {
        _player.gameObject.SetActive(true);
        _enemyPull.Reset();
        _torpedoesPull.Reset();
        _playerHealth.Reset();
        _healView.Reset();
        _playerMover.Reset();
        _score.Reset();
        _secondsLive.Reset();
        _playerAttacker.Reset();

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
        _playerAttacker = _player.GetComponent<PlayerAttacker>();
    }

    private void Start()
    {
        _playerMover.OnMove(false);
        _playerAttacker.OnAttack(false);
        _secondsLive.SetTimerActive(false);
        _player.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _gameOverMenu.Restarted += Reset;
        _mainMenu.StartGame += StartGame;
        _playerHealth.Over += LoseGame;
    }

    private void OnDisable()
    {
        _gameOverMenu.Restarted -= Reset;
        _mainMenu.StartGame -= StartGame;
        _playerHealth.Over -= LoseGame;
    }

    private void LoseGame()
    {
        _gameOverMenu.gameObject.SetActive(true);
        _player.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    private void StartGame()
    {
        _player.gameObject.SetActive(true);
        _playerMover.OnMove(true);
        _playerAttacker.OnAttack(true);
        _enemySpawner.StartSpawn();
        _mainMenu.gameObject.SetActive(false);
        _gameMenu.gameObject.SetActive(true);
        _secondsLive.SetTimerActive(true);
    }
}
