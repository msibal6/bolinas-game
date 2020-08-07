using UnityEngine;
using UnityEngine.UI;
public class DrivingManager : MonoBehaviour
{

    public Button straight;
    public Button right;
    public Button back;
    public Button left;

    public GameObject map;

    public Button[] availableTurns;

    private BolinasTile[] bolinasTiles;
    private Person person;
    private BolinasTile currentLocation;
    private enum Turn { straight, right, back, left };



    // Start is called before the first frame update
    void Start() {
        person = GameManager.instance.person;
        bolinasTiles = map.GetComponentsInChildren<BolinasTile>();
        print(bolinasTiles.Length);
        foreach (BolinasTile tile in bolinasTiles) {
            if (tile.name == person.bolinasTile) {
                currentLocation = tile;
                break;
            }
        }

        // start the first turn section
        // show turns
        for (int i = 0; i < currentLocation.neighbors.Length; i++) {
            if (currentLocation.neighbors[i] == null) {
                availableTurns[i].interactable = false;
            }
        }
    }

    public void ShowTurns(BolinasTile origin, BolinasTile currentLocation) {
        print("coming from" + origin.name);
        print("now in " + currentLocation.name);
        int originIndex = 0;

        for (int i = 0; i < currentLocation.neighbors.Length; i++) {
            if (currentLocation.neighbors[i] == origin) {
                originIndex = i;
                break;
            }
        }

        if ((Turn)originIndex == Turn.straight) {
            UpdateButtons(2);
        } else if ((Turn)originIndex == Turn.right) {
            print("oneth");
            UpdateButtons(1);
        } else if ((Turn)originIndex == Turn.back) {
            UpdateButtons(0);
        } else if ((Turn)originIndex == Turn.left) {
            UpdateButtons(3);
        }

    }

    private void UpdateButtons(int offset) {
        for (int i = 0; i < currentLocation.neighbors.Length; i++) {
            int buttonIndex = i + offset;
            if (buttonIndex >= currentLocation.neighbors.Length) {
                buttonIndex -= currentLocation.neighbors.Length;
            }
            if (currentLocation.neighbors[i] != null) {
                availableTurns[buttonIndex].interactable = true;
            } else {
                availableTurns[buttonIndex].interactable = false;
            }
        }
        currentLocation.SetOffset(offset);
    }

    public void GoTo(int neighbor) {
        BolinasTile oldLocation = currentLocation;
        int chosenNeighbor = neighbor;
        chosenNeighbor -= oldLocation.GetOffset();
        if (chosenNeighbor < 0) {
            chosenNeighbor += oldLocation.neighbors.Length;
        }
        currentLocation = oldLocation.neighbors[chosenNeighbor];
        ShowTurns(oldLocation, currentLocation);
    }
}

