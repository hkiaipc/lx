using System;
using System.Collections;

namespace GprsSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class TallyItem
    {
        private string      _name;
        private ArrayList   _list;

        #region TallyItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public TallyItem( string name )
        {
            _name = name;
            _list = new ArrayList( 100 );
        }
        #endregion //TallyItem

        #region List
        /// <summary>
        /// 
        /// </summary>
        public ArrayList List
        {
            get { return _list;}
        }
        #endregion //List

        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
        #endregion //Name
    }
}
