using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Newt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (IntPtr.Size != 8)
            {
                MessageBox.Show("This program cannot run on 32 Bit versions of Windows.");
                return;
            }

            string ConfigPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"/config";

            if (File.Exists(ConfigPath))
            {
                Globals.Python = File.ReadAllText(ConfigPath);
            }
            else
                Globals.Python = Environment.GetEnvironmentVariable("PYTHONHOME");

            bool ProperPathFound = false;

            while (!ProperPathFound)
            {
                if (Globals.Python == "Cancelled")
                    return;

                if (Globals.Python == "")
                {
                    MessageBox.Show("Couldn't find the PYTHONHOME variable. Please select your Python 3.6 x64 installation.");
                    SelectPythonPath();

                    if (Globals.Python == "Cancelled")
                        return;
                }

                if (File.Exists(Globals.Python + @"\Python36.dll"))
                    ProperPathFound = true;
                else
                {
                    MessageBox.Show("Couldn't find Python36.dll. Select a proper Python 3.6 x64 path");
                    SelectPythonPath();
                }
            }

            try
            {
                Python.Runtime.PythonEngine.PythonHome = Globals.Python;
                Python.Runtime.PythonEngine.Initialize();
            }
            catch
            {
                MessageBox.Show("Couldn't initialize the Python Engine. Check your Python installation.");
                return;
            }

            using (Python.Runtime.Py.GIL())
            {
                using (Python.Runtime.PyScope scope = Python.Runtime.Py.CreateScope())
                {
                    try
                    {
                        scope.Exec("import ndspy.texture");
                    }
                    catch
                    {
                        MessageBox.Show("ndspy wasn't detected. Please run \"py -3.6 -m pip install ndspy\" from the command line to install it.");
                        return;
                    }
                }
            }

            if (File.Exists(ConfigPath))
                File.Delete(ConfigPath);

            FileStream f = File.Create(ConfigPath);
            f.Close();
            File.WriteAllText(ConfigPath, Globals.Python);

            string Filename = "";

            if (args.Count() != 0)
                Filename = args[0];


            Newt_MainWindow Main = new Newt_MainWindow(Filename);
            Main.BringToFront();
  
            Application.Run(Main);

            Python.Runtime.PythonEngine.Shutdown();
        }

        private static void SelectPythonPath()
        {
            using (var FBDialog = new FolderBrowserDialog())
            {
                DialogResult result = FBDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(FBDialog.SelectedPath))
                {
                    Globals.Python = FBDialog.SelectedPath;
                }
                else
                    Globals.Python = "Cancelled";
            }
        }
    }
}