using System;
using System.Runtime.InteropServices;

namespace GprsSystem
{
    public class WavePlayer 
    {
        private const int SND_SYNC            = 0x0000  ; /* play synchronously (default) */
        private const int SND_ASYNC           = 0x0001  ; /* play asynchronously */
        private const int SND_NODEFAULT       = 0x0002  ; /* silence (!default) if sound not found */
        private const int SND_MEMORY          = 0x0004  ; /* pszSound points to a memory file */
        private const int SND_LOOP            = 0x0008  ; /* loop the sound until next sndPlaySound */
        private const int SND_NOSTOP          = 0x0010  ; /* don't stop any currently playing sound */

        private const int SND_NOWAIT      = (int)0x00002000L ; /* don't wait if the driver is busy */
        private const int SND_ALIAS       = (int)0x00010000L ; /* name is a registry alias */
        private const int SND_ALIAS_ID    = (int)0x00110000L ; /* alias is a predefined ID */
        private const int SND_FILENAME    = (int)0x00020000L ; /* name is file name */
        private const int SND_RESOURCE    = (int)0x00040004L ; /* name is resource name or atom */

        
        [DllImport("winmm.DLL", EntryPoint="PlaySound",  SetLastError=true)]
        private static extern bool PlaySound(
            string pszSound,  
            int hmod,     
            uint fdwSound    
            );

        #region PlaySimple
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static public bool PlaySimple( string fileName )
        {
            return PlaySound( fileName, 0, SND_FILENAME | SND_ASYNC | SND_NOSTOP );
        }
        #endregion //PlaySimple
    }

}
