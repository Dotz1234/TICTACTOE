using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;


public class GameControler : MonoBehaviour
{
    public int whoseTurn;
    public int turnCount;
    public GameObject[] turnIcons;
    public Sprite[] playerIcons;
    public Button[] tictactoeSpaces;
    public int[] markedSpaces;
    public Text winnerText;
    public GameObject[] winningLine;
    public GameObject winnerController;
    public int SwordsScore;
    public int ShieldsScore;
    public Text SwordScoreText;
    public Text ShieldScoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameRules();
    }
       
   

        void GameRules()
        {
            whoseTurn = 0;
            turnCount = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
            for(int i = 0; i <tictactoeSpaces.Length; i ++)
            {
                tictactoeSpaces[i].interactable = true;
                tictactoeSpaces[i].GetComponent<Image>().sprite = null;
            }
            for(int i = 0; i < markedSpaces.Length; i++)
            {
             markedSpaces[i] = -100;
            }

        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TicTacToeButton(int WhichNumber)
    {
        tictactoeSpaces[WhichNumber].image.sprite = playerIcons[whoseTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoseTurn+1;
        turnCount++;
        if (turnCount > 4)
        {
            WinnerCheck();
        }
        if(whoseTurn == 0)
        {
            whoseTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else
        {
            whoseTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }

    void WinnerCheck()
    {
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int s8 = markedSpaces[6] + markedSpaces[4] + markedSpaces[2];
        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for(int i = 0; i < solutions.Length; i++)
        {
            if(solutions[i] == 3*(whoseTurn+1))
            {
                WinnerDisplay(i);
                return;
            }
        }
    }

    void WinnerDisplay(int indexIn)
    {
        winnerController.gameObject.SetActive(true);
        if(whoseTurn == 0)
        {
            SwordsScore++;
            SwordScoreText.text = SwordsScore.ToString();
            winnerText.text = "SWORDS WIN!!!!";
        }
        else if(whoseTurn == 1)
        {
            ShieldsScore++;
            ShieldScoreText.text = ShieldsScore.ToString();
            winnerText.text = "SHIELDS WIN!!!!";
        }
        winningLine[indexIn].SetActive(true);
    }
    public void Replay()
    {
        GameRules();
        for(int i = 0; i <winningLine.Length; i++)
        {
            winningLine[i].SetActive(false);
        }
        winnerController.SetActive(false);
    }
    public void Restart()
    {
        Replay();
        SwordsScore = 0;
        ShieldsScore = 0;
        SwordScoreText.text = "0";
        ShieldScoreText.text = "0";
    }

    public void Quitting()
    {
        Replay();
        SwordsScore = 0;
        ShieldsScore = 0;
        SwordScoreText.text = "0";
        ShieldScoreText.text = "0"; 
        print("Quitting Game");
        Application.Quit();
    }
}
