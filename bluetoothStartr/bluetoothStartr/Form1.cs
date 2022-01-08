using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using InTheHand.Net;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
      //  private static BluetoothEndPoint EP = new BluetoothEndPoint(BluetoothAddress.Parse("68:94:23:54:c2:ee"), BluetoothService.BluetoothBase);
        private static BluetoothEndPoint EP = new BluetoothEndPoint(BluetoothAddress.Parse("00:1A:7D:DA:71:15"), BluetoothService.BluetoothBase);   // "A4:17:31:CA:C3:4C"
        private static BluetoothClient BC = new BluetoothClient(EP);

        // The BT device that would connect
        //    private static BluetoothDeviceInfo BTDevice = new BluetoothDeviceInfo(BluetoothAddress.Parse("60:A1:0A:1D:12:BC"));
        private static List<BluetoothDeviceInfo> listBT = new List<BluetoothDeviceInfo>();
        private static List<bool> spojeno = new List<bool>();
        //private static BluetoothDeviceInfo BTDevice = new BluetoothDeviceInfo(BluetoothAddress.Parse("e0:63:e5:45:2c:8f"));
        //private static NetworkStream stream = null;
        //bool pripojeno = false;
        int k = 0;
        DateTime cas = DateTime.Now;
        DateTime timeStamp1;
        DateTime timeStamp2;

        public Form1()
        {
            InitializeComponent();
           
        //          timer1.Enabled = true;

    }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label2.Text = k.ToString();
            timeStamp1 = DateTime.Now;
            int i;
            for (i = 0; i < listBT.Count; i++) {
                //if (BluetoothSecurity.PairRequest(BTDevice.DeviceAddress, ""))
                if (BluetoothSecurity.PairRequest(listBT.ElementAt(i).DeviceAddress, ""))
                {
                    
                    listBox1.Items.Insert(0,"prošel pair request č. " + i);
                //if (!pripojeno)
                if (!spojeno.ElementAt(i))
                {
                    cas = DateTime.Now;
                    //listBox1.Items.Add("on " + cas.ToLongTimeString());
                    listBox1.Items.Insert(0, "pripojeno " + listBT.ElementAt(i).DeviceAddress + " cas: " + cas.ToLongTimeString());

                    //pripojeno = true;
                    spojeno.RemoveAt(i);
                    spojeno.Insert(i, true);
                    //label1.Text = "Pripojeno";
                    //label1.ForeColor = Color.Green;
                }
            }
            else
            {
                    listBox1.Items.Insert(0, "neprošel pair request č. " + i);
                    //if (pripojeno)
                if (spojeno.ElementAt(i))
                {
                    cas = DateTime.Now;
                    //pripojeno = false;
                    spojeno.RemoveAt(i);
                    spojeno.Insert(i, false);
                    //label1.Text = "Odpojeno";
                    //label1.ForeColor = Color.Red;
                    //listBox1.Items.Add("off " + cas.ToLongTimeString());
                    listBox1.Items.Insert(0, "odpojeno " + listBT.ElementAt(i).DeviceAddress + " cas: " + cas.ToLongTimeString());
                }
            }
            label2.Text = (k++).ToString();
            }
            timeStamp2 = DateTime.Now;
            listBox1.Items.Insert(0, i + " prubehu za " + (timeStamp2 - timeStamp1));
            i = 0;
    //                       if (BTDevice.Authenticated)
   //         label3.Text = BTDevice.Rssi.ToString();
            
      }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            listBox1.Items.Clear();
            listBT.Clear();
            spojeno.Clear();
            //cas = DateTime.Now;
            //listBox1.Items.Add("klik " + cas.ToLongTimeString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //BluetoothDeviceInfo BTDevice = new BluetoothDeviceInfo(BluetoothAddress.Parse("e0:63:e5:45:2c:8f"));
            //listBT.Add(BTDevice);  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBT.Clear();
            spojeno.Clear();

            //var btDiscoveredList = BC.DiscoverDevices(30, false, true, true);

            //foreach (var BTDevice in btDiscoveredList)
            //{
            //    listBT.Add(BTDevice);
            //    spojeno.Add(false);
            //}
            //listBox1.Items.Insert(0, listBT.Count);
            //foreach (var item in listBT)
            //{
            //    listBox1.Items.Insert(0, item.DeviceAddress);
            //}
            BluetoothDeviceInfo BTDevice = new BluetoothDeviceInfo(BluetoothAddress.Parse("c0:f4:e6:69:62:24")); // "e0:63:e5:45:2c:8f"
            listBT.Add(BTDevice);
            spojeno.Add(false);
            //BTDevice = new BluetoothDeviceInfo(BluetoothAddress.Parse("60:A1:0A:1D:12:BC"));
            //listBT.Add(BTDevice);
            //spojeno.Add(false);
        }
    }
}
