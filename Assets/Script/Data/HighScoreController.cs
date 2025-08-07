using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    // Have a class which offers a set of functions to manage the score of players in a flexible way
    // I can invoke it any part of the game without instantiation, having one global instance in the memory
    static class HighScoreController
    {
        private static string FilePath = Application.persistentDataPath + "/highscores.json";

        private static HighScores LoadHighScoresInternal()
        {
            // Check the existence of the file first
            if (File.Exists(FilePath))
            {
                string jsonString = File.ReadAllText(FilePath);
                HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
                //Debug.Log("Score: " + highScores.highScoreEntryList[0].Score + "   Name: " +
                //    highScores.highScoreEntryList[0].Name + "  TimeStamp:  " + highScores.highScoreEntryList[0].TimeStamp);
                if ((highScores == null) || (highScores.highScoreEntryList == null))
                {
                    return new HighScores();
                }

                return highScores;
            }
            else
            {
                return new HighScores(); // Empty fallback
            }
        }
        public static List<HighScoreEntry> LoadHighScores()
        {
            HighScores highScores = LoadHighScoresInternal();
            Debug.Log("LENGTH:" + highScores.highScoreEntryList.Count);
            return highScores.highScoreEntryList ?? new List<HighScoreEntry>();

        }

        public static void AddHighScoreEntry(int score, string name, int level)
        {
            // Create new HighScoreEntry
            HighScoreEntry newHighScoreEntry = new HighScoreEntry(score, name, level, DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            //Debug.Log("Score: " + newHighScoreEntry.score + "   Name: "+ newHighScoreEntry.name +"   Level:  "+ newHighScoreEntry.level +"  TimeStamp"+newHighScoreEntry.timeStamp);

            // Load saved HighScores
            HighScores highScoresWrapper = LoadHighScoresInternal();
            List<HighScoreEntry> highScores = highScoresWrapper.highScoreEntryList;


            // Add new entry
            highScores.Add(newHighScoreEntry);

            //Sorting in descending order by score
            highScores.Sort((a, b) => b.score.CompareTo(a.score));

            // Save the updated list back to Json file
            string jsonString = JsonUtility.ToJson(highScoresWrapper, true);
            File.WriteAllText(FilePath, jsonString);

            Debug.Log("High score saved to " + FilePath);

        }

        public static HighScoreEntry GetLastHighScoreEntry()
        {
            List<HighScoreEntry> highScores = LoadHighScores();

            if (highScores == null || highScores.Count == 0)
            {
                return null;
            }
            //search for the highest TimeStamp among the HighScoreEntrys
            var maxTimeStamp = highScores[0].timeStamp;
            int currentEntryIndex = 0;

            for (int i = 1; i < highScores.Count; i++)
            {
                if (maxTimeStamp < highScores[i].timeStamp)
                {
                    maxTimeStamp = highScores[i].timeStamp;
                    currentEntryIndex = i;
                }
            }


            // add + 1 to the index of the element in the list to have a valid rank number
            return highScores[currentEntryIndex];

        }

        public static int GetLastHighScoreEntryIndex()
        {
            List<HighScoreEntry> highScores = LoadHighScores();

            if (highScores == null || highScores.Count == 0)
            {
                return -1;
            }
            //search for the highest TimeStamp among the HighScoreEntrys
            var maxTimeStamp = highScores[0].timeStamp;
            int currentEntryIndex = 0;

            for (int i = 1; i < highScores.Count; i++)
            {
                if (maxTimeStamp < highScores[i].timeStamp)
                {
                    maxTimeStamp = highScores[i].timeStamp;
                    currentEntryIndex = i;
                }
            }


            // add + 1 to the index of the element in the list to have a valid rank number
            return currentEntryIndex;

        }

        public static void ClearHighScores()
        {
            // Delete the file
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                Debug.Log("High scores cleared.");
            }

        }

        // Represents the list of highscores
        [System.Serializable]
        private class HighScores
        {
            public List<HighScoreEntry> highScoreEntryList = new List<HighScoreEntry>();

        }


        // Represents a single HighScore Entry
        [System.Serializable]
        public class HighScoreEntry
        {
            // Set field to public because JsonUtility class cannnot handle the serialization of private classes
            //Later solution: Newtonsoft.Json (JSON.NET) or System.Text.Json
            public int score;
            public string name;
            public int level;
            public long timeStamp;

            //public int Score
            //{
            //    get
            //    {
            //        return score;
            //    }
            //    private set { score = value; }
            //}
            //public string Name
            //{
            //    get { return name; }
            //    private set { name = value; }
            //}
            //public long TimeStamp
            //{
            //    get { return timeStamp; }
            //    private set { timeStamp = value; }
            //}

            public HighScoreEntry(int score, string name, int level, long timeStamp)
            {
                this.score = score;
                this.name = name;
                this.level = level;
                this.timeStamp = timeStamp;
            }
        }
    }
}
