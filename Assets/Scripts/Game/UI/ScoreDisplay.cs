using TMPro;
using UnityEngine;

[FromFactory("ScoreDisplay",true)]
public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI DistanceText;
    public TextMeshProUGUI ScoreText;

    public LevelDistance levelDistance;

    private void Update()
    {
        DistanceText.text = levelDistance.Distance.ToString(); 
    }
}
