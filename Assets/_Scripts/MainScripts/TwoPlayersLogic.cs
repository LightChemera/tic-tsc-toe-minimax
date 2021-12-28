using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class TwoPlayersLogic : MonoBehaviour
{
    [SerializeField]
    private Sprite _ticSp;

    [SerializeField]
    private Sprite _tacSp;

    [SerializeField]
    private Image _whoMoveImg;

    [SerializeField]
    private Text _winnerTxt;

    [SerializeField]
    private GameObject _panel;

    private int[] _gameBoard = {0, 0, 0,
                                0, 0, 0,
                                0, 0, 0};


    private int _fullArray = 0;

    private string _whoMove = "tic";
    private string _whoMoveArray = "tic";

    private bool _ticWin;
    private bool _tacWin;
    private bool _draw;
   

    public void TextureChange(Button _button)
    { 
        _button.GetComponent<Image>();

        if (_whoMove == "tic")
        {
            _button.image.sprite = _ticSp;
            _button.interactable = false;
            _whoMoveImg.sprite = _tacSp;
            _whoMove = "tac";
        }
        else
        {
            _button.image.sprite = _tacSp;
            _button.interactable = false;
            _whoMoveImg.sprite = _ticSp;
            _whoMove = "tic";
        }
 
    }

    public void ArrayInput(int index)
    {
        if(_whoMoveArray == "tic")
        {
            _gameBoard[index] = 1;
            _fullArray++;
            _whoMoveArray = "tac";
            WhoWin();
        }
        else
        {
            _gameBoard[index] = 2;
            _fullArray++;
            _whoMoveArray = "tic";
            WhoWin();
        }

    }

    private void WhoWin()
    {
        //if tic win
        if(_gameBoard[0] == 1 & _gameBoard[3] == 1 & _gameBoard[6] == 1) 
        {
            _ticWin = true;                               
        }
        else if(_gameBoard[1] == 1 & _gameBoard[4] == 1 & _gameBoard[7] == 1)
        {
            _ticWin = true;
        }
        else if (_gameBoard[2] == 1 & _gameBoard[5] == 1 & _gameBoard[8] == 1)
        {
            _ticWin = true;
        }

        else if (_gameBoard[0] == 1 & _gameBoard[1] == 1 & _gameBoard[2] == 1)
        {
            _ticWin = true;
        }
        else if (_gameBoard[3] == 1 & _gameBoard[4] == 1 & _gameBoard[5] == 1)
        {
            _ticWin = true;
        }
        else if (_gameBoard[6] == 1 & _gameBoard[7] == 1 & _gameBoard[8] == 1)
        {
            _ticWin = true;
        }

        else if (_gameBoard[0] == 1 & _gameBoard[4] == 1 & _gameBoard[8] == 1)
        {
            _ticWin = true;
        }
        else if (_gameBoard[2] == 1 & _gameBoard[4] == 1 & _gameBoard[6] == 1)
        {
            _ticWin = true;
        }
        //if tac win
        if (_gameBoard[0] == 2 & _gameBoard[3] == 2 & _gameBoard[6] == 2)
        {
            _tacWin = true;
        }
        else if (_gameBoard[1] == 2 & _gameBoard[4] == 2 & _gameBoard[7] == 2)
        {
            _tacWin = true;
        }
        else if (_gameBoard[2] == 2 & _gameBoard[5] == 2 & _gameBoard[8] == 2)
        {
            _tacWin = true;
        }

        else if (_gameBoard[0] == 2 & _gameBoard[1] == 2 & _gameBoard[2] == 2)
        {
            _tacWin = true;
        }
        else if (_gameBoard[3] == 2 & _gameBoard[4] == 2 & _gameBoard[5] == 2)
        {
            _tacWin = true;
        }
        else if (_gameBoard[6] == 2 & _gameBoard[7] == 2 & _gameBoard[8] == 2)
        {
            _tacWin = true;
        }

        else if (_gameBoard[0] == 2 & _gameBoard[4] == 2 & _gameBoard[8] == 2)
        {
            _tacWin = true;
        }
        else if (_gameBoard[2] == 2 & _gameBoard[4] == 2 & _gameBoard[6] == 2)
        {
            _tacWin = true;
        }

        else if(_fullArray == 9)
        {
            _draw = true;
        }

        PrintWinner();
    }

    private void PrintWinner()
    {
        if (_ticWin)
        {
            _panel.SetActive(true);
            _winnerTxt.text = "Tic win!";
        } 
        else if(_tacWin)
        {
            _panel.SetActive(true);
            _winnerTxt.text = "Tac win!";
        }
        else if(_draw)
        {
            _panel.SetActive(true);
            _winnerTxt.text = "Draw!";
        }
    }
}
