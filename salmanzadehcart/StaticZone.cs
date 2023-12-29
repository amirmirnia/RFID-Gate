using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CardLib
{
    public static class MifareData
    {
        public static byte[] DLL_version = new byte[33];
        public static byte[] portN = new byte[4];
        public static byte[] Dver = new byte[33];
        public static byte Daddress;
        public static byte[] Dsn = new byte[8];
        public static byte[] cardT = new byte[3];
        public static byte[] cardSerialNumber = new byte[4];
        public static byte[] Ckey = new byte[6];
        public static byte[] databuffer = new byte[17];
        public static byte[] value = new byte[4];
        public static byte[] Dbuffer = new byte[64];
        public static void Reset()
        {
            DLL_version = new byte[33];
            portN = new byte[4];
            Dver = new byte[33];
            Dsn = new byte[8];
            cardT = new byte[3];
            cardSerialNumber = new byte[4];
            Ckey = new byte[6];
            databuffer = new byte[17];
            value = new byte[4];
            Dbuffer = new byte[64];
        }
    }
    public static class MifareAPI
    {
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern short MF_GetDLL_Ver(ref byte rVER);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_InitComm(string portname, int baud);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_ControlBuzyditdtyt(short DeviceAddr);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_ExitComm();
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_GetDevice_Ver(short DeviceAddr, ref byte ver);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_SetDeviceBaud(short DeviceAddr, int baud);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_SetDeviceAddr(short DeviceAddr, short addr);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_ControlLED(short DeviceAddr, short LED1, short LED2);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_GetDeviceAddr(short DeviceAddr, ref byte addr);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_SetDeviceSNR(short DeviceAddr, string snr);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_GetDeviceSNR(short DeviceAddr, ref byte snr);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_SetRF_ON(short DeviceAddr);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_SetRF_OFF(short DeviceAddr);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_Request(short DeviceAddr, short mode, ref byte CardType);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_Anticoll(short DeviceAddr, ref byte snr);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_Halt(short DeviceAddr);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_Select(short DeviceAddr, ref byte snr);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_LoadKey(short DeviceAddr, ref byte key);

        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_ControlBuzzer(short DeviceAddr, short BeepTime);

        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_LoadKeyFromEE(short DeviceAddr, short KeyType, short KeyNum);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_StoreKeyToEE(short DeviceAddr, short KeyAB, short KeyAdd, ref byte key);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_Authentication(short DeviceAddr, short AuthType, short block, ref byte snr);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_Read(short DeviceAddr, short block, short numbers, ref byte databuff);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_Write(short DeviceAddr, short block, short numbers, ref byte databuff);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_Value(short DeviceAddr, short valoption, ref byte value);
        [DllImport("MF_API.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int MF_Transfer(short DeviceAddr, short block);

        public static bool beepForOK()
        {
            if (MifareAPI.MF_ControlBuzzer(0, 0) == 0)
            {
                MifareAPI.MF_ControlLED(0, 1, 0);
                System.Threading.Thread.Sleep(20);
                MifareAPI.MF_ControlBuzzer(0, 2);
                System.Threading.Thread.Sleep(5);
                MifareAPI.MF_ControlBuzzer(0, 5);
                MifareAPI.MF_ControlLED(0, 0, 0);
                return true;
            }
            return false;
        }
        public static bool beepForDeny()
        {
            if (MifareAPI.MF_ControlBuzzer(0, 0) == 0)
            {
                MifareAPI.MF_ControlLED(0, 0, 1);
                MifareAPI.MF_ControlBuzzer(0, 10);
                System.Threading.Thread.Sleep(200);
                MifareAPI.MF_ControlLED(0, 0, 0);
                return true;
            }
            return false;
        }


        public static bool beepForDenylong()
        {
            if (MifareAPI.MF_ControlBuzzer(0, 0) == 0)
            {
                MifareAPI.MF_ControlLED(0, 0, 1);
                MifareAPI.MF_ControlBuzzer(0, 10);
                System.Threading.Thread.Sleep(20);
                MifareAPI.MF_ControlLED(0, 0, 0);
                return true;
            }
            return false;
        }


    }
    public static class SharedData
    {
        public static DateTime GlobalDateTime;
        public static AutoCompleteStringCollection NameList = new System.Windows.Forms.AutoCompleteStringCollection();
        public static AutoCompleteStringCollection FamilyList =new System.Windows.Forms.AutoCompleteStringCollection();
        public static AutoCompleteStringCollection FieldStudyList =new System.Windows.Forms.AutoCompleteStringCollection();
        public static List<string> GroupList = new List<string>();
    }
}
