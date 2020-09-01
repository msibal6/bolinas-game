using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public List<BolinasTile> tilesOnFire;

    public void Spread() {
        foreach (BolinasTile tile in tilesOnFire.ToArray()) {
            foreach (BolinasTile neighbor in tile.neighbors) {
                bool spreads = Random.Range(0.0f, 1.0f) < 0.1f;
                if (neighbor != null && !tilesOnFire.Contains(neighbor) && spreads) {
                    //neighbor.SetFire();
                    //tilesOnFire.Add(neighbor);
                }
            }
        }
    }

}
