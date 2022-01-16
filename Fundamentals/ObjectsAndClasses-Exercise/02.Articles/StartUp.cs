using System;

namespace _02.Articles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            string title = input[0];
            string content = input[1];
            string autor = input[2];

            Article article = new Article();
            article.Title = title;
            article.Content = content;
            article.Autor = autor;

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] tokens = Console.ReadLine().Split(": ");
                string command = tokens[0];
                string newInput = tokens[1];

                if (command == "Edit")
                {
                    EditContent(article, newInput);
                }
                else if (command == "ChangeAuthor")
                {
                    ChangeAutor(article, newInput);
                }
                else if (command == "Rename")
                {
                    RenameTitle(article, newInput);
                }
            }

            Console.WriteLine(PrintArticle(article));

        }
        static string PrintArticle(Article article)
        {
            string result = "";
            result = $"{article.Title} - {article.Content}: {article.Autor}";
            return result;
        }

        static void RenameTitle(Article article, string newTitle)
        {
            article.Title = newTitle;
        }

        static void ChangeAutor(Article article, string newAutor)
        {
            article.Autor = newAutor;
        }

        static void EditContent(Article article, string newContent)
        {
            article.Content = newContent;
        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Autor { get; set; }
    }
}
