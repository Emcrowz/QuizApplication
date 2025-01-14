import { QuizStatus } from "../constants/QuizStateStatus";
import { ParticipantModel } from "./ParticipantModel";
import { QuestionModel } from "./QuestionModel";

export interface QuizState {
    participant: ParticipantModel;
    questions: QuestionModel[];
    status: QuizStatus;
    index: number;
    answers: string[];
    points: number;
}