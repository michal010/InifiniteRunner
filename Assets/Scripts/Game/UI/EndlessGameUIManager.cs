using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[FromFactory("EndlessGameUIManager", true)]
public class EndlessGameUIManager : UIManager, IInjectable<LevelDistance>
{
    public ScoreDisplay scoreDisplay;
    public Button RestartButton;
    public LevelDistance levelDistance;
    public GameObject GameOverPanel;

    public void Inject(LevelDistance dependency)
    {
        levelDistance = dependency;
        scoreDisplay.Inject(levelDistance);
    }

    private void Awake()
    {
        scoreDisplay.levelDistance = levelDistance;

    }

    public void OnRestartButton()
    {
        GameManager.Instance.GameEvents.OnRestartGame();
    }

    public override void ShowGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }

}
