using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO ;
using Shell32;
using IWshRuntimeLibrary;
namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button2.Hide();

                string[] c = Assembly.GetExecutingAssembly().GetManifestResourceNames();
                if (System.IO .File.Exists("C:/ProgramData/locker/locklog.accdb"))
                {
                    System.IO.File.Delete("C:/ProgramData/locker/locklog.accdb");

                }
                FileStream db = new FileStream("C:/ProgramData/locker/locklog.accdb", FileMode.CreateNew);
                Stream a = Assembly.GetExecutingAssembly().GetManifestResourceStream("WindowsFormsApplication1.locklog.accdb");
                Stream b = Assembly.GetExecutingAssembly().GetManifestResourceStream("WindowsFormsApplication1.locker.exe");
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 2;
                int i = new int();




                progressBar1.Show();
                string path;
                path = "C:/ProgramData/locker/locker.exe";

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);

                }
                progressBar1.Value = 0;
                FileStream ap = new FileStream(path, FileMode.CreateNew);


                for (i = 0; i < b.Length; i++)
                {
                    ap.WriteByte((byte)b.ReadByte());

                }
                ap.Close();
                progressBar1.Value = 1;
                for (i = 0; i < a.Length; i++)
                {
                    db.WriteByte((byte)a.ReadByte());

                }
                db.Close();
                progressBar1.Value = 2;

                object shDesktop = (object)"Desktop";
                WshShell shell = new WshShell();
                string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\locker.lnk";
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                shortcut.Description = "New shortcut for a locker";
                shortcut.Hotkey = "Ctrl+Shift+l";
                shortcut.TargetPath = "C:/ProgramData/locker/locker.exe";
                shortcut.Save();


                MessageBox.Show(" installation completed");

                Form4 f = new Form4();
                f.ShowDialog();

                this.Hide();

            }
            catch (Exception u)
            {
                MessageBox.Show("error:"+u.Message );
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
