using System.Text.Json;
using Blazor.Models;
using Microsoft.AspNetCore.Hosting;

namespace Blazor.Service
{
    public interface IQuizService
    {
        Task<List<Quiz>> GetAllQuizzesAsync();
        Task<Quiz?> GetQuizByIdAsync(string id);
        Task<Quiz?> GetQuizByTitleAsync(string title);
    }

    public class QuizService : IQuizService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<QuizService> _logger;
        private QuizData? _quizData;
        private readonly Random _random = new Random();

        public QuizService(IWebHostEnvironment webHostEnvironment, ILogger<QuizService> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public async Task<List<Quiz>> GetAllQuizzesAsync()
        {
            try
            {
                if (_quizData == null)
                {
                    await LoadQuizDataAsync();
                }

                return _quizData?.Quizzes ?? new List<Quiz>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fejl ved indlæsning af quizzer");
                return new List<Quiz>();
            }
        }

        public async Task<Quiz?> GetQuizByIdAsync(string id)
        {
            try
            {
                if (_quizData == null)
                {
                    await LoadQuizDataAsync();
                }

                return _quizData?.Quizzes?.FirstOrDefault(q => q.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fejl ved indlæsning af quiz med ID: {QuizId}", id);
                return null;
            }
        }

        public async Task<Quiz?> GetQuizByTitleAsync(string title)
        {
            try
            {
                if (_quizData == null)
                {
                    await LoadQuizDataAsync();
                }

                return _quizData?.Quizzes?.FirstOrDefault(q => 
                    q.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fejl ved indlæsning af quiz med titel: {QuizTitle}", title);
                return null;
            }
        }

        private async Task LoadQuizDataAsync()
        {
            try
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "data", "quizzes.json");
                
                if (!File.Exists(filePath))
                {
                    _logger.LogWarning("Quiz data fil ikke fundet: {FilePath}", filePath);
                    _quizData = new QuizData();
                    return;
                }

                var jsonContent = await File.ReadAllTextAsync(filePath);
                _quizData = JsonSerializer.Deserialize<QuizData>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (_quizData == null)
                {
                    _logger.LogWarning("Kunne ikke deserialisere quiz data");
                    _quizData = new QuizData();
                    return;
                }

                // Shuffle options for all questions
                foreach (var quiz in _quizData.Quizzes)
                {
                    foreach (var question in quiz.Questions)
                    {
                        ShuffleQuestionOptions(question);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fejl ved indlæsning af quiz data fra JSON fil");
                _quizData = new QuizData();
            }
        }

        private void ShuffleQuestionOptions(QuizQuestion question)
        {
            // Create a list of option pairs to shuffle
            var optionPairs = question.Options.ToList();
            
            // Shuffle the pairs
            for (int i = optionPairs.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                var temp = optionPairs[i];
                optionPairs[i] = optionPairs[j];
                optionPairs[j] = temp;
            }

            // Create new shuffled options with new keys (A, B, C, D...)
            question.ShuffledOptions.Clear();
            question.ShuffledToOriginalMapping.Clear();
            
            var newKeys = new[] { "A", "B", "C", "D", "E", "F" }; // Support for up to 6 options
            
            for (int i = 0; i < optionPairs.Count; i++)
            {
                var newKey = newKeys[i];
                var originalKey = optionPairs[i].Key;
                var optionText = optionPairs[i].Value;
                
                question.ShuffledOptions[newKey] = optionText;
                question.ShuffledToOriginalMapping[newKey] = originalKey;
            }
        }
    }
}
