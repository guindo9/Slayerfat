using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
            timer1.Stop();
            circularProgressBar1.Value = 0;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            timer2.Stop();
            circularProgressBar2.Value = 0;
            circularProgressBar2.Text = circularProgressBar2.Value.ToString();
        }
        //Activar boost 
        private void Button1_Click(object sender, EventArgs e)
        {
            Button1.Hide();
            circularProgressBar1.Show();
            timer1.Stop();
            circularProgressBar1.Value = 0;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            timer1.Start();
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C net stop FontCache & net stop SDRSVC & net stop wuauserv & net stop SysMain & net stop WbioSrvc & net stop WSearch & net stop DeviceAssociationService & exit"
            };
            process.StartInfo = startInfo;
            process.Start();

            Process proces = new Process();
            ProcessStartInfo startInf = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C net stop Themes & net stop DeviceAssociationService & net stop Dnscache & net stop TimeBroker & net stop VaultSvc & net stop UsoSvc & net stop wmiApSrv & net stop SgrmBroker & net stop Spooler & net stop wscsvc & net stop RmSvc & exit"
            };
            proces.StartInfo = startInf;
            proces.Start();

            Process proce = new Process();
            ProcessStartInfo startIn = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C net stop AppXSvs & net stop InstallService & net stop DisplayEnhancementService & net stop TabletInputService & net stop fsvc & net stop NVDisplay.ContainerLocalSystem & net stop AppXSvc & cd C:\Program Files\Game_Booster\Archivos & EmptyStandbyList.exe workingsets & EmptyStandbyList.exe modifiedpagelist & EmptyStandbyList.exe priority0standbylist & EmptyStandbyList.exe standbylist & exit"
            };
            proce.StartInfo = startIn;
            proce.Start();

            Process proc = new Process();
            ProcessStartInfo startI = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C net stop Winmgmt & net stop CryptSvc & net stop stisvc & net stop SmsRouter & net stop SENS & net stop FontCache & exit"
            };
            proc.StartInfo = startI;
            proc.Start();
        }

        //Restaurar Windows
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox1.Hide();
            circularProgressBar2.Show();
            timer2.Stop();
            circularProgressBar2.Value = 0;
            circularProgressBar2.Text = circularProgressBar2.Value.ToString();
            timer2.Start();
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C net start CryptSvc & net start Winmgmt & net start Themes & net start SysMain & net start WbioSrvc & net start WSearch & net start DeviceAssociationService & exit"
            };
            process.StartInfo = startInfo;
            process.Start();

            Process proces = new Process();
            ProcessStartInfo startInf = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C net start TimeBroker & net start VaultSvc & net start UsoSvc & net start wmiApSrv & net start SgrmBroker & net start Spooler & net start AppXSvs & net start InstallService & exit"
            };
            proces.StartInfo = startInf;
            proces.Start();

            Process proce = new Process();
            ProcessStartInfo startIn = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C net start FontCache & net start TabletInputService & net start fsvc & net start SmsRouter & net start SDRSVC & net start NVDisplay.ContainerLocalSystem & net start AppXSvc & exit"
            };
            proce.StartInfo = startIn;
            proce.Start();

            Process proc = new Process();
            ProcessStartInfo startI = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C net start DeviceAssociationService & net start Dnscache & net start DisplayEnhancementService & net start RmSvc & net start FontCache & net start wuauserv & net start wscsvc & net start SENS & exit"
            };
            proc.StartInfo = startI;
            proc.Start();
        }

        //Agregar juegos
        private void Button4_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"C:\Program Files\Game_Booster\Juegos");
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
                Filter = "Ver mas juegos (*.url)|*.url|Todos los juegos (*.lnk)|*.lnk",
                FilterIndex = 1,
            };

            if (buscar.ShowDialog() == DialogResult.OK)
            {
                Process.Start(buscar.FileName);
            }
        }

        //Abrir juego o aplicacion con boost activado
        private void Button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog
            {
                InitialDirectory = @"C:\Program Files\Game_Booster\Juegos",
                Title = "Game Booster",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "url",
                Filter = "Ver mas juegos (*.url)|*.url|Todos los juegos (*.lnk)|*.lnk",
                FilterIndex = 1,
            };

            if (buscar.ShowDialog() == DialogResult.OK)
            {
                Process.Start(buscar.FileName);
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = @"/C timeout /t 3 /nobreak & TASKKILL /IM explorer.exe /F & exit"
                };
                process.StartInfo = startInfo;
                process.Start();
            }
        }

        //Barra de titulo y botones
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Barratitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files\Game_Booster\Scrips\cerrar.vbs");
            Application.Exit();
        }
        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Paneles de botones
        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
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

        //Optimizar
        //Liberar Ram
        private void Button5_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C cd C:\Program Files\Game_Booster\Archivos & EmptyStandbyList.exe workingsets & EmptyStandbyList.exe modifiedpagelist & EmptyStandbyList.exe priority0standbylist & EmptyStandbyList.exe standbylist"
            };
            process.StartInfo = startInfo;
            process.Start();
            //se localiza el formulario buscandolo entre los forms abiertos 
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Messagebox);
            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }
            //sino existe la instancia se crea una nueva
            frm = new Messagebox();
            frm.Show();
        }
        //Limpiar archivos temporales
        private void Button3_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C RD /S /Q %temp% & md %temp% & md %temp% & rd C:\windows\TEMP /s /q & md C:\windows\TEMP & md C:\windows\TEMP & exit"
            };
            process.StartInfo = startInfo;
            process.Start();
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Messagebox);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            frm = new Messagebox();
            frm.Show(); ;
        }
        //Limpiar cache de actualizaciones
        private void Button11_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C rd C:\Windows\SoftwareDistribution\Download / s / q & md C:\Windows\SoftwareDistribution\Download & md C:\Windows\SoftwareDistribution\Download & exit"
            };
            process.StartInfo = startInfo;
            process.Start();
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Messagebox);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            frm = new Messagebox();
            frm.Show(); ;
        }
        //Refrescar conexiones de red
        private void Button9_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C ipconfig /release & ipconfig /renew & ipconfig /flushdns & netsh winsock reset & exit"
            };
            process.StartInfo = startInfo;
            process.Start();
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Messagebox);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            frm = new Messagebox();
            frm.Show();
        }
        //Prueba de velocidad de internet
        private void Button14_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = "cmd.exe",
                Arguments = @"/C mode con:cols=59 lines=20 & title Prueba de Velocidad de Internet & color 3 & cd C:\Program Files\Game_Booster\Archivos & cls & echo =========================================================== & speedtest.exe & echo. & echo =========================================================== & pause & exit"
            };
            process.StartInfo = startInfo;
            process.Start();
        }

        //Herramientas
        //Limpiar registro
        private void Button7_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C cd C:\Program Files\Game_Booster\Archivos & RegistryCleaner.exe & exit"
            };
            process.StartInfo = startInfo;
            process.Start();
        }
        //Limpiar disco
        private void Button8_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C cd C:\Program Files\Game_Booster\Archivos & DiskCleaner.exe & exit"
            };
            process.StartInfo = startInfo;
            process.Start();
        }
        //Administrador de procesos
        private void Button10_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C cd C:\Program Files\Game_Booster\Archivos & ProcessManager.exe & exit"
            };
            process.StartInfo = startInfo;
            process.Start();
        }
        //Monitoriar temperaturas
        private void Button12_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C cd C:\Program Files\Game_Booster\Archivos & OpenHardwareMonitor.exe & exit"
            };
            process.StartInfo = startInfo;
            process.Start();
        }
        //Desinstalar un programa
        private void Button15_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = @"/C cd C:\Program Files\Game_Booster\Archivos & Uninstaller.exe & exit"
            };
            process.StartInfo = startInfo;
            process.Start();
        }

        //Timers para animacion 
        private void Timer1_Tick(object sender, EventArgs e)
        {

            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            if (circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                circularProgressBar1.Value = 0;
                circularProgressBar1.Text = circularProgressBar1.Value.ToString();
                PictureBox1.Show();
                circularProgressBar1.Hide();
                Button13.Show();
                Button6.Hide();
                Button4.Hide();

                OpenFileDialog buscar = new OpenFileDialog
                {
                    InitialDirectory = @"C:\Program Files\Game_Booster\Juegos",
                    Title = "Game Booster",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "url",
                    Filter = "Ver mas juegos (*.url)|*.url|Todos los juegos (*.lnk)|*.lnk",
                    FilterIndex = 1,
                };

                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    Process.Start(buscar.FileName);
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd.exe",
                        Arguments = @"/C timeout /t 3 /nobreak & TASKKILL /IM explorer.exe /F & exit"
                    };
                    process.StartInfo = startInfo;
                    process.Start();
                }
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            circularProgressBar2.Value += 2;
            circularProgressBar2.Text = circularProgressBar2.Value.ToString();
            circularProgressBar2.Minimum = 0;
            circularProgressBar2.Maximum = 100;
            if (circularProgressBar2.Value == 100)
            {
                timer2.Stop();
                circularProgressBar2.Value = 0;
                circularProgressBar2.Text = circularProgressBar2.Value.ToString();
                Button1.Show();
                circularProgressBar2.Hide();
                Button6.Show();
                Button13.Hide();
                Button4.Show();
                Process.Start(@"C:\Program Files\Game_Booster\Scrips\cerrar.vbs");
            }
        }


    }
}





