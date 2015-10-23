﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.MachineKeyUtil
{
    public static class KeyCreator
    {

        public static string GetRandomKey(int bytelength)
        {
            byte[] buff = new byte[bytelength];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buff);
            StringBuilder sb = new StringBuilder(bytelength * 2);
            for (int i = 0; i < buff.Length; i++)
                sb.Append(string.Format("{0:X2}", buff[i]));
            return sb.ToString();
        }
        public static string GetASPNET20machinekey()
        {
            StringBuilder aspnet20machinekey = new StringBuilder();
            string key64byte = GetRandomKey(64);
            string key32byte = GetRandomKey(32);
            aspnet20machinekey.Append("<machineKey \n");
            aspnet20machinekey.Append("validationKey=\"" + key64byte + "\"\n");
            aspnet20machinekey.Append("decryptionKey=\"" + key32byte + "\"\n");
            aspnet20machinekey.Append("validation=\"SHA1\" decryption=\"AES\"\n");
            aspnet20machinekey.Append("/>\n");
            return aspnet20machinekey.ToString();
        }

        public static string GetASPNET11machinekey()
        {
            StringBuilder aspnet11machinekey = new StringBuilder();
            string key64byte = GetRandomKey(64);
            string key24byte = GetRandomKey(24);

            aspnet11machinekey.Append("<machineKey ");
            aspnet11machinekey.Append("validationKey=\"" + key64byte + "\"\n");
            aspnet11machinekey.Append("decryptionKey=\"" + key24byte + "\"\n");
            aspnet11machinekey.Append("validation=\"SHA1\"\n");
            aspnet11machinekey.Append("/>\n");
            return aspnet11machinekey.ToString();
        }
    }
}
