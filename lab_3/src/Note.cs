using System;
using System.Collections.Generic;

namespace Notebook
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Tags { get; set; }

        public Note()
        {
            Title = string.Empty;
            Content = string.Empty;
            CreatedAt = DateTime.Now;
            Tags = new List<string>();
        }

        public override string ToString()
        {
            string tags = Tags.Count > 0 ? string.Join(", ", Tags) : "нет";
            return $"[{Id}] {Title}\n    Дата: {CreatedAt:yyyy-MM-dd HH:mm}\n    Теги: {tags}\n    {Content}";
        }
    }
}