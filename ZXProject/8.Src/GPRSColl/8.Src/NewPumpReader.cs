using System;
using System.Collections;
using System.Xml;


namespace GprsSystem
{
    ///// <summary>
    ///// ��Э���վ��ȡ�������ڶ�ȡʹ����Э��ı�վ����
    ///// </summary>
    //public class NewPumpReader
    //{
    //    private string _filename = "NewPump.xml";
    //    //private ArrayList _pumpNames = new ArrayList();

    //    public NewPumpReader() : this("NewPump.xml")
    //    {
    //        //
    //        // TODO: �ڴ˴���ӹ��캯���߼�
    //        //
    //    }

    //    public NewPumpReader( string filename )
    //    {
    //        _filename = filename;
    //    }

    //    //public string[] Pumps
    //    //{
    //    //    get { return (string[]) _pumpNames.ToArray(); }
    //    //}

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string[] Read()
    //    {
    //        try
    //        {
    //            ArrayList list = new ArrayList();

    //            XmlDocument doc = new XmlDocument();
    //            doc.Load( _filename );
    //            XmlNode node = doc.DocumentElement;
    //            foreach (XmlNode n in node.ChildNodes )
    //            {
    //                list.Add( n.Attributes["name"].Value );
    //            }

    //            object[] os = list.ToArray();
    //            //string[] ss = (string[]) os;

    //            return list.ToArray( typeof( string )) as string[];
    //        }
    //        catch( Exception ex )
    //        {
    //            System.Windows.Forms.MessageBox.Show( ex.ToString() );
    //        }
    //        return null;
    //    }
    //}
}
