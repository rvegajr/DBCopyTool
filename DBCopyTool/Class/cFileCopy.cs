using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DatabaseCopier.Class
{
    /// <summary>
    /// EventArgs class for Progress
    /// </summary>
    public class ProgressEventArgs : EventArgs
    {
        private readonly int _progress = 0;

        public ProgressEventArgs(int progress)
        {
            _progress = progress;
        }

        //Properties.
        public int Progress
        {
            get { return _progress; }
        }
    }

    public class cFileCopy
    {
        public event ProgressEventHandler Progress;

        //http://www.pinvoke.net/default.aspx/kernel32.CopyFileEx
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName,
           CopyProgressRoutine lpProgressRoutine, IntPtr lpData, ref Int32 pbCancel,
           CopyFileFlags dwCopyFlags);

        delegate CopyProgressResult CopyProgressRoutine(
        long TotalFileSize,
        long TotalBytesTransferred,
        long StreamSize,
        long StreamBytesTransferred,
        uint dwStreamNumber,
        CopyProgressCallbackReason dwCallbackReason,
        IntPtr hSourceFile,
        IntPtr hDestinationFile,
        IntPtr lpData);

        int pbCancel;

        enum CopyProgressResult : uint
        {
            PROGRESS_CONTINUE = 0,
            PROGRESS_CANCEL = 1,
            PROGRESS_STOP = 2,
            PROGRESS_QUIET = 3
        }

        enum CopyProgressCallbackReason : uint
        {
            CALLBACK_CHUNK_FINISHED = 0x00000000,
            CALLBACK_STREAM_SWITCH = 0x00000001
        }

        [Flags]
        enum CopyFileFlags : uint
        {
            COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
            COPY_FILE_RESTARTABLE = 0x00000002,
            COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
            COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008
        }

        public void XCopy(string oldFile, string newFile)
        {
            CopyFileEx(oldFile, newFile, new CopyProgressRoutine(this.CopyProgressHandler), IntPtr.Zero, ref pbCancel, CopyFileFlags.COPY_FILE_RESTARTABLE);
        }

        private CopyProgressResult CopyProgressHandler(long total, long transferred, long streamSize, long StreamByteTrans, uint dwStreamNumber, CopyProgressCallbackReason reason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData)
        {
            //calculate progress
            int iProgress;
            iProgress = (int)(((float)transferred/(float)total) * 100);
            Progress(this, new ProgressEventArgs(iProgress));
            return CopyProgressResult.PROGRESS_CONTINUE;
        }

  
    }
}

