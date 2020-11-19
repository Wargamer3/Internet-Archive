using System;
using System.IO;
using Hayden.Models;

namespace Core
{
    public class BinaryDiskArchiver : Archiver
    {
        private readonly string PathToRoot;

        public BinaryDiskArchiver(string PathToRoot)
        {
            this.PathToRoot = PathToRoot;
        }

        public void AppendAll(string Board, ulong ThreadNumber, int NumberOfEntriesToSkip, Post[] Posts)
        {
            string ThreadFolder = PathToRoot + "/" + Board + "/" + ThreadNumber;
            Directory.CreateDirectory(ThreadFolder);

            FileStream FS = new FileStream(ThreadFolder + "/Posts.bin", FileMode.Append, FileAccess.Write);
            BinaryWriter BW = new BinaryWriter(FS);

            for (int i = NumberOfEntriesToSkip; i < Posts.Length; ++i)
            {
                Post ActivePost = Posts[i];
                BW.Write(ActivePost.PostNumber);
                BW.Write(ActivePost.OriginalFilenameFull ?? "");
                BW.Write(ActivePost.Comment ?? "");
            }

            FS.Close();
            BW.Close();
        }

        public void Archive(string board, ulong threadNumber)
        {
        }

        public void WriteAll(string Board, ulong ThreadNumber, Post[] Posts)
        {
            string ThreadFolder = PathToRoot + "/" + Board + "/" + ThreadNumber;
            Directory.CreateDirectory(ThreadFolder);

            FileStream FS = new FileStream(ThreadFolder + "/Posts.bin", FileMode.Create, FileAccess.Write);
            BinaryWriter BW = new BinaryWriter(FS);

            foreach (Post ActivePost in Posts)
            {
                BW.Write(ActivePost.PostNumber);
                BW.Write(ActivePost.OriginalFilenameFull ?? "");
                BW.Write(ActivePost.Comment ?? "");
            }

            FS.Close();
            BW.Close();
        }
    }
}
