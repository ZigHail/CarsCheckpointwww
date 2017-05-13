using CarsCheckpoint.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsClient.BussisessLogic;
using WindowsClient.BussisessLogic.Admin;

namespace WindowsClient
{
    public partial class Form1 : Form
    {
        List<AdminSettings> adminSettings;
        public Form1()
        {
            InitializeComponent();
            adminSettings = Server.GetSettings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (adminSettings.Count != 0)
            {
                var portName = adminSettings.FirstOrDefault(a => a.Name == AdminSettingsNames.USBPort).Value;
                if (portName != null)
                {
                    arduinoPort.PortName = portName;
                    arduinoPort.Open();
                }
            }
            

            string ExePath = Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            reg.SetValue("CarCheckpoint", ExePath);
            reg.Close();
        }

        private void cardTextBox_TextChanged(object sender, EventArgs e)
        {
            if (cardTextBox.Text.Length == 10)
            {
                var card = cardTextBox.Text;
                Reset();              
                var user = BussisessLogic.User.Server.GetUser(card);
                if (user.User == null)
                {
                    errorLabel.Text = "Unknown user";
                    return;
                }
                else
                {
                    nameLabel.Text = user.User.Name;
                }
                
            }
        }

        private void Reset()
        {
            cardTextBox.Text = "";
            nameLabel.Text = "";
            surnameLabel.Text = "";
            garageLabel.Text = "";
            carLabel.Text = "";
            balanceLabel.Text = "";
            errorLabel.Text = "";
        }
    }
}
