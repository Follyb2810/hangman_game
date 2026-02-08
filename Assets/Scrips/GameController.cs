using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
// using Env = System;

public class NewBehaviourScript : MonoBehaviour
{
    public TMP_Text timeField;
    public TMP_Text wordToFind;
    private float time;// = 3.1f;
    // private string path_name = Env.Environment.CurrentDirectory + "/Assets/word.txt";
    // Environment.CurrentDirectory + "/Assets/word.txt";
    // private string[] words = File.ReadAllLines(@"Assets/word.txt");
    // private string[] words = File.ReadAllLines(@"Assets/word.txt");
    private string[] words;
    private string[] wordLocal = new string[] { "milk", "bread", "eggs", "cheese", "yogurt", "pop corn", "shawarma" };
    private string hiddenWord;
    private string choosenWord;
    public GameObject[] hangMan;
    public GameObject winText;
    public GameObject loseText;
    private int fails;
    private bool gameEnd = false;

    // private string[] groceries = new string[] { "milk", "bread", "eggs", "cheese", "yogurt" };

    //! Declare a two-dimensional array (2 rows, 3 columns)
    // int[,] multiDimensionalArray = new int[2, 3];

    //! Declare and initialize a two-dimensional array
    // int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

    // private IList<string> food = new List<string>() { "milk", "bread", "eggs", "cheese", "yogurt" };


    // Start is called before the first frame update
    void Start()
    {

        // string path = Path.Combine(Application.streamingAssetsPath, "word.txt");
        string path = Path.Combine(
    Application.dataPath,
    "Texts/words.txt");
        //     string path = Path.Combine(
        // Application.streamingAssetsPath,
        // "Texts/words.txt");

        words = File.ReadAllLines(path);
        // int counter = 0;
        // while (counter < 6)xa
        // {
        //     Debug.Log(wordLocal[counter]);
        //     Debug.Log(words[counter]);
        //     counter++;
        // }
        // for (int i = 0; i < wordLocal.Length; i++)
        // for (int i = 0; i < words.Length; i++)
        // {

        // }

        // var rand = Random.Range(0, wordLocal.Length);
        var rand = Random.Range(0, words.Length);

        // choosenWord = "milk".ToUpper();

        // choosenWord = wordLocal[rand].ToUpper();
        choosenWord = words[rand].ToUpper();
        Debug.Log("chosen word: " + choosenWord);

        // wordToFind.text = "Word to find: " + choosenWord;
        for (int i = 0; i < choosenWord.Length; i++)
        {

            char letter = choosenWord[i];
            // Debug.Log(letter);
            if (char.IsWhiteSpace(letter))
            {
                hiddenWord += " ";

            }
            else
            {

                hiddenWord += "_";
            }

            wordToFind.text = "Word to find: " + hiddenWord;

        }




        // for (int i = 0; i < words.Length; i++)
        // for (int i = 0; i < wordLocal.Length; i++)
        // {
        //     words[i] = words[i].ToUpper();
        //     wordLocal[i] = wordLocal[i].ToUpper();
        //     wordLocal[i] = wordLocal[i].ToUpper();
        // }

        // foreach (string word in words)
        // foreach (string word in wordLocal)
        // {
        //     string upper = word.ToUpper();

        //     Debug.Log(upper);
        // }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed this frame");
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse clicked this frame");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right mouse clicked this frame");
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Middle mouse clicked this frame");
        }
        //! using input
        // for (char c = 'A'; c <= 'Z'; c++)
        // {
        //     if (Input.GetKeyDown(c.ToString()))
        //     {
        //         HandleLetter(c.ToString());
        //         break;
        //     }
        // }

        //!
        if (gameEnd == false)
        {

            time += Time.deltaTime;
            // timeField.text = "Time: " + time.ToString();
            timeField.text = "Time: " + time;
        }
    }
    void GetAll()
    {

    }
    void HandleLetter(string pressLetter)
    {
        pressLetter = pressLetter.ToUpper();

        if (choosenWord.Contains(pressLetter))
        {
            int pos = choosenWord.IndexOf(pressLetter);

            while (pos != -1)
            {
                hiddenWord =
                    hiddenWord.Substring(0, pos) +
                    pressLetter +
                    hiddenWord.Substring(pos + 1);

                choosenWord =
                    choosenWord.Substring(0, pos) +
                    "_" +
                    choosenWord.Substring(pos + 1);

                pos = choosenWord.IndexOf(pressLetter, pos + 1);
            }

            wordToFind.text = "Word to find: " + hiddenWord;
        }
        else
        {
            if (fails < hangMan.Length)
            {
                hangMan[fails].SetActive(true);
                fails++;
            }
        }

        if (fails >= hangMan.Length)
        {
            loseText.SetActive(true);
            winText.SetActive(false);
            gameEnd = true;
        }

        if (!hiddenWord.Contains("_"))
        {
            winText.SetActive(true);
            loseText.SetActive(false);
            gameEnd = true;
        }
    }

    private void OnGUI()
    {
        if (gameEnd) return;

        Event e = Event.current;
        bool keyLength = e.keyCode.ToString().Length == 1;
        string pressLetter = e.keyCode.ToString().ToUpper();

        if (e.type == EventType.KeyDown && keyLength)
        {
            if (choosenWord.Contains(pressLetter))
            {
                int pos = choosenWord.IndexOf(pressLetter);

                while (pos != -1)
                {
                    hiddenWord =
                        hiddenWord.Substring(0, pos) +
                        pressLetter +
                        hiddenWord.Substring(pos + 1);

                    choosenWord =
                        choosenWord.Substring(0, pos) +
                        "_" +
                        choosenWord.Substring(pos + 1);

                    pos = choosenWord.IndexOf(pressLetter, pos + 1);
                }

                wordToFind.text = "Word to find: " + hiddenWord;
            }
            else
            {
                if (fails < hangMan.Length)
                {
                    hangMan[fails].SetActive(true);
                    fails++;
                }
            }

            if (fails >= hangMan.Length)
            {
                loseText.SetActive(true);
                winText.SetActive(false);
                gameEnd = true;
            }

            if (!hiddenWord.Contains("_"))
            {
                winText.SetActive(true);
                loseText.SetActive(false);
                gameEnd = true;
            }
        }
    }

}
