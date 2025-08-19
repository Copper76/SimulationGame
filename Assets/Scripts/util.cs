public enum ActionType
{
    Recon,
    Collect,
    Produce,
    Combat,
    Flee,
}

public enum CarriedObject
{
    None,
    Food,
    Material,
    Weapon
}

[System.Serializable]
public struct Status
{
    public int HitPoint;
    public int Attack;
    bool IsDead;
}

public enum CreatureType
{
    Blue,
    Red, 
    Yellow
}
