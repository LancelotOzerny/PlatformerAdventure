using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    [SerializeField] private Text _title;
    [SerializeField] private Text _description;

    void Start()
    {
        _title.text = "Title";
        _description.text = "Description";
    }

    public void SetTask(Task task)
    {
        _title.text = task.Title;
        _description.text = task.Description;
    }
}
