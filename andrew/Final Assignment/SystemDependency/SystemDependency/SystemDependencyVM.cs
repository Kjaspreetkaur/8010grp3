using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemDependency
{
    public class SystemDependencyVM : INotifyPropertyChanged
    {
        private string _messages;
        private string _commandInput;
        private List<string> _outputList;
        //dictionary of dependencies <string, list<string>> OR <string,componentObj>
        private Dictionary<string, List<string>> Dependencies = new Dictionary<string, List<string>>();
        //dictionary of installed components
        private List<string> InstalledComponents = new List<string>();
        //list of messages thus far
        private List<string> ListMessages = new List<string>();

        public string Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
                NotifyPropertyChanged();
            }
        }
        public string CommandInput
        {
            get
            {
                return _commandInput;
            }
            set
            {
                _commandInput = value.ToLower();
                NotifyPropertyChanged();
                EchoActions();
            }
        }
        public List<string> OutputList
        {
            get
            {
                return _outputList;
            }
            set
            {
                _outputList = value;
                NotifyPropertyChanged();
            }
        }

        //read function
        public void GetInput()
        {
            ListMessages.Add(CommandInput);

            List<string> listOfParams = new List<string>();
            listOfParams = CommandInput.Split(' ').ToList();

            if (listOfParams[0] == "depend")
            {
                CommandInput = "";
                Messages = "Adding Dependencies";
                AddDependency(listOfParams);
            }
            else if(listOfParams[0] == "install")
            {
                CommandInput = "";
                Messages = "";
                InstallComponent(listOfParams[1]);
            }
            else if (listOfParams[0] == "remove")
            {
                CommandInput = "";
                Messages = "";
                RemoveComponent(listOfParams[1]);
            }
            else if (listOfParams[0] == "list")
            {
                CommandInput = "";
                Messages = "Displaying list of installed Components";
                ListInstalledComponents();
            }
            else if (listOfParams[0] == "end")
            {
                Messages = "Ending Component Installation";
            }
            else
            {
                Messages = "No command detected, no action taken";
            }
            OutputList = ListMessages;
        }

        //create a message for installing, kept repeating myself
        public void CreateMessage(string name)
        {
            ListMessages.Add("Installing " + name);
        }

        //add dependency
        public void AddDependency(List<string> list)
        {
            List<string> temp;
            int counter = 2;

            for (int i = 1; i < list.Count()-1; i++)
            {
                if (!(Dependencies.Keys.Contains(list[i])))
                {
                    temp = new List<string>();
                    for (int j = counter; j < list.Count(); j++)
                    {
                        temp.Add(list[j]);
                    }
                    Dependencies.Add(list[i], temp);
                }
                counter++;
            }
        }

        //install component
        public void InstallComponent(string name)
        {
            List<string> temp = null;
            if (InstalledComponents.Contains(name))
            {
                ListMessages.Add(name + " is already installed.");
            }
            else if (Dependencies.ContainsKey(name))
            {
                temp = Dependencies[name];
                //Messages = "Dependencies for: " + name + " ->" + temp.Count(); this works now'sd

                InstalledComponents.Add(name);
                CreateMessage(name);

                for (int i = 0; i < temp.Count(); i++)
                {
                    if (!(InstalledComponents.Contains(temp[i])))
                    {
                        InstalledComponents.Add(temp[i]);
                        CreateMessage(temp[i]);
                    }
                }
            }
            else
            {
                InstalledComponents.Add(name);
                CreateMessage(name);
            }
        }

        //this is to check the dependencies before an install
        public Boolean CheckDependency(string name)
        {
            Boolean flag = false;
            int count = Dependencies[name].Count();
            int numInstalled = 0;

            for (int i = 0; i < count; i++)
            {
                if (InstalledComponents.Contains(Dependencies[name][i]))
                {
                    numInstalled++;
                }
            }

            if (numInstalled == count)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        //remove component
        public void RemoveComponent(string name)
        {
            /*check dependencies, does the component to be deleted have dependencies?
             *   if yes:
             *       what are the those dependencies? - store them in a "to be deleted" list
             *   if no:
             *       "to be deleted" list only contains name
             *       
             *now, for every name in the "to be deleted" list, check if more than 1 exists in the list of installed components, and their dependencies
             *   if more than 1 exists
             *       do not delete
             *   if only <= 1
             *       delete the component
            */
            List<string> toBeDeleted = new List<string>();
            int found = 0;
            if (Dependencies.Keys.Contains(name))
            {
                toBeDeleted.Add(name);
                if (Dependencies[name].Count() > 1)
                {
                    for (int i = 0; i < Dependencies[name].Count(); i++)
                    {
                        toBeDeleted.Add(Dependencies[name][i]);
                    }
                }
                else
                {
                    toBeDeleted.Add(name);
                }
            }
            else
            {
                toBeDeleted.Add(name);
            }

            for (int k = toBeDeleted.Count(); k > 0; k--)
            {
                found = 0;

                foreach (string key in InstalledComponents)
                {
                    List<string> temp = new List<string>();
                    if (Dependencies.Keys.Contains(key))
                    {
                        temp = Dependencies[key];
                    }
                    
                    for (int j = 0; j < temp.Count(); j++)
                    {
                        if (temp[j] == toBeDeleted[k-1])
                        {
                            found++;
                        }
                    }
                }
                //the requested component being removed is found more than once, but it is not the only thing being deleted
                if (found > 1 && toBeDeleted.Count() > 1)
                {
                    //whatever is being deleted is still needed
                    //but it isn't the only one being deleted - so there is no message
                    continue;
                }
                else if (found > 1 && toBeDeleted.Count() == 1)
                {
                    //whatever is being deleted is still needed
                    //but there's only one, so there is a message
                    ListMessages.Add(toBeDeleted[k - 1] + " is still needed.");
                }
                //the requested component being removed is found once or not even there
                else if (found <= 1)
                {
                    //whatever is being deleted is not needed, since it only shows up once
                    InstalledComponents.Remove(toBeDeleted[k - 1]);
                    ListMessages.Add("Removing " + toBeDeleted[k - 1]);
                }
            }
        }

        //list installed components
        public void EchoActions()
        {
            OutputList = InstalledComponents;
        }

        public void ListInstalledComponents()
        {
            foreach (string name in InstalledComponents)
            {
                ListMessages.Add(name);
            }
            OutputList = ListMessages;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
