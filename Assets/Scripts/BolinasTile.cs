using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BolinasTile : MonoBehaviour
{
    public enum TrafficStatus { Light, Medium, Heavy};
    public string terrain;
    public bool autoPopulateNeighbors = true;
    public bool ignore0 = false;
    public bool ignore1 = false;
    public bool ignore2 = false;
    public bool ignore3 = false;
    public BolinasTile[] neighbors;
    public int offset { get; private set; }
    public TrafficStatus trafficStatus;
    public bool onFire { get; private set;}
    private bool blocked;

    private Vector2 mousePosition;
    private float deltaX, deltaY;



    private void Awake() {

        // Looking for the neighbors
        // TODO no longer need autoPopulateNeighbors as check 
        if (autoPopulateNeighbors) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, 5);
            if (!ignore0) {
                AssignNeighbor(hit, 0);
            }

            if (!ignore1) {
                hit = Physics2D.Raycast(transform.position, transform.up, 5);
                AssignNeighbor(hit, 1);
            }

            if (!ignore2) {
                hit = Physics2D.Raycast(transform.position, transform.right, 5);
                AssignNeighbor(hit, 2);
            }

            if (!ignore3) {
                hit = Physics2D.Raycast(transform.position, -transform.up, 5);
                AssignNeighbor(hit, 3);
            }
        }
    }

    private void AssignNeighbor(RaycastHit2D hit, int neighbor) {
        if (hit.collider == null) {
            ;
        } else {
            neighbors[neighbor] = hit.collider.gameObject.GetComponentInChildren<BolinasTile>();
        }
    }

    // Offset was used to calculate  where the player was looking from
    // in order to toggle the correct direction buttons
    // and determine which neighbor player wanted to drive to
    public void SetOffset(int newOffset) {
        offset = newOffset;
    }

    public bool DangerFromFire() {
        foreach (BolinasTile neighbor in neighbors) {
            if (neighbor != null && neighbor.onFire)
                return true;
        }
        return onFire;
    }

    public void SetFire() {
        onFire = true;
    }

    public void Extinguish() {
        onFire = false;
    }


    private void OnMouseDown() {

        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.parent.transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.parent.transform.position.y;

        // Place holder for highlight the tile where they live 
        GameObject text = GameObject.Find("location question");
        text.GetComponent<Text>().text = gameObject.name;
        // location grab of where the player is
        // TODO add location grab of where the rest of their evacutation party is
        if (SceneManager.GetActiveScene().name == "info grab") {
            InfoManager infoManager = FindObjectOfType<InfoManager>();
            infoManager.person = new Person {
                bolinasTile = gameObject.GetComponent<BolinasTile>().name
            };
            print(infoManager.person.bolinasTile);
        }
    }

    private void OnMouseDrag() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.parent.transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
    }
}
