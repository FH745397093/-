using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BSTool
{
    class Tool
    {
        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }

        /// <summary>
        /// 判断是否为IP地址
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsIp(string value)
        {
            return Regex.IsMatch(value, @"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");
        }


        public static string GetState(string value)
        {
            switch (value)
            {
                case "1":
                    return "授权使用";
                case "0":
                    return "暂停使用";
                case "-1":
                    return "废弃";

            }
            return "废弃";
        }


        public static string GetStateValue(string title)
        {
            switch (title)
            {
                case "授权使用":
                    return "1";
                case "暂停使用":
                    return "0";
                case "废弃":
                    return "-1";

            }
            return "0";
        }

        public static string GetMD5(string sDataIn)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        public static void InitRegions(TreeView tree)
        {
            TreeNode root = tree.Nodes[0];
            TreeNode sub = root.Nodes.Add("济南市");
            sub.Tag = "3701";

            sub = root.Nodes.Add("青岛市");
            sub.Tag = "3702";

            sub = root.Nodes.Add("青岛市");
            sub.Tag = "3702";

            sub = root.Nodes.Add("淄博市");
            sub.Tag = "3703";

            sub = root.Nodes.Add("枣庄市");
            sub.Tag = "3704";

            sub = root.Nodes.Add("东营市");
            sub.Tag = "3705";

            sub = root.Nodes.Add("烟台市");
            sub.Tag = "3706";

            sub = root.Nodes.Add("潍坊市");
            sub.Tag = "3707";

            sub = root.Nodes.Add("泰安市");
            sub.Tag = "3709";

            sub = root.Nodes.Add("威海市");
            sub.Tag = "3710";

            sub = root.Nodes.Add("日照市");
            sub.Tag = "3711";

            sub = root.Nodes.Add("莱芜市");
            sub.Tag = "3712";

            sub = root.Nodes.Add("临沂市");
            sub.Tag = "3713";

            sub = root.Nodes.Add("德州市");
            sub.Tag = "3714";

            sub = root.Nodes.Add("聊城市");
            sub.Tag = "3715";

            sub = root.Nodes.Add("滨州市");
            sub.Tag = "3716";

            sub = root.Nodes.Add("菏泽市1");
            sub.Tag = "3717";

            sub = root.Nodes.Add("菏泽市2");
            sub.Tag = "3729";

            sub = root.Nodes.Add("滨海");
            sub.Tag = "3730";

            sub = root.Nodes.Add("齐都");
            sub.Tag = "3731";

            sub = root.Nodes.Add("银山");
            sub.Tag = "370097";

            tree.ExpandAll();
        }
    }
}
