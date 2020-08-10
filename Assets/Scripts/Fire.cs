using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public List<BolinasTile> tilesOnFire;


    // TODO
    // How far can the player see the fire
    // ie obviously people can see fire in real life some distance away

    public void Spread() {
        foreach (BolinasTile tile in tilesOnFire.ToArray()) {
            foreach (BolinasTile neighbor in tile.neighbors) {
                if (neighbor != null && !tilesOnFire.Contains(neighbor)) {
                    neighbor.SetFire();
                    tilesOnFire.Add(neighbor);
                }
            }
        }
    }

}
