using Assets.Scripts.Core.Model.QuestModel;
using UnityEngine;

[CreateAssetMenu(fileName = "ConfigQuest", menuName = "config/configQuest")]
public class QuestConfig : ScriptableObject
{
    [SerializeField] Sprite SpriteQuest;
    [SerializeField] int DangerLevelQuest;
    [SerializeField] int GoldQuest;
    [SerializeField] int ExperienseQuest;
    [SerializeField] string NameQuest;
    [SerializeField] float QuestAllTime;



    public QuestModel GetQuestModel()
    {
        QuestModel Quest1 = new QuestModel(SpriteQuest, DangerLevelQuest, ExperienseQuest, GoldQuest, NameQuest, QuestAllTime);
        return Quest1;
    }
}
