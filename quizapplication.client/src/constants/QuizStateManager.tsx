import { ValidateCorrectAnswers } from "../helpers/ValidateCorrectAnswers";
import { QuizState } from "../types/QuizState";
import { QuizAction } from "../types/QuizStatus";
import { QuizActionType } from "./QuizActionType";
import { QuizStatus } from "./QuizStateStatus";

export function quizStateManager(state: QuizState, action: QuizAction) {
    switch (action.type) {
        case QuizActionType.DataReceived:
            return { ...state, questions: action.payload, status: QuizStatus.Ready };
        case QuizActionType.DataFail:
            return { ...state, status: QuizStatus.Failed };
        case QuizActionType.QuizStart:
            return { ...state, participant: action.payload, status: QuizStatus.Start };
        case QuizActionType.NextQuestion:
            return { ...state, index: state.index + 1, answers: [] };
        case QuizActionType.QuestionAnswered:
            return { 
                ...state, 
                answers: action.payload,
                points: ValidateCorrectAnswers(action.payload, state.questions.at(state.index)!.correctOptions) 
                    ? state.points + state.questions.at(state.index)!.points 
                    : state.points,
                index: state.index + 1
            }
        case QuizActionType.QuestionAnsweredFinal:
            return {
                ...state,
                answers: action.payload,
                points: ValidateCorrectAnswers(action.payload, state.questions.at(state.index)!.correctOptions)
                    ? state.points + state.questions.at(state.index)!.points
                    : state.points,
                status: QuizStatus.Finished
            }
        default:
            throw new Error("Unknown action");
    }
}