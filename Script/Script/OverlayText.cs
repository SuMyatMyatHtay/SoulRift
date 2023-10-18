using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverlayText : MonoBehaviour
{
    public string NewText;
    public TextMeshProUGUI overlayText;
    public bool show;

    private void Start()
    {
        overlayText.enabled = false;
    }

    public void UpdateText()
    {
       StartCoroutine( countdownText());
       
    }

    private IEnumerator countdownText()
    {
        overlayText.enabled = show;
        overlayText.text = NewText;
        yield return new WaitForSeconds(4f);
        overlayText.enabled = false;
        overlayText.text = "";

    }
}
