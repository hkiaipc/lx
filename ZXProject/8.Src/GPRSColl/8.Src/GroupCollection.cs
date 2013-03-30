using System;
using System.Net ;
using System.Collections.Generic;
using System.Text;

namespace GprsSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class GroupCollection : Xdgk.Common.Collection<Group>
    {
        /// <summary>
        /// 
        /// </summary>
        static public GroupCollection Default
        {
            get
            {
                if (s_default == null)
                {
                    s_default = new GroupCollection();
                }
                return s_default;
            }
        } static private GroupCollection s_default;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public Group GetGroup(IPAddress ip)
        {
            Group r = null;

            foreach (Group g in this)
            {
                if (g.IP.Equals(ip))
                {
                    r = g;
                    break;
                }
            }

            if (r == null)
            {
                Group ng = new Group();
                ng.IP = ip;
                this.Add(ng);
                r = ng;
            }

            return r;
        }

    }
}
