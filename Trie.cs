using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;


namespace Spotlight
{
    class Trie
    {
        //root of our Trie
        public TrieNode root;

        //This is our final map/Index .Each key in the map represents a prefix and its value is a list of all files who has this string as its prefix , but the array/list is sorted by rank , which is assigned by recently added file first.
        public Dictionary<string, List<FileObj>> map = new Dictionary<string, List<FileObj>>();

        public Trie(TrieNode root)
        {
            this.root = root;
        }

        //basic trie insertion
        public void Insert(TrieNode node, FileObj file, int index)
        {
            if (index == file.name.Length)
            {
                //if reached the end of the string , simply add the current file to the list of current node's files 
                node.files.Add(file);
                return;
            }

            char cur = file.name[index];

            //if child does not exist yet, then create it.
            if (!node.children.ContainsKey(cur))
            {
                node.children[cur] = new TrieNode(cur);
            }

            //recur for every chaaracter of the file
            Insert(node.children[cur], file, index + 1);
            
        }



        void DfsHelper(TrieNode node, string s)
        {
            //index the current prefix with the list of files
            map[s] = node.files;

            //recur for all nodes in the trie
            foreach (KeyValuePair<char, TrieNode> child in node.children)
            {
                DfsHelper(child.Value, s + child.Key);
            }
        }

        public void Dfs(TrieNode node, string str, int index)
        {
            while (index != str.Length)
            {
                node = node.children[str[index++]];
            }
            DfsHelper(node, str);
        }

        public class Ranksort : IComparer
        {

            int IComparer.Compare(Object a, Object b)
            {
                FileObj x = (FileObj)a;
                FileObj y = (FileObj)b;
                return (y.rank - x.rank);
            }
        }


        //this is an interesting function. Basically , a trienode will call upon its children and tell them to return a list of sorted files upto their prefix
        //Then it will combine and assign it self the sorted list of all files which could be formed from current prefix(formed by the current character as the end point) .
        public List<FileObj> Update(TrieNode node)
        {

            //if reached the end 
            if (node.children.Count == 0)
            {
                //sort in descending order of rank and return the list
                node.files.Sort((a, b) => b.rank - a.rank );
                return node.files;
            }

            //combine all the list of its children
            List<FileObj> tmp = new List<FileObj>();

            foreach (KeyValuePair<char, TrieNode> child in node.children)
            {
                tmp.AddRange(Update(child.Value));
            }

            node.files.AddRange(tmp);
            node.files.Sort((a, b) => b.rank - a.rank);

            //return the sorted list
            return node.files;
        }


        public void printMap()
        {
            foreach (KeyValuePair<String, List<FileObj>> comp in map)
            {
                Console.Write(comp.Key + " => ");
                foreach (FileObj file in comp.Value)
                {
                    Console.Write(file.name + " " + file.rank + " ");
                }
                Console.WriteLine("");
            }

        }
        

        //serliazing and desearlizing the which was eventually given up because it was too time consuming
        public void SerializeNow()
        {

            Console.WriteLine("Serialising now");
            var f_fileStream = new FileStream(@"C:\\Users\\gunny\\source\\repos\\Spotlight\\tp.xml", FileMode.Create, FileAccess.Write);
            var f_binaryFormatter = new BinaryFormatter();
            f_binaryFormatter.Serialize(f_fileStream, map);
            f_fileStream.Close();

        }

        public void DeSerializeNow()
        {
            Dictionary<string, ArrayList> tp;
            Console.WriteLine("DE-Serialising now");

            var f_fileStream = File.OpenRead(@"C:\\Users\\gunny\\source\\repos\\Spotlight\\tp.xml");
            var f_binaryFormatter = new BinaryFormatter();
            tp = (Dictionary<string, ArrayList>)f_binaryFormatter.Deserialize(f_fileStream);
            f_fileStream.Close();

            while (true)
            {
                string q = Console.ReadLine();
                foreach (FileObj x in tp[q])
                    Console.WriteLine(x.name + " " + x.location + " " + x.rank);
            }



        }

    }

}