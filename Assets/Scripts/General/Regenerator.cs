using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Regenerator : MonoBehaviour
{
    //Declarations
    [Tooltip("Used to differentiate btwn multiple regenerators that may exist on a single game object")]
    [SerializeField] private string _regeneratorName;

    [Tooltip("The amount to regenerate each tick")]
    [SerializeField] private float _regenRate = 0;

    [Tooltip("The amount of time in seconds btwn ticks. First tick happens once the regenerator activates")]
    [SerializeField] private float _regenTickDuration = 1;


    [SerializeField] private bool _isRegenerating = false;

    [Space(10)]
    public UnityEvent<float> OnRegenerationTick;


    //Monobehaviors






    //Utilities
    public void StartRegen()
    {
        if (_isRegenerating == false)
        {
            _isRegenerating = true;
            InvokeRepeating("TickRegeneration", 0, _regenTickDuration);
        }
    }

    public void StopRegen()
    {
        if (_isRegenerating)
        {
            _isRegenerating = false;
            CancelInvoke("TickRegeneration");
        }
    }

    private void TickRegeneration()
    {
        //Debug.Log("Regen Ticked");
        OnRegenerationTick?.Invoke(_regenRate);
    }


    public void SetRegenRate(float value)
    {
        if (value >= 0)
            _regenRate = value;
    }

    public void SetTickDuration(float value)
    {
        if (value > 0)
            _regenTickDuration = value;
    }

    public float GetRegenRate()
    {
        return _regenRate;
    }

    public float GetTickDuration()
    {
        return _regenTickDuration;
    }

    public bool IsRegenerating()
    {
        return _isRegenerating;
    }

    public string GetName()
    {
        return _regeneratorName;
    }
}
