using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour {
    private int infoStage;
    public GameObject bolinasMap;
    public Button nextButton;
    public Person person;
    public MuggleGroup local;
    public MuggleGroup independent;
    public MuggleGroup plannedAhead;
    public InputField groupSize;
    public Dropdown transportation;
    public string cheese;
    public GameObject[] infoPrompts;

    private void Start() {
        groupSize.onValueChanged.AddListener(delegate {
            GetGroupSize(groupSize.text);
            }
        );
        transportation.onValueChanged.AddListener(delegate {
            person.transportation = transportation.captionText.text;
            }
        );
    }

    private void Update() {
        switch (infoStage) {
            case (0):
                // Must interact with the UI to move to next selection 
                if (person == null) {
                    nextButton.interactable = false;
                } else {
                    nextButton.interactable = true;
                }
                break;
            default:
                break;
        }
    }

    // Changes the questions to the next round
    // or switches to the next scene if we are done getting all info
    public void NextInfo() {

        if (infoStage == 0) {
            bolinasMap.SetActive(false);
            person.transportation = transportation.captionText.text;
        } else if (infoStage == 1) {
            person.transportation = transportation.captionText.text;
        }
        infoPrompts[infoStage].SetActive(false);
        infoStage++;

        if (infoStage >= infoPrompts.Length) {
            GameManager.instance.person = new Person(person);
            GameManager.instance.NextStage();

        } else { 
            infoPrompts[infoStage].SetActive(true);
            nextButton.interactable = false;
        }
    }

    // handling for the group input and vehicle dropdown
    public void GetGroupSize(string input) {
        if (input.IsAllDigits()) {
            person.groupSize = int.Parse(input);
            nextButton.interactable = true;
        }
    }

    // Updates the values of the changing muggle fields
    public void UpdateMuggle(string field) {
        switch (field) {
            case ("local"):
                person.local = local.activeToggle.isOn;
                break;
            case ("independent"):
                person.independent = independent.activeToggle.isOn;
                break;
            case ("plannedAhead"):
                person.plannedAhead = plannedAhead.activeToggle.isOn;
                break;
            default:
                break;
        }
    }
}





    


