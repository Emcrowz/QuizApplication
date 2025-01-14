import { ValidateCorrectAnswers } from "../Helpers/ValidateCorrectAnswers";
import { Participant } from "../Models/Participant";
import { Question } from "../Models/Question";
import { QuizState } from "../Interfaces/QuizState";
import { QuizAction } from "../Interfaces/QuizAction";
import { QuizActionType } from "../Constants/QuizActionType";
import { QuizStatus } from "../Constants/QuizStatus";

export function quizStateManager(state: QuizState, action: QuizAction) {
  switch (action.type) {
    case QuizActionType.DataReceived:
      return {
        ...state,
        questions: action.payload as Question[],
        status: QuizStatus.Ready,
      };
    case QuizActionType.DataFail:
      return { ...state, status: QuizStatus.Failed };
    case QuizActionType.QuizStart:
      return {
        ...state,
        participant: action.payload as Participant,
        status: QuizStatus.Start,
      };
    case QuizActionType.NextQuestion:
      return { ...state, index: state.index + 1, answers: [] };
    case QuizActionType.QuestionAnswered:
      return {
        ...state,
        answers: action.payload as string[],
        points: ValidateCorrectAnswers(
          action.payload as string[],
          state.questions.at(state.index)!.correctOptions
        )
          ? state.points + state.questions.at(state.index)!.points
          : state.points,
        index: state.index + 1,
      };
    case QuizActionType.QuestionAnsweredFinal:
      return {
        ...state,
        answers: action.payload as string[],
        points: ValidateCorrectAnswers(
          action.payload as string[],
          state.questions.at(state.index)!.correctOptions
        )
          ? state.points + state.questions.at(state.index)!.points
          : state.points,
        status: QuizStatus.Finished,
      };
    default:
      throw new Error("Unknown action");
  }
}
