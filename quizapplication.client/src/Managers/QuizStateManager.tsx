import { Participant } from "../Models/Participant";
import { Question } from "../Models/Question";
import { QuizState } from "../Interfaces/QuizState";
import { QuizAction } from "../Interfaces/QuizAction";
import { QuizActionType } from "../Constants/QuizActionType";
import { QuizStatus } from "../Constants/QuizStatus";

export const quizStateManager = (state: QuizState, action: QuizAction): QuizState => {
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
        participant: {
          ...state.participant,
          finalAnswers: [
            ...state.participant.finalAnswers as string[],
            action.payload as string[],
          ] as string[],
        },
        index: state.index + 1,
      };
    case QuizActionType.QuestionAnsweredFinal:
      return {
        ...state,
        participant: {
          ...state.participant,
          finalAnswers: [
            ...state.participant.finalAnswers as string[],
            action.payload as string[],
          ] as string[],
        },
        status: QuizStatus.Finished,
      };
    default:
      throw new Error("Unknown action");
  }
}
