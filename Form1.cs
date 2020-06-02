using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.IO;

namespace pruevabooster1
{
    public partial class Form1 : Form
    {
        public string InitialDirectory { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
            //Activar boost 
        private void Button1_Click(object sender, EventArgs e)
        {
            button2.Show();
            Button1.Hide();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C TASKKILL /IM explorer.exe /F & net stop wuauserv & net stop SENS & net stop CryptSvc & net stop Winmgmt & net stop Themes & net stop SysMain & net stop stisvc & net stop FontCache & net stop WbioSrvc & net stop WSearch & net stop EventSystem & net stop DeviceAssociationService & net stop DeviceAssociationService & net stop Dnscache & net stop TimeBroker & net stop VaultSvc & net stop UsoSvc & net stop wmiApSrv & net stop SgrmBroker & net stop Spooler & net stop wscsvc & net stop RmSvc & net stop AppXSvs & net stop InstallService & net stop DisplayEnhancementService & net stop TabletInputService & net stop fsvc & net stop SmsRouter & net stop SDRSVC & net stop NVDisplay.ContainerLocalSystem & net stop AppXSvc & cd C:\Program Files\Game_Booster\Archivos & EmptyStandbyList.exe workingsets & EmptyStandbyList.exe modifiedpagelist & EmptyStandbyList.exe priority0standbylist & EmptyStandbyList.exe standbylis & exit";
            process.StartInfo = startInfo;
            process.Start();
            OpenFileDialog buscar = new OpenFileDialog
            {
                InitialDirectory = @"C:\Program Files\Game_Booster\Juegos",
                Title = "Game Booster",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "url",
                Filter = "Todos los juegos (*.*)|*.*|Ver mas juegos (*.url)|*.url",
                FilterIndex = 2,             
            };

            if (buscar.ShowDialog() == DialogResult.OK)
            {
                Process.Start(buscar.FileName);
            }
        }
        //Restaurar Windows
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Button1.Show();
            button2.Hide();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C cd C:\Windows & start explorer.exe & net start wuauserv & net start SENS & net start CryptSvc & net start Winmgmt & net start Themes & net start SysMain & net start stisvc & net start FontCache & net start WbioSrvc & net start WSearch & net start EventSystem & net start DeviceAssociationService & net start DeviceAssociationService & net start Dnscache & net start TimeBroker & net start VaultSvc & net start UsoSvc & net start wmiApSrv & net start SgrmBroker & net start Spooler & net start wscsvc & net start RmSvc & net start AppXSvs & net start InstallService & net start DisplayEnhancementService & net start TabletInputService & net start fsvc & net start SmsRouter & net start SDRSVC & net start NVDisplay.ContainerLocalSystem & net start AppXSvc & cd C:\Program Files\Game_Booster\Archivos & EmptyStandbyList.exe workingsets & EmptyStandbyList.exe modifiedpagelist & EmptyStandbyList.exe priority0standbylist & EmptyStandbyList.exe standbylis & exit";
            process.StartInfo = startInfo;
            process.Start();

        }
        //Agregar juegos
        private void Button4_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"C:\Program Files\Game_Booster\Juegos");
        }
         //Liberar Ram
        private void Button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C cd C:\Program Files\Game_Booster\Archivos & EmptyStandbyList.exe workingsets & EmptyStandbyList.exe modifiedpagelist & EmptyStandbyList.exe priority0standbylist & EmptyStandbyList.exe standbylist";
            process.StartInfo = startInfo;
            process.Start();
        }
         //Abrir juego o aplicacion
        private void Button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog
            {
                InitialDirectory = @"C:\Program Files\Game_Booster\Juegos",
                Title = "Game Booster",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "url",
                Filter = "Todos los juegos (*.*)|*.*|Ver mas juegos (*.url)|*.url",
                FilterIndex = 2,
            };

            if (buscar.ShowDialog() == DialogResult.OK)
            {
                Process.Start(buscar.FileName);
            }
        }

        //Barra de titulo y botones
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Barratitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
          
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files\Game_Booster\Scrips\cerrar.vbs");
            Application.Exit();
        }
        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

         //Paneles de botones
        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

         //Propiedades de boton para imagen de restaurar
        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void PictureBox1_MouseHover(object sender, EventArgs e)
        {

        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {

        }
          //Limpiar archivos temporales
        private void Button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C RD /S /Q %temp% & md %temp% & md %temp% & rd C:\windows\TEMP /s /q & md C:\windows\TEMP & md C:\windows\TEMP";
            process.StartInfo = startInfo;
            process.Start();

        }
        
        
    }
}
       

        
    

