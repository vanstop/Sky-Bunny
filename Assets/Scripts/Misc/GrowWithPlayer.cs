using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowWithPlayer : MonoBehaviour {

	void Update () {
        transform.localScale = Player.Current.transform.localScale;
	}
}
