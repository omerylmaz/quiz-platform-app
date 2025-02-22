﻿using Common.Domain;

namespace Quiz.Domain.Quizzes;

public sealed class QuizCreatedDomainEvent(Guid quizId) : DomainEvent
{
    public Guid QuizId { get; init; } = quizId;
}
