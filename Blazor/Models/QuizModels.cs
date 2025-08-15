namespace Blazor.Models
{
    public class QuizData
    {
        public List<Quiz> Quizzes { get; set; } = new();
    }

    public class Quiz
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Category { get; set; } = "";
        public string Difficulty { get; set; } = "";
        public string EstimatedTime { get; set; } = "";
        public List<QuizQuestion> Questions { get; set; } = new();
    }

    public class QuizQuestion
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = "";
        public Dictionary<string, string> Options { get; set; } = new();
        public List<string> CorrectAnswers { get; set; } = new();
        public Dictionary<string, string> Explanations { get; set; } = new();
        public int ExpectedAnswerCount => CorrectAnswers.Count;
        
        // Shuffled options for display
        public Dictionary<string, string> ShuffledOptions { get; set; } = new();
        
        // Mapping from shuffled keys to original keys for validation
        public Dictionary<string, string> ShuffledToOriginalMapping { get; set; } = new();
        
        // Optional learning resource
        public LearnMore? LearnMore { get; set; }
    }

    public class LearnMore
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Url { get; set; } = "";
        public string Type { get; set; } = ""; // "article", "video", "document", etc.
        public string? Icon { get; set; } = ""; // FontAwesome icon class
    }
}
