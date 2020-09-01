using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class DrivingManager : MonoBehaviour
{

    public Camera mapCamera;
    public GameObject map;
    public Fire fire;
    public Text infoSplash;
    public Button[] availableTurns;
    private BolinasTile[] bolinasTiles;
    private Person person;
    private BolinasTile currentLocation;
    private enum Turn { straight, right, back, left };



    // Start is called before the first frame update
    void Start() {
        person = GameManager.instance.person;
        bolinasTiles = map.GetComponentsInChildren<BolinasTile>();
        foreach (BolinasTile tile in bolinasTiles) {
            if (tile.name == person.bolinasTile) {
                currentLocation = tile;
                break;
            }
        }

        // start the first turn section
        bool turned = false;
        mapCamera.PanTo(currentLocation.transform.position);
        for (int i = 0; i < currentLocation.neighbors.Length; i++) {
            if (turned == false && currentLocation.neighbors[i] != null) {
                // TODO rotate to face it
                // This turns to the first available which might not be the straight
                // 
                mapCamera.gameObject.RotateTo(currentLocation.transform.position,
                    currentLocation.neighbors[i].transform.position);
                turned = true;
            }
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

        // originIndex is which tile player is coming from with respect
        // to current location list of neighbors
        if ((Turn)originIndex == Turn.straight) {
            UpdateButtons(2);
        } else if ((Turn)originIndex == Turn.right) {
            UpdateButtons(1);
        } else if ((Turn)originIndex == Turn.back) {
            UpdateButtons(0);
        } else if ((Turn)originIndex == Turn.left) {
            UpdateButtons(3);
        }
        mapCamera.gameObject.RotateTo(origin.transform.position,
                    currentLocation.transform.position);
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
        mapCamera.PanTo(currentLocation.transform.position);
        
    }

    public void GoTo(int neighbor) {

        BolinasTile oldLocation = currentLocation;
        int chosenNeighbor = neighbor;
        chosenNeighbor -= oldLocation.offset;
        if (chosenNeighbor < 0) {
            chosenNeighbor += oldLocation.neighbors.Length;
        }

        if (oldLocation.neighbors[chosenNeighbor].DangerFromFire()) {
            //print("new location on fire");
            //print(oldLocation.neighbors[chosenNeighbor].name);
            StartCoroutine("ShowFireWarning");
            print("fire");
        } else {
            currentLocation = oldLocation.neighbors[chosenNeighbor];
            fire.Spread();
            ShowTurns(oldLocation, currentLocation);
        }
    }

    public IEnumerator ShowFireWarning() {
        infoSplash.gameObject.SetActive(true); 
        yield return new WaitForSecondsRealtime(.5f);
        infoSplash.gameObject.SetActive(false);
    }
     
}

