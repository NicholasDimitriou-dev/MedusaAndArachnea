using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public TextAsset levelFile;
    public Transform levelRoot;
    //3 horz doors(interaction), 3 verical(interaction), 1 weight, enemy path, 2 doors, collectible 
    [Header("Prefabs")]
    public GameObject HorzintalDoorOne; // $
    public GameObject HorzintalDoorOneButton; //4
    public GameObject HorizonalDoorTwo; //%
    public GameObject HorzintalDoorTwoButton; //5
    public GameObject HorizonltalDoorThree; //^
    public GameObject HorzintalDoorThreeButton; //6
    public GameObject VerticalDoorOne; //!
    public GameObject VerticalDoorOneButton; //1
    public GameObject VerticalDoorTwo; //@
    public GameObject VerticalDoorTwoButton; //2
    public GameObject VerticalDoorThree; //#
    public GameObject VerticalDoorThreeButton; //3
    public GameObject wieghtBlockPrefab;
    public GameObject enemyPathPrefab;
    public GameObject doorMedPrefab;
    public GameObject doorArPrefab;
    public GameObject collectPrefab;
    public GameObject blockPrefab;
    public GameObject Medusa;
    public GameObject Aracnea;

    private void Start()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        // Push lines onto a stack so we can pop bottom-up rows. This is easy to reason
        //  about, but an index-based loop over the string array is faster.
        Stack<string> levelRows = new Stack<string>();

        foreach (string line in levelFile.text.Split('\n'))
            levelRows.Push(line);

        int row = 0;
        while (levelRows.Count > 0)
        {
            string rowString = levelRows.Pop();
            char[] rowChars = rowString.ToCharArray();
            
            for (var columnIndex = 0; columnIndex < rowChars.Length; columnIndex++)
            {
                var currentChar = rowChars[columnIndex];

                // Todo - Instantiate a new GameObject that matches the type specified by the character
                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
                if (currentChar == 'x')
                {
                 Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                 Transform rockInstance = Instantiate(blockPrefab, levelRoot).transform;
                 rockInstance.position = position;   
                }
                if (currentChar == 'm')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(Medusa, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == 'a')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(Aracnea, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == 'c')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(collectPrefab, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '-')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(doorMedPrefab, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '+')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(doorArPrefab, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == 'e')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(enemyPathPrefab, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == 'w')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(wieghtBlockPrefab, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == 'c')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(blockPrefab, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '1')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(VerticalDoorOneButton, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '!')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(VerticalDoorOne, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '2')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(VerticalDoorTwoButton, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '@')
                {
                    Vector3 position = new Vector3(columnIndex+0.5f, row+0.5f, 0f);
                    Transform rockInstance = Instantiate(VerticalDoorTwo, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '3')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(VerticalDoorThreeButton, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '#')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(VerticalDoorThree, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '4')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(HorzintalDoorOneButton, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '$')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(HorzintalDoorOne, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '5')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(HorzintalDoorTwoButton, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '%')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(HorizonalDoorTwo, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '6')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(HorzintalDoorThreeButton, levelRoot).transform;
                    rockInstance.position = position;   
                }
                if (currentChar == '^')
                {
                    Vector3 position = new Vector3(0f, row+0.5f, columnIndex+0.5f);
                    Transform rockInstance = Instantiate(HorizonltalDoorThree, levelRoot).transform;
                    rockInstance.position = position;   
                }

                
                
                
            }

            row++;
        }
    }
}
