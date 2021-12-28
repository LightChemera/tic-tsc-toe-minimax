using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Hard : MonoBehaviour
{
    [SerializeField]
    private Sprite _ticSp;

    [SerializeField]
    private Sprite _tacSp;

    [SerializeField]
    private Text _winnerTxt;

    [SerializeField]
    private GameObject _panel;

    [SerializeField]
    private Button[] _ButtonArray = new Button[9];


    private char[] _gameBoard = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };


    private char _huPlayer = 'X';
    private char _aiPlayer = 'O';

    private string _whoMove = "tic";

    private bool _ticWin = false;
    private bool _tacWin = false;
    private bool _draw = false;

    private bool _endGame = false;
   
    public void Update()
    {
        if (winning(_gameBoard, _aiPlayer))
        {
            _tacWin = true;
            _endGame = true;
        }
        if (winning(_gameBoard, _huPlayer))
        {
            _ticWin = true;
            _endGame = true;
        }
        if (BoardIsFull())
        {
            _draw = true;
            _endGame = true;
        }

        if (_whoMove == "tac" && _endGame == false)
        {
            float bestScore = -Mathf.Infinity;
            int bestMove = 0;

            for (int i = 0; i < _gameBoard.Length; i++)
            {
                if (SpaceIsFree(i))
                {
                    _gameBoard[i] = _aiPlayer;
                    float score = Minimax(_gameBoard, 0, false);
                    _gameBoard[i] = ' ';
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = i;
                    }
                }
            }

            InsertLetter(_aiPlayer, bestMove);
            _whoMove = "tic";
        }


        PrintWinner();
    }
    public void TextureChange(Button _button)
    { 
        _button.GetComponent<Image>();

        if (_whoMove == "tic")
        {
            _button.image.sprite = _ticSp;
            _button.interactable = false;
            _whoMove = "tac";
        }
 
    }

    public void huMove(int index)
    {
        _gameBoard[index] = _huPlayer;
    }
    private void InsertLetter(char latter, int index)
    {
        Button _button = _ButtonArray[index];
        _button.GetComponent<Image>();
        _button.image.sprite = _tacSp;
        _button.interactable = false;

        _gameBoard[index] = latter;
    }

    private bool SpaceIsFree(int pos)
    {
        return _gameBoard[pos] == ' ';
    }

    private float Minimax(char[] board, int depth, bool isMaximizer)
    {
        if (winning(_gameBoard, _aiPlayer))
            return 1;
        if (winning(_gameBoard, _huPlayer))
            return -1;
        if (BoardIsFull())
            return 0;

        if (isMaximizer)
        {
            float bestScore = -Mathf.Infinity;
            for (int i = 0; i < board.Length; i++)
            {
                if (SpaceIsFree(i))
                {
                    board[i] = _aiPlayer;
                    float score = Minimax(board, depth + 1, false);
                    board[i] = ' ';
                    bestScore = Mathf.Max(score, bestScore);
                }
            }
            return bestScore;
        }
        else
        {
            float bestScore = Mathf.Infinity;
            for (int i = 0; i < board.Length; i++)
            {
                if (SpaceIsFree(i))
                {
                    board[i] = _huPlayer;
                    float score = Minimax(board, depth + 1, true);
                    board[i] = ' ';
                    bestScore = Mathf.Min(score, bestScore);
                }
            }
            return bestScore;
        }
    }
    private bool winning(char[] board, char letter)
    {
        return (board[0] == letter && board[1] == letter && board[2] == letter) ||            
                       (board[3] == letter && board[4] == letter && board[5] == letter) ||    
                       (board[6] == letter && board[7] == letter && board[8] == letter) ||    
                       (board[0] == letter && board[3] == letter && board[6] == letter) ||
                       (board[1] == letter && board[4] == letter && board[7] == letter) ||
                       (board[2] == letter && board[5] == letter && board[8] == letter) ||
                       (board[0] == letter && board[4] == letter && board[8] == letter) ||
                       (board[6] == letter && board[4] == letter && board[2] == letter);
    }
    private bool BoardIsFull()
    {
        foreach (char space in _gameBoard)
            if (space == ' ')
                return false;
        return true;
    }


    private void PrintWinner()
    {
        if (_ticWin)
        {
            _panel.SetActive(true);
            _winnerTxt.text = "Win!";
        } 
        else if(_tacWin)
        {
            _panel.SetActive(true);
            _winnerTxt.text = "Lose!";
        }
        else if(_draw)
        {
            _panel.SetActive(true);
            _winnerTxt.text = "Draw!";
        }
    }
}
