using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandle : MonoBehaviour
{
    private Stack _stack;
    private GameState _gameState;

    private void Start()
    {
        _gameState = FindObjectOfType<GameState>();
        _stack = FindObjectOfType<Stack>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Platform>() && _stack.GetBlockCount() == 0 )
        {
            _gameState.EndGame();
        }
        else if (collision.gameObject.GetComponent<StopCube>() && _stack.GetBlockCount() == 0)
        {
            _gameState.EndGame();
        }
    }

}
