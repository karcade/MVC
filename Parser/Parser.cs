using WebApp.Model.DatabaseModels;
using System.Xml;

namespace Parser;

public class Parser
{
    public List<WorkTask> GetTasks()
    {
        var tasks = new List<WorkTask>();

        XmlDocument xDoc = new XmlDocument();
        xDoc.Load("data.xml");
        XmlElement? xRoot = xDoc.DocumentElement;
        if (xRoot != null)
        {
            foreach (XmlElement xnode in xRoot)
            {
                WorkTask task = new WorkTask();
                XmlNode? attr = xnode.Attributes.GetNamedItem("id");
                task.Id = attr?.Value;

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "description")
                        task.Description = childnode.InnerText;
                }
                tasks.Add(task);
            }
        }
        return tasks;
    }
    }
}