using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;

namespace RedGrimV2.Controllers
{
    public class BluetoothController
    {
        public static IBluetoothLE ble = CrossBluetoothLE.Current;
        public static IAdapter adp = CrossBluetoothLE.Current.Adapter;
        public static IDevice device;
        public static IService service;

        public static async Task<List<IDevice>> ScanForDevices()
        {
            List<IDevice> deviceList = new List<IDevice>();

            adp.DeviceDiscovered += (s, a) => deviceList.Add(a.Device);
            await adp.StartScanningForDevicesAsync();

            return deviceList;
        }

        public static async Task<string> ConnectDevice(IDevice selectedDevice)
        {

            //TODO: Combine these after testing each stage
            try
            {
                await adp.ConnectToDeviceAsync(selectedDevice);
                device = selectedDevice;
                return $"Connected successfully to {device.Name}";
            }
            catch (DeviceConnectionException e)
            {
                return $"Failed to connect to {selectedDevice.Name}: {e.Message}";
            }

            try
            {
                service = (IService)await device.GetServicesAsync();
            }
            catch(Exception e)
            {

            }

            try
            {
                ICharacteristic characteristic = (ICharacteristic)await service.GetCharacteristicsAsync();


                //TEST

                //Write
                byte[] writeBuffer = Encoding.ASCII.GetBytes("ATZ\r");
                await characteristic.WriteAsync(writeBuffer);


                //Read
                var read = await characteristic.ReadAsync();
                string data = Encoding.ASCII.GetString(read);


            }
            catch (Exception e)
            {

            }

            try
            {

            }
            catch(Exception e)
            {

            }


        }

        //public async Task WriteELMCommand(string input)
        //{
        //    try
        //    {
        //        byte[] writeBuffer = Encoding.ASCII.GetBytes(input);

        //        await

        //        await socket.OutputStream.WriteAsync(writeBuffer, 0, writeBuffer.Length);
        //        await socket.OutputStream.FlushAsync();

        //        await Task.Delay(elmDelay);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public async Task ReadELMCommands()
        //{
        //    try
        //    {
        //        byte[] readBuffer = new byte[512];
        //        int length = await socket.InputStream.ReadAsync(readBuffer, 0, readBuffer.Length);
        //        string data = Encoding.ASCII.GetString(readBuffer);

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

    }
}
