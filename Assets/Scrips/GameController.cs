using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TMP_Text timeField;
    public TMP_Text wordToFind;
    private float time;// = 3.1f;
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
        // int counter = 0;
        // while (counter < 6)
        // {
        //     Debug.Log(wordLocal[counter]);
        //     counter++;
        // }
        // for (int i = 0; i < wordLocal.Length; i++)
        // {

        // }

        var rand = Random.Range(0, wordLocal.Length);

        // choosenWord = "milk".ToUpper();

        choosenWord = wordLocal[rand].ToUpper();
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




        // for (int i = 0; i < wordLocal.Length; i++)
        // {
        //     wordLocal[i] = wordLocal[i].ToUpper();
        // }

        // foreach (string word in wordLocal)
        // {
        //     string upper = word.ToUpper();

        //     Debug.Log(upper);
        // }
        // Debug.Log(wordLocal[0]);
        // Debug.Log(wordLocal[2]);
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
    private void OnGUI()
    {
        Event e = Event.current;
        bool keyLength = e.keyCode.ToString().Length == 1;

        string pressLetter = e.keyCode.ToString();
        if (e.type == EventType.KeyDown && keyLength)
        {
            if (choosenWord.Contains(pressLetter))
            {
                int pos = choosenWord.IndexOf(pressLetter);

                while (pos != -1)
                {
                    Debug.Log("Found letter at index: " + pos);
                    hiddenWord = hiddenWord.Substring(0, pos) + pressLetter + hiddenWord.Substring(pos + 1);
                    Debug.Log("hiddenWord: " + hiddenWord);

                    choosenWord = choosenWord.Substring(0, pos) + "_" + choosenWord.Substring(pos + 1);
                    Debug.Log("choosenWord: " + choosenWord);
                    pos = choosenWord.IndexOf(pressLetter, pos + 1);
                    // pos = choosenWord.IndexOf(pressLetter);

                }
                wordToFind.text = "Word to find: " + hiddenWord;


            }
            else
            {
                hangMan[fails].SetActive(true);
                fails++;
            }
            if (fails == hangMan.Length)
            {
                loseText.SetActive(true);
                winText.SetActive(false);
                gameEnd = true;


            }
            if (!hiddenWord.Contains("_"))
            {
                gameEnd = true;
                winText.SetActive(true);
                loseText.SetActive(false);

            }
            Debug.Log("Key Down is pressed " + pressLetter);
        }
        else if (e.type == EventType.KeyUp && keyLength)
        {
            Debug.Log("Key Up is pressed" + pressLetter);
        }
        else if (e.type == EventType.MouseDown && keyLength)
        {
            Debug.Log("Mouse Down is pressed" + pressLetter);
        }
        else if (e.type == EventType.MouseUp && keyLength)
        {
            Debug.Log("Mouse Up is pressed " + pressLetter);
        }
        else if (e.type == EventType.MouseDrag && keyLength)
        {
            Debug.Log("Mouse Drag is pressed " + pressLetter);
        }
    }
}
