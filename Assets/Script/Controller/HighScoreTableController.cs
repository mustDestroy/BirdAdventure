using Assets.Script;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTableController : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highScoreEntryTransformList;
    private HighScoreController.HighScoreEntry lastHighScoreEntry;
    private List<HighScoreController.HighScoreEntry> highScores;
    private int lastPlayerRank;

    private const int highScoreBoardSlot = 8;
    private const float entryTemplateHeight = 40f;


    private void Awake()
    {
        // DUMMY DATA
        //HighScoreController.AddHighScoreEntry(1, "Player1", 1);
        //HighScoreController.AddHighScoreEntry(10, "Player2", 2);
        //HighScoreController.AddHighScoreEntry(210, "Player3", 4);
        //HighScoreController.AddHighScoreEntry(20, "Player4", 10);
        //HighScoreController.AddHighScoreEntry(200, "Player5", 4);
        //HighScoreController.AddHighScoreEntry(4, "Player6", 1);
        //HighScoreController.AddHighScoreEntry(20, "NewPlayer", 9);

        entryContainer = transform.Find("HSTEntryContainer");
        entryTemplate = entryContainer.Find("HSTEntryTemplate");
        entryTemplate.gameObject.SetActive(false);


        // I need to handle the highscore board template based on the last player's results
        // because I want to show the results regardless its ranking
        lastHighScoreEntry = HighScoreController.GetLastHighScoreEntry();
        lastPlayerRank = HighScoreController.GetLastHighScoreEntryIndex() + 1;

        highScores = HighScoreController.LoadHighScores();
        highScoreEntryTransformList = new List<Transform>();


        // if last player's rank is in the top 8 &&
        // total highScores contains less then 8 palyer data
        if ((lastPlayerRank <= highScoreBoardSlot) && (highScores.Count <= highScoreBoardSlot))
        {
            //displays only the available ranking data from JSON file
            CreateHighScoreEntryTransformList(highScores, lastHighScoreEntry, entryContainer, highScoreEntryTransformList, highScores.Count);
        }
        else if ((lastPlayerRank <= highScoreBoardSlot) && (highScoreBoardSlot < highScores.Count))
        {
            CreateHighScoreEntryTransformList(highScores, lastHighScoreEntry, entryContainer, highScoreEntryTransformList, highScoreBoardSlot);
        }
        else if (highScoreBoardSlot < lastPlayerRank)
        {
            // display top 7 player only
            CreateHighScoreEntryTransformList(highScores, lastHighScoreEntry, entryContainer, highScoreEntryTransformList, highScoreBoardSlot - 1);

            // display last player's rank in the 8th slot just to inform the player about his performance in the last round
            CreateSingelScoreEntryTransform(lastHighScoreEntry, lastPlayerRank, entryContainer, highScoreEntryTransformList);
        }

    }
    private void CreateSingelScoreEntryTransform(HighScoreController.HighScoreEntry lastHighScoreEntry,
                                                int lastPlayerRank,
                                                Transform container,
                                                List<Transform> transformList)
    {


        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        entryRectTransform.anchoredPosition = new Vector2(0, (-entryTemplateHeight * transformList.Count));
        entryTransform.gameObject.SetActive(true);


        int rank = lastPlayerRank;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
        }

        entryTransform.Find("RankText").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = lastHighScoreEntry.score;
        entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        int level = lastHighScoreEntry.level;
        entryTransform.Find("LevelText").GetComponent<TextMeshProUGUI>().text = level.ToString();

        string name = lastHighScoreEntry.name;
        entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;


        // Highlight the last player's result
        entryTransform.Find("RankText").GetComponent<TextMeshProUGUI>().color = new Color(0.335849f, 2392751f, 0.1184977f, 0.8588235f);
        entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().color = new Color(0.335849f, 2392751f, 0.1184977f, 0.8588235f);
        entryTransform.Find("LevelText").GetComponent<TextMeshProUGUI>().color = new Color(0.335849f, 2392751f, 0.1184977f, 0.8588235f);
        entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().color = new Color(0.335849f, 2392751f, 0.1184977f, 0.8588235f);


        transformList.Add(entryTransform);
        //entryTransform.Find("RowBackground").gameObject.SetActive(rank % 2 == 1);

    }

    private void CreateHighScoreEntryTransformList(List<HighScoreController.HighScoreEntry> highScores,
                                                HighScoreController.HighScoreEntry lastHighScoreEntry,
                                                Transform container,
                                                List<Transform> transformList,
                                                int numberOfSlot)
    {
        for (int i = 0; i < numberOfSlot; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

            entryRectTransform.anchoredPosition = new Vector2(0, (-entryTemplateHeight * transformList.Count));
            entryTransform.gameObject.SetActive(true);

            // use the index to calculate the rank since the  highScores is ordered by score in desc
            int rank = i + 1;
            string rankString;
            switch (rank)
            {
                default:
                    rankString = rank + "TH";
                    entryTransform.Find("GoldTrophyImage").gameObject.SetActive(false);
                    entryTransform.Find("SilverTrophyImage").gameObject.SetActive(false);
                    entryTransform.Find("BronzeTrophyImage").gameObject.SetActive(false);
                    break;
                case 1:
                    Debug.Log("RANK1: " + rank);
                    rankString = "1ST";
                    entryTransform.Find("GoldTrophyImage").gameObject.SetActive(true);
                    entryTransform.Find("GoldTrophyImage").GetComponent<Image>();
                    break;
                case 2:
                    Debug.Log("RANK2: " + rank);
                    rankString = "2ST";
                    entryTransform.Find("SilverTrophyImage").gameObject.SetActive(true);
                    entryTransform.Find("SilverTrophyImage").GetComponent<Image>();
                    break;
                case 3:
                    Debug.Log("RANK3: " + rank);
                    rankString = "3ST";
                    entryTransform.Find("BronzeTrophyImage").gameObject.SetActive(true);
                    entryTransform.Find("BronzeTrophyImage").GetComponent<Image>();
                    break;
            }

            entryTransform.Find("RankText").GetComponent<TextMeshProUGUI>().text = rankString;

            int score = highScores[i].score;
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

            int level = highScores[i].level;
            entryTransform.Find("LevelText").GetComponent<TextMeshProUGUI>().text = level.ToString();

            string name = highScores[i].name;
            entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;

            // Set background rows visible odds and evens, easier to read
            entryTransform.Find("RowBackground").gameObject.SetActive(rank % 2 == 1);


            if (highScores[i].timeStamp == lastHighScoreEntry.timeStamp)
            {
                // Highlight the last player's result
                entryTransform.Find("RankText").GetComponent<TextMeshProUGUI>().color = new Color(0.335849f, 2392751f, 0.1184977f, 0.8588235f);
                entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().color = new Color(0.335849f, 2392751f, 0.1184977f, 0.8588235f);
                entryTransform.Find("LevelText").GetComponent<TextMeshProUGUI>().color = new Color(0.335849f, 2392751f, 0.1184977f, 0.8588235f);
                entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().color = new Color(0.335849f, 2392751f, 0.1184977f, 0.8588235f);

            }

            transformList.Add(entryTransform);
            entryTransform.Find("RowBackground").gameObject.SetActive(rank % 2 == 1);




        }


    }



}


