using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BolinasTile : MonoBehaviour
{
    enum TrafficStatus { Light, Medium, Heavy};
    public string terrain;
    public bool autoPopulateNeighbors = true;
    public BolinasTile[] neighbors;
    public int offset { get; private set; }
    private TrafficStatus trafficStatus;
    public bool onFire { get; private set;}
    private bool blocked;


    private void Start() {
        if (autoPopulateNeighbors) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, 5);
            AssignNeighbor(hit, 0);
            hit = Physics2D.Raycast(transform.position, transform.up, 5);
            AssignNeighbor(hit, 1);
            hit = Physics2D.Raycast(transform.position, transform.right, 5);
            AssignNeighbor(hit, 2);
            hit = Physics2D.Raycast(transform.position, -transform.up, 5);
            AssignNeighbor(hit, 3);
        }
    }

    private void AssignNeighbor(RaycastHit2D hit, int neighbor) {
        if (hit.collider == null) {
            ;
        } else {
            neighbors[neighbor] = hit.collider.gameObject.GetComponentInChildren<BolinasTile>();
        }
    }
    private void Update() {
        Debug.DrawRay(transform.position, -transform.right);
        //print(transform.right);
    }

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
        // TODO 
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

    void OnDrawGizmos() {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        //Gizmos.DrawLine(transform.position, transform.up);
    }

}
