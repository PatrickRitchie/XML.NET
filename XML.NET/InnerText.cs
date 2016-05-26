﻿//  Copyright 2016 Feenux LLC
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using System.Xml;

namespace XML
{
    public static class InnerText
    {
        public static bool Set(XmlDocument doc, string xPath, string text)
        {
            bool result = false;

            if (doc != null)
            {
                XmlElement element = doc.DocumentElement;

                var node = element.SelectSingleNode(xPath);
                if (node == null) node = Nodes.Add(doc, xPath);

                node.InnerText = text;
                result = true;
            }

            return result;
        }

        public static string Get(XmlDocument doc, string xPath)
        {
            string result = null;

            if (doc != null)
            {
                XmlElement element = doc.DocumentElement;

                var node = element.SelectSingleNode(xPath);
                if (node != null)
                {
                    result = node.InnerText;
                }
            }

            return result;
        }
    }
}
