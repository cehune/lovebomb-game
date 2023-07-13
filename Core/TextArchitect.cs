/*
    text architect for text system. Prepares tmpro setup for
    conversations, text, etc
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;




public class TextArchitect
{

    public float SPEED = 1; // text scroll speed
    private int CHARACTERS_PER_CYCLE = 2;

    //for 2d and 3d text systems. Will be using tmpro_ui for lovebomb
    private TextMeshProUGUI tmpro_ui;
    private TextMeshPro tmpro_world;

    // Choose which tmp text style to use
    public TMP_Text tmpro => tmpro_ui != null ? tmpro_ui : tmpro_world;
    
    // Current and added texts
    public string currentText => tmpro.text;
    public string targetText{get;private set;} = "";
    public string preText { get; private set; } = "";
    public int preTextLength = 0;
    public string fullTargetText => preText + targetText;
    
    // Change text colour. I would like to highlight certain words for emphasis
    public Color textColor { get { return tmpro.color ;} set { tmpro.color = value;}}

    // default speed should be a type writer, I would like it to display the text block 
    // if you click again though
    public bool displayBlock = false;



        //Constructors;

    public TextArchitect(TextMeshProUGUI tmpro_ui)
    {
        this.tmpro_ui = tmpro_ui;
    }
    public TextArchitect(TextMeshPro tmpro_world)
    {
        this.tmpro_world = tmpro_world;
    }



        /* Coroutines for building and appending text.
        * 
        * building essentially is when you are creating a new text architect
        * Appending is when you just wanna add on text into a related topic, use the same architect
        * 
        */


    private Coroutine buildProcess = null;
    public bool isBuilding => buildProcess != null;

    
    public Coroutine Build(string text)
    {
        // Create a new pretext and set the target text, start a coroutine to build the architect
        preText = "";
        targetText = text;

        stopCoroutine();
        buildProcess = tmpro_ui.StartCoroutine(Building());

        return buildProcess;
    }
    public Coroutine Append(string text)
    {
        // Add the target text, start a coroutine to build the architect
        preText = tmpro.text;
        targetText = text;

        stopCoroutine();
        buildProcess = tmpro_ui.StartCoroutine(Building());

        return buildProcess;
    }

    
    public void stopCoroutine()
    {
        if (!isBuilding) return;
        tmpro_ui.StopCoroutine(buildProcess);
        buildProcess = null;
    }

    IEnumerator Building()
    {
        yield return null;
    }

}


