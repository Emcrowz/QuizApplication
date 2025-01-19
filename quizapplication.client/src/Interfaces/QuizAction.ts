import { QuizActionType } from "../Constants/QuizActionType";
import { Participant } from "../Models/Participant";
import { Question } from "../Models/Question";

export interface QuizAction {
  type: QuizActionType;
  payload?:
    | Question[]
    | Question
    | Participant[]
    | Participant
    | string[]
    | string;
}
