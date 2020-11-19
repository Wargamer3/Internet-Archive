using Hayden.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Data
{
    public class ImageBoardService
    {
        private readonly static string PathToRoot = "H:/Archive";

        public Task<Post[]> GetForecastAsync(string Board, string ThreadNumber)
        {
            string ThreadFolder = PathToRoot + "/" + Board + "/" + ThreadNumber;

            return Task.Run(() => {
                List<Post> ListPost = new List<Post>();
                FileStream FS = new FileStream(ThreadFolder + "/Posts.bin", FileMode.Open, FileAccess.Read);
                BinaryReader BR = new BinaryReader(FS);

                bool FinishedReading = false;

                while (!FinishedReading)
                {
                    try
                    {
                        Post NewPost = new Post();
                        NewPost.PostNumber = BR.ReadUInt64();
                        NewPost.OriginalFilename = BR.ReadString();
                        NewPost.Comment = BR.ReadString();
                        ListPost.Add(NewPost);
                    }
                    catch (Exception ex)
                    {
                        FinishedReading = true;
                    }
                }

                FS.Close();
                BR.Close();

                return ListPost.ToArray();
            });
        }
    }
}
