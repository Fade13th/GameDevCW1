using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

    private float targetAlpha = 0;
    private CanvasGroup c;
    public float step = 0.1f;
    private bool bFade = false;

    private ControlScript control;
    private CharacterMovement movement;

    private void Start() {
        control = GameObject.Find("Player").GetComponent<ControlScript>();
        movement = GameObject.Find("Player").GetComponent<CharacterMovement>();

        c = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update () {

        if (bFade) {
            bFade = false;
            targetAlpha = 1f;
            StartCoroutine(waitToFade(1.5f));
        }

        if (c.alpha > targetAlpha) {
            c.alpha -= step;
        } else if (c.alpha < targetAlpha) {
            c.alpha += step;
        }

	}

    public void Fade() {
        this.bFade = true;

        control.enabled = false;
        movement.enabled = false;
    }

    private IEnumerator waitToFade(float time) {
        yield return new WaitForSeconds(time);
        targetAlpha = 0f;

        control.enabled = true;
        movement.enabled = true;
    }
}
