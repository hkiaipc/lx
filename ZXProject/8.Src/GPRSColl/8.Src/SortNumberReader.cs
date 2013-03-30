using System;
using System.Xml;
using System.Collections;
using System.Windows.Forms;

namespace GprsSystem
{

    ///// <summary>
    ///// 
    ///// </summary>
    //public enum SortNumberType
    //{
    //    Gate,
    //    Pump,
    //}

    ///// <summary>
    ///// SortNumberReader 的摘要说明。
    ///// </summary>
    //public class SortNumberReader
    //{
    //    private const string FILENAME = "SortNumber.xml";

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public SortNumberReader()
    //    {
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <returns></returns>
    //    public string[][] Read(SortNumberType snt)
    //    {
    //        XmlDocument doc = new XmlDocument();
    //        ArrayList list = new ArrayList();

    //        try
    //        {
    //            doc.Load(FILENAME);
    //            XmlNode node = doc.DocumentElement;
    //            foreach (XmlNode n in node.ChildNodes)
    //            {
    //                if (n.Name.ToUpper() == snt.ToString().ToUpper())
    //                {
    //                    XmlNodeList nodes = n.ChildNodes;
    //                    foreach (XmlNode n1 in nodes)
    //                    {
    //                        int id = int.Parse(n1.Attributes["id"].Value);
    //                        string name = n1.Attributes["name"].Value;

    //                        string[] ss = new string[] { id.ToString(), name };
    //                        list.Add(ss);
    //                    }
    //                }
    //            }
    //        }
    //        catch (System.IO.IOException)
    //        {
    //        }
    //        catch (System.Exception ex)
    //        {
    //            MessageBox.Show(ex.ToString());
    //        }

    //        if (list.Count == 0)
    //            return null;
    //        return (string[][])list.ToArray(typeof(string[]));
    //    }
    //}
}
