import { QuizStatus } from "./QuizStateStatus";

export const quizInitialState = {
    participant: null,
    questions: [],
    status: QuizStatus.Loading,
    index: 0,
    answers: [],
    points: 0
};