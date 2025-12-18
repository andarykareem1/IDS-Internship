namespace WebApplication2.DTOs.Answers
{
    public class AnswerDto
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
