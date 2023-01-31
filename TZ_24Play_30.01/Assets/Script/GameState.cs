using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] private Canvas _startGameCanvas;
    [SerializeField] private Canvas _endGameCanvas;
    private PlayerMover _playerMover;

    private void Awake()
    {
        _playerMover = FindObjectOfType<PlayerMover>();
        _playerMover.enabled = false;
        _endGameCanvas.enabled = false;
        _startGameCanvas.enabled= true;
    }

    public void StartMove()
    {
        _playerMover.enabled = true;
        _startGameCanvas.enabled = false;
    }

    public void EndGame()
    {
        _endGameCanvas.enabled = true;
        _playerMover.enabled = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
