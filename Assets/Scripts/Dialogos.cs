using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.EventSystems;

public class Dialogos : MonoBehaviour
{
    public bool is_dialogo { get; private set; }
    public GameObject player;
    public TextAsset inkJson;

    private Story story;
    private static Dialogos instance;

    [SerializeField] private GameObject dialogoPanel;
    [SerializeField] private TextMeshProUGUI dialogoText;

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private void Awake() {
        if (instance != null)
        {
            Debug.LogWarning("Mas de un dialogo manager en la escena");
        }
        instance = this;
    }

    public static Dialogos GetIntance(){
        return instance;
    }
    private void Start() {
        is_dialogo = false;
        dialogoPanel.SetActive(false);

        // Obtengo a los hijos del objeto
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices){
            choicesText[index] = choice.GetComponent<TextMeshProUGUI>();
            index++;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        story = new Story(inkJson.text);
        is_dialogo = true;
        dialogoPanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode(){
        is_dialogo = false;
        dialogoPanel.SetActive(false);
        dialogoText.text = "";
    }

    private void OnMouseDown() {
        
        // Toda la parte de isntanciar la converzacion se puede extraer a un script de trigger de converzacion

        if (gameObject.tag == "NPC")
        {
            EnterDialogueMode(inkJson);
        }


    }

    private void ContinueStory(){
        if (story.canContinue){
            dialogoText.text = story.Continue();
            displayChoices();   
        }
        else{
            ExitDialogueMode();
        }
    }


    private void displayChoices(){

        List<Choice> currentChoices = story.currentChoices;

        if (currentChoices.Count > choices.Length){
            Debug.LogError("Hay mas opciones " + currentChoices.Count + 
            " que las soportadas por la ui " + choices.Length);
        }
        
        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());

    }

    private IEnumerator SelectFirstChoice(){
        // Primero espera
        // hasta el ultimo frame para asignar
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

}
