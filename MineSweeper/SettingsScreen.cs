﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace MineSweeper
{
    public partial class SettingsScreen : Form
    {

        public SettingsScreen()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;//убираем кнопки навигации сверху
            StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            SaveSettingsButton.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            SaveSettingsButton.BackColor = Color.Gray;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
            SoundPlayer SPEsc = new SoundPlayer(Properties.Resources.ESC);
            SPEsc.Play();
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
          
            SoundPlayer SPDone = new SoundPlayer(Properties.Resources.DONE);
            SPDone.Play();
            string path = GlobalData.DifficultSetting;
            string path1 = GlobalData.ColorForm;

            StreamWriter writer = null;
            StreamWriter writer1 = null;

            switch (ColorComboBox.SelectedIndex)
            {
                case 0: //красный
                    this.BackColor = Color.Red;
                    break;

                case 1: //голубой
                    this.BackColor = Color.DarkGoldenrod;
                    break;

                case 2: //жёлтый
                    this.BackColor = Color.DarkCyan;
                    break;

                case 3: //системный
                    this.BackColor = Color.White;
                    break;
                case 4: //серый
                    this.BackColor = Color.Honeydew;
                    break;
            }

            try
            {
                writer = new StreamWriter(path, false, Encoding.Default);
                writer.WriteLine(DifficultyComboBox.SelectedIndex);
                writer.Close();

                writer1 = new StreamWriter(path1, false, Encoding.Default);
                writer1.WriteLine(ColorComboBox.SelectedIndex);
                writer1.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка при сохранении файла");
            }
            finally
            {
                if (writer != null)
                    writer.Dispose();

                if (writer1 != null)
                    writer1.Dispose();
            }
        }

        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SoundPlayer SPDone = new SoundPlayer(Properties.Resources.DONE);
            SPDone.Play();
        }

        private void DifficultyComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SoundPlayer SPDone = new SoundPlayer(Properties.Resources.DONE);
            SPDone.Play();
        }
        
    }
}