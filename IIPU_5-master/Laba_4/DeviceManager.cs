using System;
using System.Collections.Generic;
using System.Management;

namespace Laba_5
{
    class DeviceManager
    {
        public List<Device> DeviseListCreate()
        {
            List<Device> devices = new List<Device>();
            var deviceList = new ManagementObjectSearcher("\\\\.\\root\\cimv2", "SELECT * FROM Win32_PnPEntity");
            foreach (ManagementObject item in deviceList.Get())
            {
                var tempDevice = new Device();
                string[] propertyArray = {"ClassGUID", "HardwareID", "Manufacturer", "Caption", "DeviceID"};
                var driver = item.GetRelated("Win32_SystemDriver");
                foreach (string property in propertyArray)
                {
                    if (item[property] != null)
                    {
                        switch (property)
                        {
                            case "ClassGUID":
                                tempDevice.Guid = item["ClassGuid"].ToString();
                                break;
                            case "HardwareID":
                                tempDevice.HardwareId = String.Join("\r\n", (string[])item["HardwareID"]);
                                break;
                            case "Manufacturer":
                                tempDevice.Manufacturer = item["Manufacturer"].ToString();
                                break;
                            case "Caption":
                                tempDevice.Provider = item["Caption"].ToString();
                                break;
                            case "DeviceID":
                                tempDevice.DevicePath = item["DeviceID"].ToString();
                                break;
                        }        
                    }
                }
                
                foreach (var driverProperty in driver)
                {
                    tempDevice.DriverDescription += driverProperty["Description"];
                    tempDevice.SysPath += driverProperty["PathName"];
                }
                tempDevice.Status = item["Status"].ToString();
                devices.Add(tempDevice);
            }
            return devices;
        }
    }
}
