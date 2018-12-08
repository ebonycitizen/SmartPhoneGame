using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour {

    [SerializeField]
    private string rightEnemyTag = "RightEnemy";

    [SerializeField]
    private string leftEnemyTag = "LeftEnemy";

    private string tagName;

    private enum InputState
    {
        None,
        Right,
        Left,
        Both
    }

    private InputState inputState;
    private InputState oldInputState;

    private bool right=false;
    private bool left=false;

    [SerializeField]
    GameObject white;

    [SerializeField]
    GameObject black;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //PakuriInput();
        //Pakuri2Input();
        //SubInput();
        //MainInput();

        OtherInput();
    }

    private void OtherInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            white.SetActive(true);
            black.SetActive(false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            white.SetActive(false);
            black.SetActive(true);
        }
    }

    private void PakuriInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<OtherPlayerController>().Pause();
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<OtherPlayerController>().Play();
        }
        if (Input.GetMouseButton(0))
        {

        }
    }

    private void Pakuri2Input()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<OtherPlayerController>().Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<OtherPlayerController>().Pause();
        }
        if (Input.GetMouseButton(0))
        {

        }
    }

    private void SubInput()
    {

        if(Input.GetMouseButtonDown(1))
        {
            GameObject[] rightObjects = GameObject.FindGameObjectsWithTag(rightEnemyTag);
            foreach (GameObject rightObject in rightObjects)
                rightObject.GetComponent<EnemyBase>().OnPause();
            right = true;
        }
        if(Input.GetMouseButtonUp(1))
        {
            GameObject[] rightObjects = GameObject.FindGameObjectsWithTag(rightEnemyTag);
            foreach (GameObject rightObject in rightObjects)
                rightObject.GetComponent<EnemyBase>().OnPlay();
            right = false;
        }
        if(Input.GetMouseButton(1))
        {

        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject[] rightObjects = GameObject.FindGameObjectsWithTag(leftEnemyTag);
            foreach (GameObject rightObject in rightObjects)
                rightObject.GetComponent<EnemyBase>().OnPause();
            left = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameObject[] rightObjects = GameObject.FindGameObjectsWithTag(leftEnemyTag);
            foreach (GameObject rightObject in rightObjects)
                rightObject.GetComponent<EnemyBase>().OnPlay();
            left = false;
        }
        if (Input.GetMouseButton(0))
        {

        }

        if (right && left)
        {
            inputState = InputState.Both;
        }
        else
        {
            inputState = InputState.None;
        }

        if (oldInputState == inputState)
            return;

        if (inputState == InputState.Both)
        {
            GetComponent<OtherPlayerController>().Pause();
        }
        else
        {
            GetComponent<OtherPlayerController>().Play();
        }

        oldInputState = inputState;

    }

    private void MainInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            tagName = rightEnemyTag;

            //if (Screen.width / 2 < Input.mousePosition.x)
            //{
            //    tagName = rightEnemyTag;
            //}
            //else if (Screen.width / 2 >= Input.mousePosition.x)
            //{
            //    tagName = leftEnemyTag;
            //}

            GameObject[] rightObjects = GameObject.FindGameObjectsWithTag(rightEnemyTag);
            foreach (GameObject rightObject in rightObjects)
                rightObject.GetComponent<EnemyBase>().OnPause();
        }
        if (Input.GetMouseButtonUp(1))
        {
            GameObject[] rightObjects = GameObject.FindGameObjectsWithTag(rightEnemyTag);
            foreach (GameObject rightObject in rightObjects)
                rightObject.GetComponent<EnemyBase>().OnPlay();
        }

        if (Input.GetMouseButtonDown(0))
        {

            GameObject[] rightObjects = GameObject.FindGameObjectsWithTag(leftEnemyTag);
            foreach (GameObject rightObject in rightObjects)
                rightObject.GetComponent<EnemyBase>().OnPause();
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject[] rightObjects = GameObject.FindGameObjectsWithTag(leftEnemyTag);
            foreach (GameObject rightObject in rightObjects)
                rightObject.GetComponent<EnemyBase>().OnPlay();
        }
    }
}
