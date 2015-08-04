﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfHelpers.ResourceUsage
{
    class ResourceLoader
    {
        // from http://stackoverflow.com/questions/347614/wpf-image-resources


        /// <summary>
        /// Load a resource WPF-BitmapImage (png, bmp, ...) from embedded resource defined as 'Resource' not as 'Embedded resource'.
        /// </summary>
        /// <param name="pathInApplication">Path without starting slash</param>
        /// <param name="assembly">Usually 'Assembly.GetExecutingAssembly()'. If not mentionned, I will use the calling assembly</param>
        /// <returns></returns>
        public static BitmapImage LoadBitmapFromResource(string pathInApplication, Assembly assembly = null)
        {
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            if (pathInApplication[0] == '/')
            {
                pathInApplication = pathInApplication.Substring(1);
            }
            try
            {
                return
                    new BitmapImage(
                        new Uri(
                            @"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication,
                            UriKind.Absolute));
            }
            catch
            {
                return null;
            }
        }
    }
}
