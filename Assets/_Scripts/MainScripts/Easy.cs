using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Easy : MonoBehaviour
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


    private int[] _gameBoard = {0, 0, 0,
                                0, 0, 0,
                                0, 0, 0};


    private int _fullArray = 0;

    private string _whoMove = "tic";

    private bool _ticWin;
    private bool _tacWin;
    private bool _draw;
    private bool _endGame = false;
   
    public void Update()
    {
        if (_whoMove == "tac" && _endGame == false)
        {
            var rand = new System.Random();
            int index = rand.Next(9);

            if (_gameBoard[index] == 0)
            {
                var _button = _ButtonArray[index];
                _button.image.sprite = _tacSp;
                _button.interactable = false;

                _gameBoard[index] = 2;
                _fullArray++;
                WhoWin();

                _whoMove = "tic";
            }
        }
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

    public void ArrayInput(int index)
    {
        _gameBoard[index] = 1;
        _fullArray++;    
        WhoWin();
    }

    private void WhoWin()
    {
        //if tic win
        if(_gameBoard[0] == 1 & _gameBoard[3] == 1 & _gameBoard[6] == 1) 
        {
            _endGame = true;
            _ticWin = true;                               
        }
        else if(_gameBoard[1] == 1 & _gameBoard[4] == 1 & _gameBoard[7] == 1)
        {
            _endGame = true;
            _ticWin = true;
        }
        else if (_gameBoard[2] == 1 & _gameBoard[5] == 1 & _gameBoard[8] == 1)
        {
            _endGame = true;
            _ticWin = true;
        }

        else if (_gameBoard[0] == 1 & _gameBoard[1] == 1 & _gameBoard[2] == 1)
        {
            _endGame = true;
            _ticWin = true;
        }
        else if (_gameBoard[3] == 1 & _gameBoard[4] == 1 & _gameBoard[5] == 1)
        {
            _endGame = true;
            _ticWin = true;
        }
        else if (_gameBoard[6] == 1 & _gameBoard[7] == 1 & _gameBoard[8] == 1)
        {
            _endGame = true;
            _ticWin = true;
        }

        else if (_gameBoard[0] == 1 & _gameBoard[4] == 1 & _gameBoard[8] == 1)
        {
            _endGame = true;
            _ticWin = true;
        }
        else if (_gameBoard[2] == 1 & _gameBoard[4] == 1 & _gameBoard[6] == 1)
        {
            _endGame = true;
            _ticWin = true;
        }
        //if tac win
        if (_gameBoard[0] == 2 & _gameBoard[3] == 2 & _gameBoard[6] == 2)
        {
            _endGame = true;
            _tacWin = true;
        }
        else if (_gameBoard[1] == 2 & _gameBoard[4] == 2 & _gameBoard[7] == 2)
        {
            _endGame = true;
            _tacWin = true;
        }
        else if (_gameBoard[2] == 2 & _gameBoard[5] == 2 & _gameBoard[8] == 2)
        {
            _endGame = true;
            _tacWin = true;
        }

        else if (_gameBoard[0] == 2 & _gameBoard[1] == 2 & _gameBoard[2] == 2)
        {
            _endGame = true;
            _tacWin = true;
        }
        else if (_gameBoard[3] == 2 & _gameBoard[4] == 2 & _gameBoard[5] == 2)
        {
            _endGame = true;
            _tacWin = true;
        }
        else if (_gameBoard[6] == 2 & _gameBoard[7] == 2 & _gameBoard[8] == 2)
        {
            _endGame = true;
            _tacWin = true;
        }

        else if (_gameBoard[0] == 2 & _gameBoard[4] == 2 & _gameBoard[8] == 2)
        {
            _endGame = true;
            _tacWin = true;
        }
        else if (_gameBoard[2] == 2 & _gameBoard[4] == 2 & _gameBoard[6] == 2)
        {
            _endGame = true;
            _tacWin = true;
        }

        else if(_fullArray == 9)
        {
            _endGame = true;
            _draw = true;
        }

        PrintWinner();
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
