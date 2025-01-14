import { QuizActionType } from "../constants/QuizActionType";
import { ParticipantModel } from "./ParticipantModel";
import { QuestionModel } from "./QuestionModel";

export interface QuizAction {
    type: QuizActionType;
    payload?: QuestionModel[] | QuestionModel | ParticipantModel[] | ParticipantModel | string[];
}