using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Villager : MonoBehaviour
{
    [SerializeField] protected CreatureType _creatureType = CreatureType.Blue;
    [SerializeField] protected Status _status = new Status();

    protected ActionType _actionType = ActionType.Recon;
    protected CarriedObject _carriedObject = CarriedObject.None;

    protected float _nextActionTime = 0.0f;
    protected Rigidbody2D _rb;

    protected void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    protected void Start()
    {
        VillagerController.Instance.RegisterVillager(this);
    }

    public void SetNextActionTime(float inNextActionTime)
    {
        _nextActionTime = inNextActionTime;
    }

    public bool AdvanceTimeStep(float deltaTime)
    {
        _nextActionTime -= deltaTime;
        return _nextActionTime <= 0.0f;
    }

    public void DetermineActionType()
    {

    }

    public void Act()
    {
        
    }
}
