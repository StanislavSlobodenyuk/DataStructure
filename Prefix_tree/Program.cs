using Prefix_trie;

var trie = new Trie<int>();

trie.Add("banana");
trie.Add("bank");
trie.Add("banking");
trie.Add("bax");
trie.Add("back");

Console.WriteLine(trie.LongestCommonPrefix());