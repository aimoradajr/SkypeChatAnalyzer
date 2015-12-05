using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SkypeChatAnalyzer
{
    public class ReportGenerator
    {
        public ReportGenerator()
        {

        }

        public int generateMessageCountReport(List<SkypeUserMessage> list)
        {
            if(list != null)
                return list.Count;
            return 0;
        }

        public string generateWordFrequencyReporttoString(List<SkypeUserMessage> list)
        {
            Dictionary<string, int> wordsTally = generateWordFrequencyReport(list);

            string tempr = "";
            for(int i=0; i < wordsTally.Keys.Count; i++)
            {
                tempr += wordsTally.Keys.ElementAt(i) + " : " + wordsTally.ElementAt(i).Value + "\n";
            }
            return tempr;
        }

        public string generateWordFrequencyReportTopNToString(List<SkypeUserMessage> list, int n)
        {
            Dictionary<string, int> wordsTally = generateWordFrequencyReport(list,true,n);

            string tempr = "";
            for (int i = 0; i < wordsTally.Keys.Count; i++)
            {
                tempr += wordsTally.Keys.ElementAt(i) + " : " + wordsTally.ElementAt(i).Value + "\n";
            }
            return tempr;
        }

        private Dictionary<string, int> generateWordFrequencyReport(List<SkypeUserMessage> list, bool sort=false, int top = 0, string condition = "")
        {
            Dictionary<string, int> wordsTally = new Dictionary<string, int>();

            foreach(SkypeUserMessage message in list)
            {
                string mcontent = message.MessageContent;

                // remove unwanted words and chars here.
                //mcontent = mcontent.Replace('<', ' ');

                string[] words = mcontent.Split(' ','\n');
                foreach(string word in words)
                {
                    string nword = word.Trim();
                    
                    if (nword == "")
                        continue;

                    if (condition == "emoticonsOnly")
                    {
                        Regex rgx = new Regex(@"(\([^\)]+\))");
                        Match match = rgx.Match(nword);
                        
                        if (match.Success)
                        {
                            do
                            {
                                string nemoticon = match.Groups[1].Value;
                                if (wordsTally.ContainsKey(nemoticon))
                                    wordsTally[nemoticon] += 1;
                                else
                                    wordsTally.Add(nemoticon, 1);

                                match = match.NextMatch();
                            }
                            while (match.Success);
                        }
                        
                        continue;
                    }

                    if (wordsTally.ContainsKey(nword))
                        wordsTally[nword] += 1;
                    else
                        wordsTally.Add(nword, 1);
                }
            }

            //sort?
            if (sort)
            {
                var items = from pair in wordsTally orderby pair.Value descending select pair;
                
                wordsTally = items.ToDictionary(pair => pair.Key, pair => pair.Value);
            }


            //top10? or top20? or all?
            if (top != 0)
            {
                wordsTally = wordsTally.Take(top).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            
            return wordsTally;
        }

        public string generateEmoticonFrequencyReportTopNToString(List<SkypeUserMessage> list, int topn)
        {
            Dictionary<string, int> wordsTally = generateWordFrequencyReport(list, true, topn, "emoticonsOnly");

            string tempr = "";
            for (int i = 0; i < wordsTally.Keys.Count; i++)
            {
                tempr += wordsTally.Keys.ElementAt(i) + " : " + wordsTally.ElementAt(i).Value + "\n";
            }
            return tempr;
        }

        public Dictionary<string, List<string>> generateLinksReport(List<SkypeUserMessage> list, bool sort = false, int top = 0, string condition = "")
        {
            Dictionary<string, List<string>> linksTally = new Dictionary<string, List<string>>();

            foreach (SkypeUserMessage message in list)
            {
                string mcontent = message.MessageContent;

                // remove unwanted words and chars here.
                //mcontent = mcontent.Replace('<', ' ');

                string[] words = mcontent.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    string nword = word.Trim();

                    if (nword == "")
                        continue;
                    
                    Regex rgx = new Regex(@"(http[s]?:\/\/[^\/]+\/)\S*");
                    Match match = rgx.Match(nword);

                    // Look for links
                    if (match.Success)
                    {
                        do
                        {
                            string site = match.Groups[1].Value;
                            if (linksTally.ContainsKey(site))
                                linksTally[site].Add(match.Groups[0].Value);
                            else
                                linksTally.Add(site, new List<string>() { match.Groups[0].Value });

                            match = match.NextMatch();
                        }
                        while (match.Success);
                    }
                }
            }

            //sort?
            if (sort)
            {
                var items = from pair in linksTally orderby pair.Value.Count descending select pair;

                linksTally = items.ToDictionary(pair => pair.Key, pair => pair.Value);
            }


            //top10? or top20? or all?
            if (top != 0)
            {
                linksTally = linksTally.Take(top).ToDictionary(pair => pair.Key, pair => pair.Value);
            }

            return linksTally;
        }

        public int generateLinkCountReport(List<SkypeUserMessage> list)
        {
            return generateLinksReport(list).Count();
        }

        public string generateLinksReportToString(List<SkypeUserMessage> list, int topn)
        {
            Dictionary<string, List<string>> linksTally = generateLinksReport(list, true, topn);
            
            string tempr = "";

            // Links site count
            tempr += "Link sites:\n";
            for (int i = 0; i < linksTally.Keys.Count; i++)
            {
                tempr += linksTally.Keys.ElementAt(i) + " : " + linksTally.ElementAt(i).Value.Count + "\n";
            }

            // Print Links
            tempr += "\nLinks:\n";
            for (int i = 0; i < linksTally.Keys.Count; i++)
            {
                foreach(string link in linksTally.ElementAt(i).Value)
                {
                    tempr +=  link + "\n";
                }
            }

            return tempr;
        }
    }
}
