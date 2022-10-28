using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine.UI;
using System;

public class TasksMeneger : MonoBehaviour
{
    [SerializeField] private string xmlPath = string.Empty;
    [SerializeField] private List<Task> _tasks = new List<Task>();
    public List<Task> Tasks { get { return _tasks; } }

    // Start is called before the first frame update
    void Start()
    {
        Load(); 
    }

    private void Load()
    {
        _tasks.Clear();

        if (xmlPath == string.Empty)
        {
            return;
        }

        XElement data = XElement.Load(xmlPath);
        if (data == null)
        {
            return;
        }

        foreach (XElement task in data.Elements())
        {
            _tasks.Add(new Task(
                task.Attribute("Title").Value,
                task.Attribute("Description").Value,
                Convert.ToInt32(task.Attribute("Status").Value)
            ));
        }
    }

    public void Save()
    {
        if (xmlPath == string.Empty)
        {
            return;
        }

        XElement data = new XElement("Tasks");

        foreach (Task task in _tasks)
        {
            XElement element = new XElement("Task");
            
            element.SetAttributeValue("Title", task.Title);
            element.SetAttributeValue("Description", task.Description);
            element.SetAttributeValue("Status", ((int)task.Status).ToString());

            data.Add(element);
        }

        data.Save(xmlPath);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Save();
        }
    }
}


[System.Serializable]
public class Task
{
    public enum TaskStatus { Unlocked, Locked, Completed, Failed }

    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private TaskStatus _status = TaskStatus.Unlocked;

    public string Title { get { return _title; } }
    public string Description { get { return _description; } }
    public TaskStatus Status { get { return _status; } }

    public Task(string title, string description, int statusCode)
    {
        _title = title;
        _description = description;
        _status = (TaskStatus)statusCode;
    }
}
