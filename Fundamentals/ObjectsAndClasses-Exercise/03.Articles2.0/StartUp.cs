using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string title = input[0];
                string content = input[1];
                string autor = input[2];

                articles.Add(new Article() {Title = title, Autor = autor, Content = content});
            }

            string criteria = Console.ReadLine();

            List<Article> sortedList = Sorting(articles, criteria);

            foreach (var kvp in sortedList)
            {
                Console.WriteLine($"{kvp.Title} - {kvp.Content}: {kvp.Autor}");
            }
        }

        static List<Article> Sorting(List<Article> articles, string criteria)
        {
            if (criteria == "title")
            {
                 List<Article> sortedList = articles.OrderBy(x => x.Title).ToList();
                return sortedList;
            }
            else if (criteria == "content")
            {
                List<Article> sortedList = articles.OrderBy(x => x.Content).ToList();
                return sortedList;
            }
            else if (criteria == "author")
            {
                List<Article> sortedList = articles.OrderBy(x => x.Autor).ToList();
                return sortedList;
            }

            return articles;
        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Autor { get; set; }
    }
}
