using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    [Header("Health Attribute")]
    public Attribute Health = new Attribute();

    [Header("Mana Attribute")]
    public Attribute Mana = new Attribute();

    [Header("Strength Attribute")]
    public Attribute Strength = new Attribute();

    [Header("Ability Attribute")]
    public Attribute Ability = new Attribute();

    private void Start()
    {
        Health.minAttributeValueAction += Dead;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Health.Subtract(10);
        }
    }

    public void Dead()
    {
        Debug.Log("You're dead!");
    }
}

[System.Serializable]
public class Attribute
{
    public delegate void MaximumAction();
    public delegate void MinimumAction();

    public event MaximumAction maxAttributeValueAction;
    public event MaximumAction minAttributeValueAction;
    public string AttributeName { get; set; }

    [SerializeField] private int _currenValue;
    [SerializeField] private int _minValue = 0;
    [SerializeField] private int _maxValue = 100;
    public Image AttributeImage;

    public int MinValue
    {
        get
        {
            return _minValue;
        }
        set
        {
            if (value > 0)
            {
                _minValue = value;
                SetImageValue();
                Debug.Log(MinValue);
            }
        }
    }

    public int MaxValue
    {
        get
        {
            return _maxValue;
        }
        set
        {
            if (value > 0)
            {
                _maxValue = value;
                SetImageValue();
                Debug.Log(MaxValue);
            }
        }
    }

    public void Add(int value)
    {
        if (value < 0)
        {
            return;
        }

        if (value + _currenValue > _maxValue)
        {
            _currenValue = _maxValue;

            if (maxAttributeValueAction != null)
            {
                maxAttributeValueAction();
            }
        }
        else
        {
            _currenValue += value;
        }
        SetImageValue();
    }

    public void Subtract(int value)
    {
        if (value < 0)
        {
            return;
        }

        if (_currenValue - value <= _minValue)
        {
            _currenValue = _minValue;

            if (minAttributeValueAction != null)
            {
                minAttributeValueAction();
            }
        }
        else
        {
            _currenValue -= value;
        }
        SetImageValue();
    }

    private void SetImageValue()
    {
        if (AttributeImage != null)
        {
            float imgValue = (float)_currenValue / (float)_maxValue;
            AttributeImage.fillAmount = imgValue;
        }
    }
}