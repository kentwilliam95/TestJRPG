using UnityEngine;

public class Range
{
    private float _max;
    private float _min;
    public float Value {get; private set;}
    public float OldValue{get; private set;}
    public float Max => _max;
    public float Min => _min;

    public Range(float value, float min, float max)
    {
        _min = min;
        _max = max;
        Value = value;
    }

    public Range(float value)
    {
        _min = 0;
        _max = 100;
        Value = value;
    }

    public void SetValue(float value)
    {
        OldValue = Value;
        Value = GetClampValue(value);
    }

    public float GetClampValue(float value)
    {
        return Mathf.Clamp(value, _min, _max);
    }

    public float GetMaxValue(float value)
    {
        return Mathf.Max(value, _min);
    }

    public float GetMinValue(float value)
    {
        return Mathf.Min(value, _max);
    }

    public void ChangeMinValue(float newMin)
    {
        _min = newMin;
    }

    public void ChangeMaxValue(float newMax)
    {
        _max = newMax;
    }
}