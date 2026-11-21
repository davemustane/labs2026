using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Notebook
{
    public static class NoteRepository
    {
        private static readonly string FilePath = Path.Combine("data", "notes.json");

        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public static List<Note> Load()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    return new List<Note>();
                }

                string json = File.ReadAllText(FilePath);
                var notes = JsonSerializer.Deserialize<List<Note>>(json);
                return notes ?? new List<Note>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"[Ошибка] Файл данных повреждён: {ex.Message}");
                Console.WriteLine("Будет использован пустой список заметок.");
                return new List<Note>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Ошибка] Не удалось прочитать файл: {ex.Message}");
                return new List<Note>();
            }
        }

        public static void Save(List<Note> notes)
        {
            try
            {
                string? directory = Path.GetDirectoryName(FilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string json = JsonSerializer.Serialize(notes, JsonOptions);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Ошибка] Не удалось сохранить файл: {ex.Message}");
            }
        }
    }
}