using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiBoardPerformMode
{
    public partial class Form1 : Form
    {
        public string MainDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MultiBoard";

        private KeyboardScanner _scanner = new KeyboardScanner();
        private List<Keyboard> _keyboards = new List<Keyboard>();

        public Form1()
        {
            InitializeComponent();
            startup();
        }

        private void startup()
        {
            //backgroundWorker1.CancelAsync();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _keyboards.Clear();
            _scanner.loadList(115200);
            loadBoards();
        }

        private void loadBoards()
        {
            if (!File.Exists(MainDirectory + @"\keyboards.inf"))
            {
                //create file
                if (!Directory.Exists(MainDirectory))
                {
                    Directory.CreateDirectory(MainDirectory);
                }

                File.Create(MainDirectory + @"\keyboards.inf").Close();
            }

            int counter = 0;
            string line;
            List<string> temp = new List<string>();
            string[] boards;

            // read main file
            //============================
            System.IO.StreamReader file =
                new System.IO.StreamReader(MainDirectory + @"\keyboards.inf");
            while ((line = file.ReadLine()) != null)
            {
                if (line != "")
                {
                    temp.Add(line);
                    counter++;
                }
            }

            boards = temp.ToArray();

            file.Close();

            //add boards
            //=================================

            foreach (var t in boards)
            {
                if (string.IsNullOrEmpty(t))
                {

                }
                else
                {
                    string[] splits = t.Split('|');

                    Keyboard obj = new Keyboard(MainDirectory + @"\" + splits[1] + ".inf");
                    string port = GetComByUuid(splits[0]);
                    if (port != "NONE")
                    {
                        obj.setup(port, 115200);
                        obj.start();
                    }
                    _keyboards.Add(obj);
                }
            }


        }

        private string GetComByUuid(string id)
        {
            int count = 0;
            foreach (string s in _scanner.Uuid)
            {
                if (s == id)
                {
                    string port = _scanner.Ports[count];
                    if (port != "NONE")
                    {
                        return port;
                    }
                }
                count++;
            }

            return "NONE";
        }
    }
}
