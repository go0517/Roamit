﻿using QuickShare.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace QuickShare.HelperClasses
{
    static class WhatsNewHelper
    {
        public static bool ShouldShowWhatsNew()
        {
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey("LatestWhatsNewVersion"))
                return true;

            if (Version.TryParse(ApplicationData.Current.LocalSettings.Values["LatestWhatsNewVersion"].ToString(), out Version v))
            {
                if (v < DeviceInfo.ApplicationVersion)
                {
                    return true;
                }
            }

            return false;
        }

        public static void InitIntro()
        {
            MarkThisWhatsNewAsRead();
        }

        public static List<string> GetWhatsNewContentId()
        {
            List<string> output = new List<string>();

            if (!ShouldShowWhatsNew())
                return output;

            Version prevVersion = new Version(0, 0, 0, 0);

            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("LatestWhatsNewVersion"))
                Version.TryParse(ApplicationData.Current.LocalSettings.Values["LatestWhatsNewVersion"].ToString(), out prevVersion);

            if ((prevVersion < new Version("1.2.1.0")) &&
                ((DeviceInfo.FormFactorType == DeviceInfo.DeviceFormFactorType.Desktop) || (DeviceInfo.FormFactorType == DeviceInfo.DeviceFormFactorType.Tablet)))
                output.Add("1");

            MarkThisWhatsNewAsRead();

            return output;
        }

        private static void MarkThisWhatsNewAsRead()
        {
            ApplicationData.Current.LocalSettings.Values["LatestWhatsNewVersion"] = DeviceInfo.ApplicationVersionString;
        }
    }
}