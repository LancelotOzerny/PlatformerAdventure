using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public enum TaskStatus { Unlocked, Locked, Completed, Failed }

    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private Image _icon;
}
