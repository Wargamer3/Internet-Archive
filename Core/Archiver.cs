using Hayden.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface Archiver
    {
        void WriteAll(string Board, ulong ThreadNumber, Post[] Posts);
        void AppendAll(string Board, ulong ThreadNumber, int NumberOfEntriesToSkip, Post[] Posts);
        void Archive(string board, ulong threadNumber);
    }
}
