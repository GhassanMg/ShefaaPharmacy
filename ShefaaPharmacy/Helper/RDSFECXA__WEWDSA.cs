using Microsoft.Win32;
using ShefaaPharmacy.GeneralUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShefaaPharmacy.Helper
{
    /// <summary>
    ///  Activation Key And Reg  
    /// </summary>
    public class RDSFECXA__WEWDSA
    {
        private static ManagementObjectSearcher baseboardSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

        private static ManagementObjectSearcher motherboardSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_MotherboardDevice");
        private static object hashBytes;

        public static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // "x2" for lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public static string EncodeForRegistry(string phrase)
        {

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(phrase);
            return System.Convert.ToBase64String(plainTextBytes);

        }


        public static string DecodeForRegistry(string phrase)
        {

            var base64EncodedBytes = System.Convert.FromBase64String(phrase);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

        }


        private static void Wr(string vifisdf, string sre, string nkey, string regDate, string expDate)
        {
            RegistryKey SoftWarekey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey MTAppkey = SoftWarekey.CreateSubKey(ConnectionManager.ApplicationName);
            vifisdf = EncodeForRegistry(vifisdf);
            sre = EncodeForRegistry(sre);
            nkey = EncodeForRegistry(nkey);
            regDate = EncodeForRegistry(regDate);
            expDate = EncodeForRegistry(expDate);

            MTAppkey.SetValue("UserKey", vifisdf);
            MTAppkey.SetValue("UserNKey", nkey);
            MTAppkey.SetValue("CorKey", sre);
            MTAppkey.SetValue("sDate", regDate);
            MTAppkey.SetValue("eDate", expDate);

        }
        private static void Wr(string vifisdf, string sre, string nkey)
        {
            RegistryKey SoftWarekey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey MTAppkey = SoftWarekey.CreateSubKey(ConnectionManager.ApplicationName);
            vifisdf = EncodeForRegistry(vifisdf);
            sre = EncodeForRegistry(sre);
            nkey = EncodeForRegistry(nkey);

            MTAppkey.SetValue("UserKey", vifisdf);
            MTAppkey.SetValue("UserNKey", nkey);
            MTAppkey.SetValue("CorKey", sre);
        }
        public static void SetIpAddressForApiBarcode(string ipAddress, string port)
        {
            RegistryKey SoftWarekey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey MTAppkey = SoftWarekey.CreateSubKey(ConnectionManager.ApplicationName);
            MTAppkey.SetValue("IpAddressForBarcode", ipAddress);
            MTAppkey.SetValue("PortForBarcode", port);
        }
        private string GetIpAddressForApiBarcode()
        {
            RegistryKey MTAppkey = Registry.CurrentUser.OpenSubKey(@"Software\" + ConnectionManager.ApplicationName);
            string nkey = MTAppkey.GetValue("IpAddressForBarcode").ToString();
            return nkey;
        }

        private static void Wr2(string regDate, string expDate)
        {

            RegistryKey SoftWarekey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey MTAppkey = SoftWarekey.CreateSubKey(ConnectionManager.ApplicationName);
            MTAppkey.SetValue("sDate", regDate);
            MTAppkey.SetValue("eDate", expDate);

        }
        public static string GetNKey()
        {
            try
            {

                RegistryKey MTAppkey = Registry.CurrentUser.OpenSubKey(@"Software\" + ConnectionManager.ApplicationName);
                string nkey = MTAppkey.GetValue("UserNKey").ToString();

                nkey = DecodeForRegistry(nkey);


                return nkey;

            }
            catch (Exception)
            {
                return "";
            }
        }

        public static bool ReeD()
        {
            RegistryKey MTAppkey;
            string startdate, enddate;
            try
            {
                MTAppkey = Registry.CurrentUser.OpenSubKey(@"Software\" + ConnectionManager.ApplicationName);
                startdate = MTAppkey.GetValue("sDate").ToString();
                enddate = MTAppkey.GetValue("eDate").ToString();
            }
            catch (Exception)
            {
                return false;
            }
            if (String.IsNullOrEmpty(startdate) || String.IsNullOrEmpty(enddate))
            {
                return false;
            }
            else
            {

                //nkey = DecodeForRegistry(nkey);
                //"b14ca5898aJeO13ybboe2boa23bo5a1box";
                var s = DecryptString(startdate);
                var e = DecryptString(enddate);

                var f = Convert.ToDateTime(s);
                var l = Convert.ToDateTime(e);

                if (DateTime.Now >= f && DateTime.Now <= l)
                {
                    string T = EncryptString(DateTime.Now.ToString());
                    RegistryKey SoftWarekey = Registry.CurrentUser.OpenSubKey("Software", true);
                    RegistryKey MyRegKey = SoftWarekey.CreateSubKey(ConnectionManager.ApplicationName);
                    try
                    {
                        MyRegKey.SetValue("sDate", T);
                    }
                    catch (Exception y)
                    {
                        _MessageBoxDialog.Show(y.ToString(), MessageBoxState.Error);

                    }
                    return true;
                }
                else
                {
                    _MessageBoxDialog.Show("انتهت صلاحية النسخة التجريبية", MessageBoxState.Error);
                    //throw new Exception();
                    return false;
                }
                return true;
            }
        }
        public static bool Ree()
        {
            try
            {
                RegistryKey MTAppkey = Registry.CurrentUser.OpenSubKey(@"Software\" + ConnectionManager.ApplicationName);
                string vifisdf = RDSFECXA__WEWDSA.GetString(RDSFECXA__WEWDSA.getMotherBoardID());
                string sre = MTAppkey.GetValue("CorKey").ToString();
                string nkey = MTAppkey.GetValue("UserNKey").ToString();
                if (vifisdf == null || vifisdf == "" || sre == null || sre == "" || nkey == null || nkey == "")
                {
                    return false;
                }
                else
                {
                    if (DecodeForRegistry(nkey) == "Demo")
                    {
                        if (checktrial(sre))
                        {
                            return true;
                        }
                        _MessageBoxDialog.Show("انتهت النسخة التجريبية لديك", MessageBoxState.Warning);
                        return false;
                    }
                    else if (CheckNumber(vifisdf, sre, nkey, false))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        static public string Availability
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in motherboardSearcher.Get())
                    {
                        return GetAvailability(int.Parse(queryObj["Availability"].ToString()));
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        private static bool checktrial(string sre)
        {
            string serial = GetString(getMotherBoardID());
            string trying = FpartTesting(serial);
            if (ReeD() && trying == DecodeForRegistry(sre))
            {
                return true;
            }
            return false;
        }
        private static string Fpart(string val)
        {
            //val = "993522"; /*DecodeForRegistry(val);*/
            byte[] tmpDeviceIdArray;
            byte[] deviceIdArray;
            int j = 0;
            string token = "";
            tmpDeviceIdArray = Encoding.UTF8.GetBytes(val);
            deviceIdArray = new byte[tmpDeviceIdArray.Length];
            for (int i = tmpDeviceIdArray.Length - 1; i > 0; i--)
            {
                deviceIdArray[j] = tmpDeviceIdArray[i];
                j++;
            }
            BigInteger bigInteger1 = new BigInteger(deviceIdArray);
            BigInteger deviceIdBigInteger = BigInteger.Abs(bigInteger1);
            BigInteger operationBigInteger = deviceIdBigInteger >> 3; // Shift R 3
            operationBigInteger = operationBigInteger ^= 4; // Flip Bits 4 
            operationBigInteger = operationBigInteger & deviceIdBigInteger;//And operation
            operationBigInteger = operationBigInteger ^= 3; // Flip Bits 3 
            operationBigInteger = operationBigInteger ^= GetBitLength(operationBigInteger); // Flip Bits 3 
            operationBigInteger = operationBigInteger << 2; // Shift L 2
            operationBigInteger = operationBigInteger ^ deviceIdBigInteger; // XOR
            operationBigInteger = operationBigInteger << 5; // Shift L 5
            operationBigInteger = operationBigInteger << Convert.ToInt32(GetBitLength(operationBigInteger)); // Shift L BitLength
            operationBigInteger = operationBigInteger ^= 2; // Flip Bits 3 
            operationBigInteger = BigInteger.Abs(operationBigInteger);
            token = operationBigInteger.ToString();

            string part1 = token.Substring(Convert.ToInt32(Math.Truncate(Convert.ToDecimal(token.Length) / 2)), 2);
            string part2 = token.Substring(Convert.ToInt32(token.Length - 1) - 2, 2);
            string part3 = token.Substring(0, 2);
            string result = part1 + part2 + part3;
            return result;
        }
        private static string FpartTesting(string val)
        {
            byte[] tmpDeviceIdArray;
            byte[] deviceIdArray;
            int j = 0;
            string token = "";
            tmpDeviceIdArray = Encoding.UTF8.GetBytes(val);
            deviceIdArray = new byte[tmpDeviceIdArray.Length];
            for (int i = tmpDeviceIdArray.Length - 1; i > 0; i--)
            {
                deviceIdArray[j] = tmpDeviceIdArray[i];
                j++;
            }
            BigInteger bigInteger1 = new BigInteger(deviceIdArray);
            BigInteger deviceIdBigInteger = BigInteger.Abs(bigInteger1);
            BigInteger operationBigInteger = deviceIdBigInteger >> 4; // Shift R 4
            operationBigInteger = operationBigInteger ^= 5; // Flip Bits 4 
            operationBigInteger = operationBigInteger & deviceIdBigInteger;//And operation
            operationBigInteger = operationBigInteger ^= 1; // Flip Bits 3 
            operationBigInteger = operationBigInteger ^= GetBitLength(operationBigInteger); // Flip Bits 3 
            operationBigInteger = operationBigInteger << 4; // Shift L 2
            operationBigInteger = operationBigInteger ^ deviceIdBigInteger; // XOR
            operationBigInteger = operationBigInteger << 9; // Shift L 5
            operationBigInteger = operationBigInteger << Convert.ToInt32(GetBitLength(operationBigInteger)); // Shift L BitLength
            operationBigInteger = operationBigInteger ^= 8; // Flip Bits 3
            operationBigInteger = BigInteger.Abs(operationBigInteger);
            token = operationBigInteger.ToString();

            string part1 = token.Substring(Convert.ToInt32(Math.Truncate(Convert.ToDecimal(token.Length) / 2)), 2);
            string part2 = token.Substring(Convert.ToInt32(token.Length - 1) - 2, 2);
            string part3 = token.Substring(0, 2);
            string result = part1 + part2 + part3;
            return result;
        }
        private static string CSprat(string val1, string val2, bool ftime)
        {
            if (!ftime)
                val1 = DecodeForRegistry(val1);

            BigInteger bigInteger1 = new BigInteger(Encoding.UTF8.GetBytes(val1));
            BigInteger bigInteger2 = new BigInteger(Encoding.UTF8.GetBytes(val2));
            string newResult = (bigInteger1 ^ bigInteger2).ToString();
            string part1 = newResult.Substring(Convert.ToInt32(Math.Truncate(Convert.ToDecimal(newResult.Length) / 2)), 2);
            string part2 = newResult.Substring(Convert.ToInt32(newResult.Length - 1) - 2, 2);
            string part3 = newResult.Substring(0, 2);
            string result = part1 + part2 + part3;
            return result;
        }

        public static string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            plainText = EncodeForRegistry(plainText);

            return plainText;

            //key = b.ToString();
            //byte[] mykey = new byte[16];
            //for (int i = 0; i < 16; i += 2)
            //{
            //    byte[] unicodeBytes = BitConverter.GetBytes(key[i % key.Length]);
            //    Array.Copy(unicodeBytes, 0, mykey, i, 2);
            //}

            //using (Aes aes = Aes.Create())
            //{
            //    aes.Key = Encoding.UTF8.GetBytes(key);
            //    aes.IV = iv;

            //    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            //    using (MemoryStream memoryStream = new MemoryStream())
            //    {
            //        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
            //        {
            //            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
            //            {
            //                streamWriter.Write(plainText);
            //            }

            //            array = memoryStream.ToArray();
            //        }
            //    }
            //}
        }

        public static string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            // byte[] buffer = Convert.FromBase64String(cipherText);

            cipherText = DecodeForRegistry(cipherText);
            return cipherText;
            //using (Aes aes = Aes.Create())
            //{
            //    aes.Key = Encoding.UTF8.GetBytes(key);
            //    aes.IV = iv;
            //    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            //    using (MemoryStream memoryStream = new MemoryStream(buffer))
            //    {
            //        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
            //        {
            //            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
            //            {
            //                return streamReader.ReadToEnd();
            //            }
            //        }
            //    }
            //}
        }

        public static bool CheckNumber(string val1, string val2, string val3, bool fTime)
        {
            string ss = Fpart(val1);
            ss = CSprat(val2, ss, fTime);
            if (!fTime)
                val3 = DecodeForRegistry(val3);
            if (ss == val3)
            {
                if (fTime)
                {
                    Wr(val1, val2, val3);
                }
                return true;
            }
            return false;
        }
        public static bool TestingNumber(string valSerial, string valNextNumber, bool fTime)
        {
            var ss = FpartTesting(valSerial);
            if (ss == valNextNumber)
            {
                if (fTime)
                {
                    Wr(valSerial, ss, "Demo");
                    //"b14ca5898aJeO13ybboe2boa23bo5a1box"
                    Wr2(EncryptString(DateTime.Now.ToString()), EncryptString(DateTime.Now.AddMonths(1).ToString()));
                }
                return true;
            }
            return false;
        }
        static public Int64 GetBitLength(BigInteger bigInteger)
        {
            Int64 bitLength = 0;
            BigInteger bigN = bigInteger;
            do
            {
                bitLength++;
                bigN /= 2;

            } while (bigN != 0);
            return bitLength;
        }
        static public string GetString(string mthr)
        {
            byte[] tmpDeviceIdArray;
            byte[] deviceIdArray;
            int j = 0;
            string token = "";
            tmpDeviceIdArray = Encoding.UTF8.GetBytes(mthr);
            deviceIdArray = new byte[tmpDeviceIdArray.Length];
            for (int i = tmpDeviceIdArray.Length - 1; i > 0; i--)
            {

                deviceIdArray[j] = tmpDeviceIdArray[i];
                j++;

            }
            BigInteger bigInteger1 = new BigInteger(deviceIdArray);
            BigInteger deviceIdBigInteger = BigInteger.Abs(bigInteger1);
            BigInteger operationBigInteger = deviceIdBigInteger >> 3; // Shift R 3
            operationBigInteger = operationBigInteger ^= 8; // Flip Bits 4 
            operationBigInteger = operationBigInteger & deviceIdBigInteger;//And operation
            operationBigInteger = operationBigInteger ^= 6; // Flip Bits 3 
            operationBigInteger = operationBigInteger ^= GetBitLength(operationBigInteger); // Flip Bits 3 
            operationBigInteger = operationBigInteger << 4; // Shift L 2
            operationBigInteger = operationBigInteger ^ deviceIdBigInteger; // Shift L 2
            operationBigInteger = operationBigInteger << 4; // Shift L 5
            operationBigInteger = operationBigInteger << Convert.ToInt32(GetBitLength(operationBigInteger)); // Shift L BitLength
            operationBigInteger = operationBigInteger ^= 4; // Flip Bits 3 
            operationBigInteger = BigInteger.Abs(operationBigInteger);
            token = operationBigInteger.ToString();

            string part1 = token.Substring(Convert.ToInt32(Math.Truncate(Convert.ToDecimal(token.Length) / 2)), 2);
            string part2 = token.Substring(Convert.ToInt32(token.Length - 1) - 2, 2);
            string part3 = token.Substring(0, 2);
            return part1 + part2 + part3;
        }
        static public bool HostingBoard
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        if (queryObj["HostingBoard"].ToString() == "True")
                            return true;
                        else
                            return false;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        static public string InstallDate
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return ConvertToDateTime(queryObj["InstallDate"].ToString());
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }
        static public string Manufacturer
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["Manufacturer"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }
        static public string Model
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["Model"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }
        static public string PartNumber
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["PartNumber"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }
        static public string PNPDeviceID
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in motherboardSearcher.Get())
                    {
                        return queryObj["PNPDeviceID"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }
        static public string PrimaryBusType
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in motherboardSearcher.Get())
                    {
                        return queryObj["PrimaryBusType"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }
        static public string Product
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["Product"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }
        static public bool Removable
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        if (queryObj["Removable"].ToString() == "True")
                            return true;
                        else
                            return false;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        static public bool Replaceable
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        if (queryObj["Replaceable"].ToString() == "True")
                            return true;
                        else
                            return false;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        static public string RevisionNumber
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in motherboardSearcher.Get())
                    {
                        return queryObj["RevisionNumber"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string SecondaryBusType
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in motherboardSearcher.Get())
                    {
                        return queryObj["SecondaryBusType"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string SerialNumber
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["SerialNumber"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string Status
        {
            get
            {
                try
                {
                    foreach (ManagementObject querObj in baseboardSearcher.Get())
                    {
                        return querObj["Status"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string SystemName
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in motherboardSearcher.Get())
                    {
                        return queryObj["SystemName"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        static public string Version
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["Version"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        private static string GetAvailability(int availability)
        {
            switch (availability)
            {
                case 1: return "Other";
                case 2: return "Unknown";
                case 3: return "Running or Full Power";
                case 4: return "Warning";
                case 5: return "In Test";
                case 6: return "Not Applicable";
                case 7: return "Power Off";
                case 8: return "Off Line";
                case 9: return "Off Duty";
                case 10: return "Degraded";
                case 11: return "Not Installed";
                case 12: return "Install Error";
                case 13: return "Power Save - Unknown";
                case 14: return "Power Save - Low Power Mode";
                case 15: return "Power Save - Standby";
                case 16: return "Power Cycle";
                case 17: return "Power Save - Warning";
                default: return "Unknown";
            }
        }

        private static string ConvertToDateTime(string unconvertedTime)
        {
            string convertedTime = "";
            int year = int.Parse(unconvertedTime.Substring(0, 4));
            int month = int.Parse(unconvertedTime.Substring(4, 2));
            int date = int.Parse(unconvertedTime.Substring(6, 2));
            int hours = int.Parse(unconvertedTime.Substring(8, 2));
            int minutes = int.Parse(unconvertedTime.Substring(10, 2));
            int seconds = int.Parse(unconvertedTime.Substring(12, 2));
            string meridian = "AM";
            if (hours > 12)
            {
                hours -= 12;
                meridian = "PM";
            }
            convertedTime = date.ToString() + "/" + month.ToString() + "/" + year.ToString() + " " +
            hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString() + " " + meridian;
            return convertedTime;
        }
        public static string getMotherBoardID()
        {
            string serial = "";
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
                ManagementObjectCollection moc = mos.Get();

                foreach (ManagementObject mo in moc)
                {
                    serial = mo["SerialNumber"].ToString();
                }
                return serial;
            }
            catch (Exception)
            {
                return serial;
            }
        }
    }
}
