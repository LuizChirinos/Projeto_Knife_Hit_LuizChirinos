using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private ThrowKnife throwKnife;
    public Slider knifesBar;
    public Text textScore;

    void Start()
    {
        throwKnife = GetComponent<ThrowKnife>();
        throwKnife.onThrow += UpdateUI;

        foreach (ThrowableEntity knife in throwKnife.knifesStorage)
        {
            knife.ontargetHit += UpdateUI;
        }

        knifesBar.maxValue = throwKnife.knifesStorage.Length;
        UpdateUI();
    } 
    public void UpdateUI()
    {
        int knifeLeft = throwKnife.GetKnifesLeft();
        knifesBar.value = knifeLeft;

        textScore.text = ScoreController.score.ToString();
    }
}
