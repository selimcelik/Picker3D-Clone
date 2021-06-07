using UnityEngine;
using ManagerActorFramework;

public class GameData : Entity<GameData>
{
    #region Variables

    public int Level = 0;

    #endregion


    protected override bool Init()
    {
        return true;
    }

    public void UpdateLevel(int level)
    {
        Level = level;
        Save();
    }
}
