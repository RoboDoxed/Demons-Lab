using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace idk
{
    class vCk_resource
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        public static void vC()
        {
            if (GetModuleHandle("SbieDll.dll").ToInt32() != 0)
            {
                vCk = true;
                return;
            }
            try
            {
                try
                {
                    using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
                    {
                        using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
                        {
                            foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
                            {
                                string text = managementBaseObject["Manufacturer"].ToString().ToLower();
                                if ((text == "microsoft corporation" && managementBaseObject["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL")) || text.Contains("vmware") || managementBaseObject["Model"].ToString().ToLower() == "virtualbox")
                                {
                                    vCk = true;
                                    return;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    vCk = false;
                }
                const string ar = "12:03:33:4A:04:AF";
                ArrayList mac = new ArrayList();
                ManagementClass manager = new ManagementClass("Win32_NetworkAdapterConfiguration");
                foreach (ManagementObject obj in manager.GetInstances())
                {

                    if ((bool)obj["IPEnabled"])
                    {
                        mac.Add(obj["MacAddress"].ToString());
                    }
                }
                for (int i = 0; i < mac.Count; i++)
                {
                    if (ar != mac[0].ToString())
                    {
                        if (i == mac.Count - 1)
                        {
                            vCk = false;
                            return;
                        }
                    }
                    else
                    {
                        vCk = true;
                        return;
                    }
                }
                vCk = true;
            }
            catch { if (vCk != true) return; }
        }
        public static bool vCk = false;
    }
}
