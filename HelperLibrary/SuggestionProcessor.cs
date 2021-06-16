using HelperLibrary.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelperLibrary
{
    public class SuggestionProcessor
    {
        public static List<string> QuestionTags = new List<string>() {
            "what", "who", "where", "when", "why", "which", "how", "can", "are", "will", "is", "whom", "whose"
        };

        public static string GetTranslatedQuestionTag(string QuestionTag, string Lang) 
        {
            if(Lang == "en")
            {
                return QuestionTag;
            }
            else
            {
                // TODO: Translation call goes here
                return QuestionTag;
            }
        }

        public static async Task<List<Suggestion>> GetData(string Keyword, string Lang, string Country)
        {
            string Url;

            List<Suggestion> Suggestions = new List<Suggestion>();

            for (int i = 0; i < QuestionTags.Count; i++) 
            {
                string CurrentQuestionTag = QuestionTags[i];

                Url = "http://suggestqueries.google.com/complete/search?&output=toolbar&hl=en&q=" + GetTranslatedQuestionTag(CurrentQuestionTag, Lang) + "+" + Keyword + "&gl=" + Country;
                Debug.WriteLine(Url);
                using (HttpResponseMessage Response = await ApiHelper.ApiClient.GetAsync(Url))
                {
                    if (Response.IsSuccessStatusCode)
                    {
                        // TODO: Complete this
                        string RawXml = Response.Content.ReadAsStringAsync().Result;

                        XElement ResponseXml = XElement.Parse(RawXml);
                        List<XElement> ResponseXmlNodes = ResponseXml.Elements("CompleteSuggestion").ToList();

                        for(int j = 0; j < ResponseXmlNodes.Count; j++)
                        {
                            XAttribute DataAttribute = ResponseXmlNodes[j].Element("suggestion").Attribute("data");

                            if(DataAttribute != null)
                            {
                                string Query = DataAttribute.Value;

                                Suggestion SuggestedQuery = new Suggestion();
                                SuggestedQuery.QuestionTag = CurrentQuestionTag;
                                SuggestedQuery.Query = Query;

                                Suggestions.Add(SuggestedQuery);
                            }
                        }

                    }
                    else
                    {
                        throw new Exception(Response.ReasonPhrase);
                    }
                }
            }

            return Suggestions;
        }
    }
}
