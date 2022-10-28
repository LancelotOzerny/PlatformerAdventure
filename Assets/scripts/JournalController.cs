using UnityEngine;
using System.Xml.Linq;

public class JournalController : MonoBehaviour
{
    [SerializeField] private GameObject _journal;

    [Header("Tasks")]
    [SerializeField] private TasksMeneger _taskMeneger;

    [SerializeField] private GameObject _taskPrefab;
    [SerializeField] private GameObject _unlockedTasksPage;
    [SerializeField] private GameObject _completedTasksPage;

    void Start()
    {
        _journal.SetActive(false);

        RewriteTasks();
    }

    public void RewriteTasks()
    {
        foreach (Task task in _taskMeneger.Tasks)
        {
            if (task.Status == Task.TaskStatus.Locked)
            {
                GameObject obj = Instantiate(_taskPrefab, _unlockedTasksPage.transform);
                obj.GetComponent<TaskController>().SetTask(task);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Cursor.visible = !_journal.activeSelf;

            _journal.SetActive(!_journal.activeSelf);
        }
    }
}

