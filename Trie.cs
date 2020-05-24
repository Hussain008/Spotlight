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
        public TrieNode root;

        public Dictionary<string, List<FileObj>> map = new Dictionary<string, List<FileObj>>();

        public Trie(TrieNode root)
        {
            this.root = root;
        }

        public void Insert(TrieNode node, FileObj file, int index)
        {
            if (index == file.name.Length)
            {
                node.files.Add(file);
                return;
            }

            char cur = file.name[index];

            if (!node.children.ContainsKey(cur))
            {
                node.children[cur] = new TrieNode(cur);
            }



            Insert(node.children[cur], file, index + 1);
            
        }



        void DfsHelper(TrieNode node, string s)
        {

            map[s] = node.files;

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

        public List<FileObj> Update(TrieNode node)
        {


            if (node.children.Count == 0)
            {
                node.files.Sort((a, b) => b.rank - a.rank );
                return node.files;
            }

            List<FileObj> tmp = new List<FileObj>();

            foreach (KeyValuePair<char, TrieNode> child in node.children)
            {
                tmp.AddRange(Update(child.Value));
            }

            node.files.AddRange(tmp);
            node.files.Sort((a, b) => b.rank - a.rank);

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