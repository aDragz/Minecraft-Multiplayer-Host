﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CraftForge.Server.Classes.Console.Initialize.Files.ContextMenus
{
    internal class UploadFile
    {
        public static void UploadFiles(FlowLayoutPanel panel, string directory, string serverName)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    try
                    {
                        File.Copy(file, directory + Path.GetFileName(file));
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("File already exists in the directory");
                    }
                }

                //Clear the panel
                panel.Controls.Clear();

                //Reinitialize the files
                AddFiles.initializeFiles(panel, directory, serverName);
            }
        }
    }
}
