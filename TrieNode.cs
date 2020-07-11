using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotlight
{
    //A TrieNode would contain the current character , A list of files which will contain all the filenames which the current prefix is present in sorted format by its last modified or added date/time
    //and a map of its children (not using an array to save space)

    class TrieNode
    {

        public char character;
        public List<FileObj> files;
        public Dictionary<char, TrieNode> children;

        public TrieNode(char c)
        {
            character = c;
            files = new List<FileObj>();
            children = new Dictionary<char, TrieNode>();
        }
    }
}