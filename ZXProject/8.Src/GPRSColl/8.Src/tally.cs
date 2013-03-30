using System;
using System.Collections;

namespace GprsSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Tally
    {
        private const int MAXCOUNT = 500 ;

        private ArrayList _itemList = new ArrayList();

        #region Tally
        /// <summary>
        /// 
        /// </summary>
        public Tally()
        {
        }
        #endregion //Tally

        #region Add
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void Add( string name, object data )
        {
            bool isFind = false;

            foreach ( object obj in _itemList )
            {
                TallyItem ti = obj as TallyItem;
                if ( string.Compare( ti.Name, name, true ) == 0 )
                {
                    isFind = true;
                    if ( ti.List.Count >= MAXCOUNT )
                        ti.List.Clear();

                    ti.List.Add( data );
                    break;
                }
            }

            if ( !isFind )
            {
                TallyItem ti = new TallyItem( name );
                ti.List.Add( data );
                _itemList.Add( ti );
            }
        }
        #endregion //Add

        #region Clear
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            foreach ( object obj in _itemList )
            {
                TallyItem ti = obj as TallyItem;
                ti.List.Clear();
            }
        }
        #endregion //Clear

        #region AddTallyItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void AddTallyItem( string name )
        {
            TallyItem item = new TallyItem( name );
            _itemList.Add( item );
        }
        #endregion //AddTallyItem
   
        #region this 
        /// <summary>
        /// 
        /// </summary>
        public TallyItem this[ int index ]
        {
            get { return _itemList[ index ] as TallyItem; }
        }
        #endregion //this

        #region Count
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _itemList.Count; }
        }
        #endregion //Count
    }
}

