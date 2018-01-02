/*System Dependencies - Final Assignment - GRP 3
 * Archit A.    8024168
 * Parthik M.   8050213
 * Jerome S.    8055907
 * Jaspreet K.  8051666
 * Andrew H.    8113730
 * Bhumi S.     8022584
 */
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemDependencies
{
    class VM : INotifyPropertyChanged
    {
        List<string> dependencies = new List<string>();
        List<string> installedDep = new List<string>();
        bool[,] dep_matrix = new bool[20,20];

        private string _inputs;
        public string Inputs
        {
            get { return _inputs; }
            set { _inputs = value; NotifyPropertyChanged(); }
        }

        private string _outputs;
        public string Outputs
        {
            get { return _outputs; }
            set { _outputs = value; NotifyPropertyChanged(); }
        }

        private string _command;
        public string Command
        {
            get { return _command; }
            set { _command = value; NotifyPropertyChanged(); }
        }

        public void ReadArguments(string comm=null)
        {
            //Check the command comming from file or from textbox
            string sanitizedCommand = (comm==null)?Command.Trim().ToUpper():comm.Trim().ToUpper();
                
            Inputs += sanitizedCommand + "\n";
            string[] tokens = sanitizedCommand.Split(null);

            switch (tokens[0])
            {
                case "DEPEND":
                    AddDependency(tokens,sanitizedCommand);
                    break;
                case "INSTALL":
                    InstallDependency(tokens,sanitizedCommand);
                    break;
                case "LIST":
                    ListDependency(tokens,sanitizedCommand);
                    break;
                case "REMOVE":
                    RemoveDependency(tokens,sanitizedCommand);
                    break;
                case "END":
                    Outputs += "END";
                    break;
                default:
                    ShowError();
                    break;
            }
        }

        public void AddDependency(string[] tokens,string sanitizedCommand)
        {
            if (tokens.Length > 2)
            {
                //For every package: Add package to dependency list and add dependency in dependency matrix
                for(int i = 1; i < tokens.Length; i++)
                {
                    if(!dependencies.Contains(tokens[i]))
                        dependencies.Add(tokens[i]);
                    dep_matrix[dependencies.IndexOf(tokens[1]), dependencies.IndexOf(tokens[i])] = true;
                }

                //Remove self dependency for a package
                dep_matrix[dependencies.IndexOf(tokens[1]), dependencies.IndexOf(tokens[1])] = false;
                Outputs += sanitizedCommand + "\n";
            }
            else
            {
                ShowError("Wrong Argument List");
            }
        }

        public void InstallDependency(string[] tokens,string sanitizedCommand=null)
        {
            if (tokens.Length == 2 && sanitizedCommand!=null)
            {
                Outputs += sanitizedCommand + "\n";
                
                //Check if dependency is not installed but dependency list has its value
                if (!installedDep.Contains(tokens[1]) && dependencies.Contains(tokens[1]))
                {
                    int key = dependencies.IndexOf(tokens[1]);
                    for(int i = 0; i < dependencies.Count; i++)
                    {
                        if (dep_matrix[key, i])
                        {
                            string[] temp_arr = new string[]{ "INSTALL", dependencies[i] };

                            //Install dependencies
                            InstallDependency(temp_arr);
                        }
                    }

                    Outputs += "\t" + "Installing " + tokens[1] + "\n";
                    installedDep.Add(tokens[1]);
                }
                else if (!installedDep.Contains(tokens[1]) && !dependencies.Contains(tokens[1]))
                {
                    //In case package has no dependency and is not installed e.g. foo
                    Outputs += "\t" + "Installing " + tokens[1] + "\n";
                    installedDep.Add(tokens[1]);
                }
                else
                {
                    Outputs += "\t" + tokens[1] + " is already installed.\n";
                }
            }
            else if (tokens.Length == 2 && sanitizedCommand == null)
            {
                //For the case when function is called within
                if (!installedDep.Contains(tokens[1]))
                {
                    Outputs += "\t" + "Installing " + tokens[1] + "\n";
                    installedDep.Add(tokens[1]);
                }
            }
            else
            {
                ShowError("Wrong Argument List");
            }
        }

        public void ListDependency(string[] tokens,string sanitizedCommand)
        {
            if (tokens.Length == 1)
            {
                Outputs += sanitizedCommand + "\n";
                foreach(string item in installedDep)
                {
                    Outputs += "\t" + item + "\n";
                }
            }
            else
            {
                ShowError("Wrong Arguments");
            }
        }

        public void RemoveDependency(string[] tokens,string sanitizedCommand=null)
        {
            bool flag = false;
            if (tokens.Length == 2 && sanitizedCommand != null && installedDep.Contains(tokens[1]))
            {
                int packageIndex = dependencies.IndexOf(tokens[1]);
                Outputs += sanitizedCommand + "\n";

                //Check the column for dependencies
                for(int i = 0; i < dependencies.Count; i++)
                {
                    if (dep_matrix[i, packageIndex])
                    {
                        flag = true;
                    }
                }

                if (flag)
                {
                    Outputs += "\t" + tokens[1] + " is still needed.\n";
                }
                else
                {
                    Outputs += "\tRemoving " + tokens[1] + "\n";
                    for(int i = 0; i < dependencies.Count; i++)
                    {
                        int counter = 0;
                        //check dependency of current
                        if (dep_matrix[packageIndex, i])
                        {
                            //Check every dependency for dependencies other than current
                            for(int j = 0; j < dependencies.Count; j++)
                            {
                                if (dep_matrix[j,i])
                                {
                                    counter++;
                                }
                            }
                            if (counter<=1)
                            {
                                Outputs += "\tRemoving " + dependencies[i] + "\n";
                                //Remove dependency and set the row to false
                                installedDep.Remove(dependencies[i]);
                                for (int x = 0; x < dependencies.Count; x++)
                                {
                                    dep_matrix[x,packageIndex] = false;
                                }
                            }
                        }
                    }
                    //Works for both cases if dependency has another dependency or a standalone package 
                    //Remove dependency and set the column to false
                    installedDep.Remove(tokens[1]);
                    for(int i = 0; i < dependencies.Count; i++)
                    {
                        dep_matrix[packageIndex, i] = false;
                    }
                }
            }
            else if (!installedDep.Contains(tokens[1]))
            {
                Outputs += sanitizedCommand + "\n";
                Outputs += "\t" + tokens[1] + " is not installed.\n";
            }
            else
            {
                ShowError("Wrong Argument List");
            }
        }

        public void ShowError(string error="Wrong Command")
        {
            Inputs += error + "\n";
        }

        public void SimulateFromFile()
        {
            string line = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                while (line!=null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        ReadArguments(line);
                    } 
                }
            }      
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
