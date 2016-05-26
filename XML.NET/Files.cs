// Copyright (c) 2016 Feenux LLC, All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.IO;
using System.Xml;

namespace XML
{
    public static class Files
    {

        public static bool WriteDocument(XmlDocument doc, string path)
        {
            var settings = new XmlWriterSettings();
            settings.Indent = true;

            int attempt = 0;
            int maxAttempts = 3;
            bool success = false;

            while (!success && attempt < maxAttempts)
            {
                try
                {
                    using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    {
                        using (var writer = XmlWriter.Create(fs, settings))
                        {
                            doc.Save(writer);
                            success = true;
                        }
                    }
                }
                catch (XmlException ex) { if (Configuration.Verbose) Console.WriteLine("XmlException :: " + ex.Message); }
                catch (Exception ex) { if (Configuration.Verbose) Console.WriteLine("Exception :: " + ex.Message); }

                if (!success) System.Threading.Thread.Sleep(50);

                attempt++;
            }

            return success;
        }

        public static XmlDocument ReadDocument(string path, XmlReaderSettings settings = null)
        {
            if (File.Exists(path))
            {
                int attempt = 0;
                int maxAttempts = 3;
                bool success = false;

                while (!success && attempt < maxAttempts)
                {
                    try
                    {
                        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (var reader = XmlReader.Create(fs, settings))
                            {
                                var xml = new XmlDocument();
                                xml.Load(reader);
                                success = true;
                                return xml;
                            }
                        }
                    }
                    catch (XmlException ex) { if (Configuration.Verbose) Console.WriteLine("XmlException :: " + ex.Message); }
                    catch (Exception ex) { if (Configuration.Verbose) Console.WriteLine("Exception :: " + ex.Message); }

                    if (!success) System.Threading.Thread.Sleep(50);

                    attempt++;
                }
            }

            return null;
        }

    }
}
