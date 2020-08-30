using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private ThrowKnife throwKnife;
    private StageController stageController;
    public Slider knifesBar;
    public Text textScore;
    public Text textStage;
    public Text textMoney;

    public Text textMaxScore;
    public Text textMaxStage;


    void Start()
    {
        stageController = GameObject.Find("Manager").GetComponent<StageController>();
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

        textScore.text = "Score\n" + ScoreController.score.ToString();
        textStage.text = "Stage\n" + stageController.currentStage.ToString();
        textMoney.text = MoneyController.money.ToString();

        textMaxScore.text = "MaxScore\n" + ScoreController.maxScore.ToString();
        textMaxStage.text = "Stage\n" + StageController.maxStage.ToString();
    }
}
